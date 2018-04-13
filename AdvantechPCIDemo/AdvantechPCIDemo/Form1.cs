using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Automation.BDaq;

namespace AdvantechPCIDemo
{
    public partial class FrmMain : Form
    {
        private ushort[][] us;//接受PCI发生来的数据
        private string deviceName = "PCI-1714UL,BID#13";
        public FrmMain()
        {
            InitializeComponent();

            OperateCustomBtn(false);

            DrawGrid(this.pbBuffCh1);
            DrawGrid(this.pbBuffCh2);
            DrawGrid(this.pbBuffCh3);
            DrawGrid(this.pbBuffCh4);

            DrawGrid(this.pbIstantCh1);
            DrawGrid(this.pbIstantCh2);
            DrawGrid(this.pbIstantCh3);
            DrawGrid(this.pbIstantCh4);
        }

        #region 数据列表定义
        private List<Point[]> pointFromBuffAI = new List<Point[]>();
        private List<double[]> dataFromBuffAI = new List<double[]>();

        private List<Point[]> pointFromInstantAI = new List<Point[]>();
        private List<double[]> dataFromInstantAI = new List<double[]>();
        #endregion

        #region 画网格和曲线
        /// <summary>
        /// 画网格
        /// </summary>
        /// <param name="pb"></param>
        private void DrawGrid(PictureBox pb)
        {
            int width = pb.Width, height = pb.Height;
            int cellWidth = height / 4;
            Color color = Color.Green;//绿色线条

            Bitmap bp = new Bitmap(width, height);
            Graphics objG = Graphics.FromImage(bp);
            objG.FillRectangle(new SolidBrush(Color.Black), 0, 0, width, height);//黑色背景

            //网格列
            for (int i = 0; i < width; i += cellWidth)
            {
                objG.DrawLine(new Pen(new SolidBrush(color)), i + cellWidth, 0, i + cellWidth, height);
            }

            //网格行
            for (int i = 0; i < width; i += cellWidth)
            {
                objG.DrawLine(new Pen(new SolidBrush(color)), 0, i + cellWidth, width, i + cellWidth);
            }

            pb.Image = bp;
        }


        /// <summary>
        /// 画动态曲线
        /// </summary>
        /// <param name="channelIndex"></param>
        /// <param name="pb"></param>
        private void DrawBufferedAICurve()
        {
            for (int channel = 0; channel < 4; channel++)
            {
                PictureBox pbTemp = null;
                switch (channel)
                {
                    case 0:
                        pbTemp = this.pbBuffCh1; break;
                    case 1:
                        pbTemp = this.pbBuffCh2; break;
                    case 2:
                        pbTemp = this.pbBuffCh3; break;
                    case 3:
                        pbTemp = this.pbBuffCh4; break;
                }

                int width = pbTemp.Width, height = pbTemp.Height;

                if (pointFromBuffAI.Count == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        pointFromBuffAI.Add(new Point[width]);
                    }
                }
                lock (locker)
                {


                    while (dataFromBuffAI.Count >= width + 2)
                    {
                        dataFromBuffAI.RemoveAt(0);
                    }
                }

                int count = dataFromBuffAI.Count;

                if (count != 0)
                {
                    pointFromBuffAI[channel] = new Point[count];
                }

                for (int i = 0; i < width + 1; i++)
                {
                    if (i >= count) break;

                    if (dataFromBuffAI[i] == null) continue;

                    pointFromBuffAI[channel][i] = new Point(i, (int)(height - ((dataFromBuffAI[i][channel] + 5) * height) / 10));//从负到正                                                                                                                   //prData[channelIndex][i] = new Point(i, (int)(((Math.Abs(showData[i][channelIndex])) * height) / 10));//全负数
                }

                pbTemp.Refresh();
            }
        }

        private void ClearBufferedAICurve()
        {
            Graphics g = Graphics.FromImage(this.pbBuffCh1.Image);
            g.Clear(this.pbBuffCh1.BackColor);

            //DrawGrid(this.pbBuffCh1);
            //DrawGrid(this.pbBuffCh2);
            //DrawGrid(this.pbBuffCh3);
            //DrawGrid(this.pbBuffCh4);
        }

