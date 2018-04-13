using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace AdvantechPCIDemo
{
    /// <summary>
    /// 数据读取策略：
    /// 采集卡读取速度极快（10MS/s、30MS/s），因此现将采集卡数据保存至指定文件，多线程同步将数据读取
    /// 再对数据进行处理、显示
    /// </summary>
    public class AnalogCard
    {
        protected int channelCount;//通道数
        protected uint readLength;//数据一次读取长度
        protected uint readCount;

        protected ManualResetEventSlim readEvent = new ManualResetEventSlim(false);
        protected ManualResetEventSlim writeEvent = new ManualResetEventSlim(false);
        protected ManualResetEventSlim readADEvent = new ManualResetEventSlim(false);

        protected Task writeTask;//任务：将内存Queue数据写入指定文件
        protected Task readTask;//任务：将指定文件数据读入内存Queue
        protected Task readADTask;//任务：将采集卡数据读取进内存Queue

        protected Queue<ushort[]> dataQueue = new Queue<ushort[]>(1000);//先进先出队列，定义初始长度，不足自动增长
        protected CancellationTokenSource source = new CancellationTokenSource();//线程是否取消
        protected string fileName = string.Format("Data\\Data-{0}.txt", DateTime.Now.ToString("yy-MM-dd-HH-mm-ss"));//定义数据保存与读取文件名
        protected Action<ushort[][]> ChannelDataAction { get; set; }

        public AnalogCard()
        {
            //将内存Queue数据写入指定文件
            writeTask = Task.Factory.StartNew(() =>
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
                {
                    while (true)
                    {
                        writeEvent.Wait(source.Token);//等待开启写入任务
                        if (source.IsCancellationRequested) return;

                        if (dataQueue.Count == 0) continue; ;
                        ushort[] us = dataQueue.Dequeue();//将第一个数据去除并移除
                        if (dataQueue.Count > 1000) { dataQueue.Clear(); }

                        byte[] bt = new byte[readLength * 2];

                        for (int i = 0, j = 0; i < us.Length; i++)
                        {
                            ushort temp = us[i];
                            bt[j++] = (byte)(temp >> 8);//取高八位
                            bt[j++] = (byte)temp;//取低八位
                        }
                        fs.Write(bt, 0, bt.Length);
                    }
                }
            }, source.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

            Thread.Sleep(500);

            //将指定文件的数据流写入内存队列Queue
            readTask = Task.Factory.StartNew(() =>
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Write))
                {
                    int currentLength = 0;
                    byte[] bt=null;
                    while (true)
                    {
                        readEvent.Wait(source.Token);//等待开启读取
                        if (source.IsCancellationRequested) break;//任务被取消

                        if (bt == null)
                        {
                            bt = new byte[readLength * 2];//byte数组为需要读取数据的两倍：两个字节转换为一个字符
                        }
                        
                        if (currentLength < bt.Length)
                        {
                            currentLength = fs.Read(bt, currentLength, bt.Length - currentLength);
                        }
                        else
                        {
                            currentLength = 0;

                            if (ChannelDataAction == null)
                                throw new Exception("无通道数据接收方法！");

                            ushort[][] us;
                            if (!GetChannelData(bt, out us))
                                throw new Exception("");

                            ChannelDataAction(us);//将读取到的数据向上传递
                        }
                    }
                }
            });
        }

        protected virtual void StartWriteReadTxt()
        {
            writeEvent.Set();
            readEvent.Set();
            readADEvent.Set();

            dataQueue.Clear();
        }

        protected virtual void StopWriteReadTxt()
        {
            writeEvent.Reset();
            readEvent.Reset();
            readADEvent.Reset();
        }

        public virtual void CancelWriteReadTxt()
        {
            source.Cancel();
        }

        /// <summary>
        /// 将读取的数据分到各通道
        /// 数据顺序：temp[0]+temp[1]=ch1va1;temp[2]+temp[3]=ch2va1...
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private bool GetChannelData(byte[] temp, out ushort[][] us)
        {
            us = new ushort[channelCount][];

            int index = 0;
            for (int i = 0; i < temp.Length; i+=2*channelCount)
            {
                
                for (int j = 0; j < channelCount; j++)
                {
                    if (us[j] == null)
                    {
                        us[j] = new ushort[readLength / channelCount];
                    }

                    us[j][index] = (ushort)((temp[i + j * 2] << 8) + temp[i + j * 2 + 1]);
                }
                index++;
            }
            return true;
        }


    }
}
