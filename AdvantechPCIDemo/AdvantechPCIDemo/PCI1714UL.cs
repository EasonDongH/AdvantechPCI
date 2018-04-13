using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.BDaq;
using System.Threading;
using System.Threading.Tasks;

namespace AdvantechPCIDemo
{
    public class PCI1714UL:AnalogCard
    {
        private string deviceCode = "";
        private const int bufferLength = 2048;
        private int channelMax=0;
        private BufferedAiCtrl bufferedCtrl = null;
        private InstantAiCtrl instantAiCtrl = null;
        private ManualResetEventSlim readADInternal = new ManualResetEventSlim(false);//有数据再开启
        private ushort[] data;
        private object locker = new object();

        public PCI1714UL(string deviceCode):base()
        {
            this.deviceCode = deviceCode;
        }

        public void StartBufferedAI(int channelCount,Action<ushort[][]> channelDataAction)
        {
            bufferedCtrl = new BufferedAiCtrl();
            bufferedCtrl.SelectedDevice = new DeviceInformation(deviceCode);
            
            this.channelCount = channelCount;
            this.readLength = (uint)(bufferLength * channelCount);
            this.readCount = bufferLength;
            this.data = new ushort[readLength];
            this.ChannelDataAction = channelDataAction;

            ScanChannel channel = bufferedCtrl.ScanChannel;
            channel.ChannelCount = channelCount;
            channel.ChannelStart = 0;
            channel.IntervalCount = bufferLength; // each channel 触发DataReady事件的采样个数，即到了指定个数之后便触发DataReady事件，可以跟windows的定时器控件类似
            channel.Samples = bufferLength;//采样的个数。例如，我设定采样个数为1024个，Rate是1024/s，那么也就是说采样经过了1秒   

            bufferedCtrl.DataReady += new EventHandler<BfdAiEventArgs>(BufferedReady);
            this.channelMax = bufferedCtrl.Features.ChannelCountMax;
            bufferedCtrl.Streaming = false;
            ErrorCode ret = bufferedCtrl.Prepare();//初始化所选设备，准备开始
            if (ret != ErrorCode.Success) throw new InvalidOperationException("Failed to prepare AD!");

            //将采集卡数据读取到Queue
            readADTask = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    readADEvent.Wait(source.Token);//等待开启
                    if (source.IsCancellationRequested) return;

                    if (!StartDevice()) return;//查看设备是否已运行
                    readADInternal.Wait(source.Token);//先等待，有数据传递触发BufferedReady后再开启

                    if (dataQueue.Count > 1000) dataQueue.Clear();

                    dataQueue.Enqueue(data);
                }
            }, source.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

            StartWriteReadTxt();
        }

        public void StopBufferedAI()
        {
            bufferedCtrl.Stop();
            //bufferedCtrl.Dispose();
            StopWriteReadTxt();
        }

        public double[] StartInstantAI()
        {
            instantAiCtrl = new InstantAiCtrl();
            instantAiCtrl.SelectedDevice = new DeviceInformation(deviceCode);
            if (!instantAiCtrl.Initialized)
            {
                throw new Exception("No device be selected or device open failed!");
            }
            double[] data=new double[4] ;
            ErrorCode er0 = instantAiCtrl.Read(0,out data[0]);
            ErrorCode er1 = instantAiCtrl.Read(1, out data[1]);
            ErrorCode er2 = instantAiCtrl.Read(2, out data[2]);
            ErrorCode er3 = instantAiCtrl.Read(3, out data[3]);

            return data;
        }

        public void StopInstantAI()
        {
            if (instantAiCtrl.State == ControlState.Running)
            {
                instantAiCtrl.Dispose(); ;
            }
        }

        private bool StartDevice()
        {
            ErrorCode ret;
            if (bufferedCtrl.State != ControlState.Running)
            {
                readADInternal.Reset();

                ret = bufferedCtrl.Start();
                //Thread.Sleep(500);
                if (ret != ErrorCode.Success)
                {
                    //log.ErrorFormat("Failed to start PCI1714 first time! ErrorCode is {0}.", ret);

                    ret = bufferedCtrl.Stop();
                    if (ret != ErrorCode.Success)
                    {
                        //log.ErrorFormat("Failed to stop PCI1714! ErrorCode is {0}.", ret);
                    }

                    Thread.Sleep(500);

                    ret = bufferedCtrl.Start();
                    if (ret != ErrorCode.Success)
                    {
                        //log.ErrorFormat("Failed to start PCI1714 second time! ErrorCode is {0}.", ret);
                        return false;
                    }
                }

            }
            return true;
        }

        public void BufferedReady(object e,BfdAiEventArgs b)
        {
            short[] data = new short[b.Count];
            ErrorCode ret = bufferedCtrl.GetData(b.Count, data);//data存放的是从采集卡得到的数据
            if (ret != ErrorCode.Success)
            {                
                lock (locker)
                {
                    this.data = null;
                    readADInternal.Set();
                }
            }

            lock (locker)
            {
                this.data = data.Select(o => (ushort)o).ToArray();
                readADInternal.Set();
            }
        }
    }
}