        private void DrawInstantAICurve()
        {
            for (int channel = 0; channel < 4; channel++)
            {
                PictureBox pbTemp = null;
                switch (channel)
                {
                    case 0:
                        pbTemp = this.pbIstantCh1; break;
                    case 1:
                        pbTemp = this.pbIstantCh2; break;
                    case 2:
                        pbTemp = this.pbIstantCh3; break;
                    case 3:
                        pbTemp = this.pbIstantCh4; break;
                }

                int width = pbTemp.Width, height = pbTemp.Height;

                if (pointFromInstantAI.Count == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        pointFromInstantAI.Add(new Point[width]);
                    }
                }
                lock (locker)
                {
                    while (dataFromInstantAI.Count >= width + 2)
                    {
                        dataFromInstantAI.RemoveAt(0);
                    }
                }

                int count = dataFromInstantAI.Count;

                if (count != 0)
                {
                    pointFromInstantAI[channel] = new Point[count];
                }

                for (int i = 0; i < width + 1; i++)
                {
                    if (i >= count) break;

                    if (dataFromInstantAI[i] == null) continue;

                    pointFromInstantAI[channel][i] = new Point(i, (int)(height - ((dataFromInstantAI[i][channel] + 5) * height) / 10));//从负到正                                                                                                                   //prData[channelIndex][i] = new Point(i, (int)(((Math.Abs(showData[i][channelIndex])) * height) / 10));//全负数
                }

                pbTemp.Refresh();
            }
        }

        private List<int> data = new List<int>();

        private Pen redPen = new Pen(Color.Red, 1);
        private void pBCh_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            string pbName = pb.Name;

            if (pbName.Contains("pbBuffCh"))
            {
                if (pointFromBuffAI.Count == 4)
                {
                    switch (pbName)
                    {
                        case "pbBuffCh1":
                            if (pointFromBuffAI[0].Count() < 3) break;//画曲线至少需要三个点
                            e.Graphics.DrawCurve(redPen, pointFromBuffAI[0]); break;
                        case "pbBuffCh2":
                            if (pointFromBuffAI[1].Count() < 3) break;
                            e.Graphics.DrawCurve(redPen, pointFromBuffAI[1]); break;
                        case "pbBuffCh3":
                            if (pointFromBuffAI[2].Count() < 3) break;
                            e.Graphics.DrawCurve(redPen, pointFromBuffAI[2]); break;
                        case "pbBuffCh4":
                            if (pointFromBuffAI[3].Count() < 3) break;
                            e.Graphics.DrawCurve(redPen, pointFromBuffAI[3]); break;
                    }
                }
            }
            else if (pbName.Contains("pbIstantCh"))
            {
                if (pointFromInstantAI.Count == 4)
                {
                    switch (pbName)
                    {
                        case "pbIstantCh1":
                            if (pointFromInstantAI[0].Count() < 3) break;//画曲线至少需要三个点
                            e.Graphics.DrawCurve(redPen, pointFromInstantAI[0]); break;
                        case "pbIstantCh2":
                            if (pointFromInstantAI[1].Count() < 3) break;
                            e.Graphics.DrawCurve(redPen, pointFromInstantAI[1]); break;
                        case "pbIstantCh3":
                            if (pointFromInstantAI[2].Count() < 3) break;
                            e.Graphics.DrawCurve(redPen, pointFromInstantAI[2]); break;
                        case "pbIstantCh4":
                            if (pointFromInstantAI[3].Count() < 3) break;
                            e.Graphics.DrawCurve(redPen, pointFromInstantAI[3]); break;
                    }
                }
            }


        }
        #endregion

        #region 界面按钮控制
        private void OperateCustomBtn(bool b)
        {
            this.btnCustomBufferedAI.Enabled = b;
            this.btnCustomInstantAI.Enabled = b;
        }

        private void OperateCtrBtn(bool b)
        {
            this.btnControlInstantAI.Enabled = b;
            this.btnControlBufferedAI.Enabled = b;
        }
        #endregion

        #region 自定义BufferedAI
        PCI1714UL objPCI1714 = null;
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                objPCI1714 = new PCI1714UL(deviceName);
                
                OperateCustomBtn(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }

        private void btnStartRead_Click(object sender, EventArgs e)
        {
            try
            {
                //ClearBufferedAICurve();

                objPCI1714.StartBufferedAI(4, ChannelDataAction);
                OperateCtrBtn(false);
                OperateCustomBtn(false);

                bufferedAITimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStopCusBuffAI_Click(object sender, EventArgs e)
        {
            try
            {                
                //if (objPCI1714 != null)
                //{
                //    objPCI1714.StopBufferedAI();
                //    //objPCI1714 = null;
                //    bufferedAITimer.Stop();

                //    OperateCustomBtn(true);
                //    OperateCtrBtn(true);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChannelDataAction(ushort[][] us)//动作方法：接受与处理数据，并交给数据展示列表
        {
            this.us = us;

            if (us == null || us[0] == null) return;

            dataFromBuffAI.Add(this.us.Select(u1 =>
            {
                return GetVoltage(u1.Select(u => (double)u).ToList().Average());
            }).ToArray());
        }

        private double GetVoltage(double data)
        {
            return data * 10 / 4095 - 5.0190516943459;
        }


        private void customBufferedAI_Tick(object sender, EventArgs e)
        {
            DrawBufferedAICurve();
        }
        #endregion

        #region 自定义InstantAI
        private void btnCustomInstantAI_Click(object sender, EventArgs e)
        {
            try
            {
                customInstantAI.Start();

                OperateCustomBtn(false);
                OperateCtrBtn(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnStopCusInstantAI_Click(object sender, EventArgs e)
        {
            try
            {
                //if (objPCI1714 != null)
                //{
                //    objPCI1714.StopInstantAI();
                //    objPCI1714 = null;
                //    customInstantAI.Stop();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void customInstantAI_Tick(object sender, EventArgs e)
        {
            dataFromInstantAI.Add(objPCI1714.StartInstantAI());

            DrawInstantAICurve();
        }
        #endregion

        #region 控件BufferedAI
        //private double[] d;
        private void btnControlBufferedAI_Click(object sender, EventArgs e)
        {
            try
            {
                waveformAiCtrl1.SelectedDevice = new DeviceInformation(deviceName);
                if (!waveformAiCtrl1.Initialized)
                {
                    MessageBox.Show("No device be selected or device open failed!");
                    return;
                }

                int channelCount = waveformAiCtrl1.Conversion.ChannelCount;
                int sectionLength = waveformAiCtrl1.Record.SectionLength;

                //d = new double[channelCount*sectionLength];

                waveformAiCtrl1.Prepare();
                ErrorCode er=ErrorCode.Success;
                if (waveformAiCtrl1.State != ControlState.Running)
                {
                    er = waveformAiCtrl1.Start();
                }
                 
                if (er != ErrorCode.Success)
                {
                    MessageBox.Show("设备打开失败！");
                    return;
                }

                OperateCtrBtn(false);
                OperateCustomBtn(false);

                bufferedAITimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnStopCtrBuffAI_Click(object sender, EventArgs e)
        {
            //if (waveformAiCtrl1.State == ControlState.Idle)
            //{
            //    return;//has been disposed
            //}
            //waveformAiCtrl1.Stop();
            //waveformAiCtrl1.Dispose();
        }

        private object locker = new object();
        private void waveformAiCtrl1_DataReady(object sender, BfdAiEventArgs e)
        {
            double[] data = new double[e.Count];
            ErrorCode er = waveformAiCtrl1.GetData(e.Count, data);
            if (er != ErrorCode.Success)
            {
                return;
            }

            lock (locker)
            {
                for (int i = 0; i < data.Length; i += 4)
                {
                    double[] temp = new double[4];
                    for (int j = 0; j < 4; j++)
                    {
                        temp[j] = data[i + j];
                    }
                    dataFromBuffAI.Add(temp);
                }
            }
        }
        #endregion

        #region 控件InstantAI

        private void btnControlInstantAI_Click(object sender, EventArgs e)
        {
            try
            {
                instantAiCtrl1.SelectedDevice = new DeviceInformation(deviceName);
                if (!instantAiCtrl1.Initialized)
                {
                    MessageBox.Show("No device be selected or device open failed!");
                    return;
                }

                OperateCtrBtn(false);
                OperateCustomBtn(false);

                ctrInstant.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void btnStopCtrInstantAI_Click(object sender, EventArgs e)
        {
            try
            {
                //ctrInstant.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
        }

        private void ctrInstant_Tick(object sender, EventArgs e)
        {
            double[] data = new double[4]; ;
            ErrorCode er0 = instantAiCtrl1.Read(0, out data[0]);
            ErrorCode er1 = instantAiCtrl1.Read(1, out data[1]);
            ErrorCode er2 = instantAiCtrl1.Read(2, out data[2]);
            ErrorCode er3 = instantAiCtrl1.Read(3, out data[3]);

            dataFromInstantAI.Add(data);

            DrawInstantAICurve();           
        }
        #endregion              
    }
}
