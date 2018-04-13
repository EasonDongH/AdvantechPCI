namespace AdvantechPCIDemo
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.bufferedAITimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.选择设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPCI1714UL = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnStopCtrBuffAI = new System.Windows.Forms.Button();
            this.btnStopCusBuffAI = new System.Windows.Forms.Button();
            this.btnControlBufferedAI = new System.Windows.Forms.Button();
            this.btnCustomBufferedAI = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pbBuffCh4 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbBuffCh3 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbBuffCh2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbBuffCh1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnStopCtrInstantAI = new System.Windows.Forms.Button();
            this.btnStopCusInstantAI = new System.Windows.Forms.Button();
            this.btnCustomInstantAI = new System.Windows.Forms.Button();
            this.btnControlInstantAI = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pbIstantCh4 = new System.Windows.Forms.PictureBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pbIstantCh3 = new System.Windows.Forms.PictureBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.pbIstantCh1 = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.pbIstantCh2 = new System.Windows.Forms.PictureBox();
            this.ctrInstant = new System.Windows.Forms.Timer(this.components);
            this.instantAiCtrl1 = new Automation.BDaq.InstantAiCtrl(this.components);
            this.waveformAiCtrl1 = new Automation.BDaq.WaveformAiCtrl(this.components);
            this.customInstantAI = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuffCh4)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuffCh3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuffCh2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuffCh1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIstantCh4)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIstantCh3)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIstantCh1)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIstantCh2)).BeginInit();
            this.SuspendLayout();
            // 
            // bufferedAITimer
            // 
            this.bufferedAITimer.Tick += new System.EventHandler(this.customBufferedAI_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择设备ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(986, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 选择设备ToolStripMenuItem
            // 
            this.选择设备ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPCI1714UL});
            this.选择设备ToolStripMenuItem.Name = "选择设备ToolStripMenuItem";
            this.选择设备ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.选择设备ToolStripMenuItem.Text = "选择设备";
            // 
            // btnPCI1714UL
            // 
            this.btnPCI1714UL.Name = "btnPCI1714UL";
            this.btnPCI1714UL.Size = new System.Drawing.Size(143, 22);
            this.btnPCI1714UL.Text = "PCI-1714UL";
            this.btnPCI1714UL.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(962, 525);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnStopCtrBuffAI);
            this.tabPage1.Controls.Add(this.btnStopCusBuffAI);
            this.tabPage1.Controls.Add(this.btnControlBufferedAI);
            this.tabPage1.Controls.Add(this.btnCustomBufferedAI);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(954, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Buffered AI";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnStopCtrBuffAI
            // 
            this.btnStopCtrBuffAI.Location = new System.Drawing.Point(850, 123);
            this.btnStopCtrBuffAI.Name = "btnStopCtrBuffAI";
            this.btnStopCtrBuffAI.Size = new System.Drawing.Size(90, 25);
            this.btnStopCtrBuffAI.TabIndex = 17;
            this.btnStopCtrBuffAI.Text = "停止控件读取";
            this.btnStopCtrBuffAI.UseVisualStyleBackColor = true;
            this.btnStopCtrBuffAI.Click += new System.EventHandler(this.btnStopCtrBuffAI_Click);
            // 
            // btnStopCusBuffAI
            // 
            this.btnStopCusBuffAI.Location = new System.Drawing.Point(850, 63);
            this.btnStopCusBuffAI.Name = "btnStopCusBuffAI";
            this.btnStopCusBuffAI.Size = new System.Drawing.Size(90, 23);
            this.btnStopCusBuffAI.TabIndex = 16;
            this.btnStopCusBuffAI.Text = "停止自定义读取";
            this.btnStopCusBuffAI.UseVisualStyleBackColor = true;
            this.btnStopCusBuffAI.Click += new System.EventHandler(this.btnStopCusBuffAI_Click);
            // 
            // btnControlBufferedAI
            // 
            this.btnControlBufferedAI.Location = new System.Drawing.Point(850, 92);
            this.btnControlBufferedAI.Name = "btnControlBufferedAI";
            this.btnControlBufferedAI.Size = new System.Drawing.Size(90, 25);
            this.btnControlBufferedAI.TabIndex = 15;
            this.btnControlBufferedAI.Text = "控件读取";
            this.btnControlBufferedAI.UseVisualStyleBackColor = true;
            this.btnControlBufferedAI.Click += new System.EventHandler(this.btnControlBufferedAI_Click);
            // 
            // btnCustomBufferedAI
            // 
            this.btnCustomBufferedAI.Location = new System.Drawing.Point(850, 34);
            this.btnCustomBufferedAI.Name = "btnCustomBufferedAI";
            this.btnCustomBufferedAI.Size = new System.Drawing.Size(90, 23);
            this.btnCustomBufferedAI.TabIndex = 13;
            this.btnCustomBufferedAI.Text = "自定义读取";
            this.btnCustomBufferedAI.UseVisualStyleBackColor = true;
            this.btnCustomBufferedAI.Click += new System.EventHandler(this.btnStartRead_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pbBuffCh4);
            this.groupBox4.Location = new System.Drawing.Point(7, 383);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(795, 111);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "通道4";
            // 
            // pbBuffCh4
            // 
            this.pbBuffCh4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbBuffCh4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBuffCh4.Location = new System.Drawing.Point(2, 16);
            this.pbBuffCh4.Name = "pbBuffCh4";
            this.pbBuffCh4.Size = new System.Drawing.Size(791, 93);
            this.pbBuffCh4.TabIndex = 1;
            this.pbBuffCh4.TabStop = false;
            this.pbBuffCh4.Paint += new System.Windows.Forms.PaintEventHandler(this.pBCh_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbBuffCh3);
            this.groupBox3.Location = new System.Drawing.Point(5, 266);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(797, 113);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "通道3";
            // 
            // pbBuffCh3
            // 
            this.pbBuffCh3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbBuffCh3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBuffCh3.Location = new System.Drawing.Point(2, 16);
            this.pbBuffCh3.Name = "pbBuffCh3";
            this.pbBuffCh3.Size = new System.Drawing.Size(793, 95);
            this.pbBuffCh3.TabIndex = 1;
            this.pbBuffCh3.TabStop = false;
            this.pbBuffCh3.Paint += new System.Windows.Forms.PaintEventHandler(this.pBCh_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbBuffCh2);
            this.groupBox2.Location = new System.Drawing.Point(5, 132);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(797, 130);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通道2";
            // 
            // pbBuffCh2
            // 
            this.pbBuffCh2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbBuffCh2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBuffCh2.Location = new System.Drawing.Point(2, 16);
            this.pbBuffCh2.Name = "pbBuffCh2";
            this.pbBuffCh2.Size = new System.Drawing.Size(793, 112);
            this.pbBuffCh2.TabIndex = 1;
            this.pbBuffCh2.TabStop = false;
            this.pbBuffCh2.Paint += new System.Windows.Forms.PaintEventHandler(this.pBCh_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbBuffCh1);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(799, 123);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通道1";
            // 
            // pbBuffCh1
            // 
            this.pbBuffCh1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbBuffCh1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBuffCh1.Location = new System.Drawing.Point(2, 16);
            this.pbBuffCh1.Name = "pbBuffCh1";
            this.pbBuffCh1.Size = new System.Drawing.Size(795, 105);
            this.pbBuffCh1.TabIndex = 0;
            this.pbBuffCh1.TabStop = false;
            this.pbBuffCh1.Paint += new System.Windows.Forms.PaintEventHandler(this.pBCh_Paint);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnStopCtrInstantAI);
            this.tabPage2.Controls.Add(this.btnStopCusInstantAI);
            this.tabPage2.Controls.Add(this.btnCustomInstantAI);
            this.tabPage2.Controls.Add(this.btnControlInstantAI);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(954, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Instand AI";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnStopCtrInstantAI
            // 
            this.btnStopCtrInstantAI.Location = new System.Drawing.Point(840, 108);
            this.btnStopCtrInstantAI.Name = "btnStopCtrInstantAI";
            this.btnStopCtrInstantAI.Size = new System.Drawing.Size(90, 23);
            this.btnStopCtrInstantAI.TabIndex = 22;
            this.btnStopCtrInstantAI.Text = "停止控件读取";
            this.btnStopCtrInstantAI.UseVisualStyleBackColor = true;
            this.btnStopCtrInstantAI.Click += new System.EventHandler(this.btnStopCtrInstantAI_Click);
            // 
            // btnStopCusInstantAI
            // 
            this.btnStopCusInstantAI.Location = new System.Drawing.Point(840, 50);
            this.btnStopCusInstantAI.Name = "btnStopCusInstantAI";
            this.btnStopCusInstantAI.Size = new System.Drawing.Size(90, 23);
            this.btnStopCusInstantAI.TabIndex = 21;
            this.btnStopCusInstantAI.Text = "停止自定义读取";
            this.btnStopCusInstantAI.UseVisualStyleBackColor = true;
            this.btnStopCusInstantAI.Click += new System.EventHandler(this.btnStopCusInstantAI_Click);
            // 
            // btnCustomInstantAI
            // 
            this.btnCustomInstantAI.Location = new System.Drawing.Point(840, 21);
            this.btnCustomInstantAI.Name = "btnCustomInstantAI";
            this.btnCustomInstantAI.Size = new System.Drawing.Size(90, 23);
            this.btnCustomInstantAI.TabIndex = 20;
            this.btnCustomInstantAI.Text = "自定义读取";
            this.btnCustomInstantAI.UseVisualStyleBackColor = true;
            this.btnCustomInstantAI.Click += new System.EventHandler(this.btnCustomInstantAI_Click);
            // 
            // btnControlInstantAI
            // 
            this.btnControlInstantAI.Location = new System.Drawing.Point(840, 79);
            this.btnControlInstantAI.Name = "btnControlInstantAI";
            this.btnControlInstantAI.Size = new System.Drawing.Size(90, 23);
            this.btnControlInstantAI.TabIndex = 19;
            this.btnControlInstantAI.Text = "控件读取";
            this.btnControlInstantAI.UseVisualStyleBackColor = true;
            this.btnControlInstantAI.Click += new System.EventHandler(this.btnControlInstantAI_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pbIstantCh4);
            this.groupBox5.Location = new System.Drawing.Point(7, 383);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(795, 111);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "通道4";
            // 
            // pbIstantCh4
            // 
            this.pbIstantCh4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbIstantCh4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIstantCh4.Location = new System.Drawing.Point(2, 16);
            this.pbIstantCh4.Name = "pbIstantCh4";
            this.pbIstantCh4.Size = new System.Drawing.Size(791, 93);
            this.pbIstantCh4.TabIndex = 1;
            this.pbIstantCh4.TabStop = false;
            this.pbIstantCh4.Paint += new System.Windows.Forms.PaintEventHandler(this.pBCh_Paint);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pbIstantCh3);
            this.groupBox6.Location = new System.Drawing.Point(5, 266);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(797, 113);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "通道3";
            // 
            // pbIstantCh3
            // 
            this.pbIstantCh3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbIstantCh3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIstantCh3.Location = new System.Drawing.Point(2, 16);
            this.pbIstantCh3.Name = "pbIstantCh3";
            this.pbIstantCh3.Size = new System.Drawing.Size(793, 95);
            this.pbIstantCh3.TabIndex = 1;
            this.pbIstantCh3.TabStop = false;
            this.pbIstantCh3.Paint += new System.Windows.Forms.PaintEventHandler(this.pBCh_Paint);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.pbIstantCh1);
            this.groupBox8.Location = new System.Drawing.Point(5, 5);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(799, 123);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "通道1";
            // 
            // pbIstantCh1
            // 
            this.pbIstantCh1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbIstantCh1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIstantCh1.Location = new System.Drawing.Point(2, 16);
            this.pbIstantCh1.Name = "pbIstantCh1";
            this.pbIstantCh1.Size = new System.Drawing.Size(795, 105);
            this.pbIstantCh1.TabIndex = 0;
            this.pbIstantCh1.TabStop = false;
            this.pbIstantCh1.Paint += new System.Windows.Forms.PaintEventHandler(this.pBCh_Paint);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.pbIstantCh2);
            this.groupBox7.Location = new System.Drawing.Point(5, 132);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(797, 130);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "通道2";
            // 
            // pbIstantCh2
            // 
            this.pbIstantCh2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbIstantCh2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIstantCh2.Location = new System.Drawing.Point(2, 16);
            this.pbIstantCh2.Name = "pbIstantCh2";
            this.pbIstantCh2.Size = new System.Drawing.Size(793, 112);
            this.pbIstantCh2.TabIndex = 1;
            this.pbIstantCh2.TabStop = false;
            this.pbIstantCh2.Paint += new System.Windows.Forms.PaintEventHandler(this.pBCh_Paint);
            // 
            // ctrInstant
            // 
            this.ctrInstant.Tick += new System.EventHandler(this.ctrInstant_Tick);
            // 
            // instantAiCtrl1
            // 
            this.instantAiCtrl1._StateStream = ((Automation.BDaq.DeviceStateStreamer)(resources.GetObject("instantAiCtrl1._StateStream")));
            // 
            // waveformAiCtrl1
            // 
            this.waveformAiCtrl1._StateStream = ((Automation.BDaq.DeviceStateStreamer)(resources.GetObject("waveformAiCtrl1._StateStream")));
            this.waveformAiCtrl1.DataReady += new System.EventHandler<Automation.BDaq.BfdAiEventArgs>(this.waveformAiCtrl1_DataReady);
            // 
            // customInstantAI
            // 
            this.customInstantAI.Tick += new System.EventHandler(this.customInstantAI_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 559);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBuffCh4)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBuffCh3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBuffCh2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBuffCh1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIstantCh4)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIstantCh3)).EndInit();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIstantCh1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIstantCh2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer bufferedAITimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选择设备ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pbBuffCh4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pbBuffCh3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbBuffCh2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbBuffCh1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem btnPCI1714UL;
        private System.Windows.Forms.Button btnCustomBufferedAI;
        private System.Windows.Forms.Timer ctrInstant;
        private Automation.BDaq.InstantAiCtrl instantAiCtrl1;
        private Automation.BDaq.WaveformAiCtrl waveformAiCtrl1;
        private System.Windows.Forms.Button btnControlBufferedAI;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pbIstantCh4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PictureBox pbIstantCh3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.PictureBox pbIstantCh1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.PictureBox pbIstantCh2;
        private System.Windows.Forms.Button btnControlInstantAI;
        private System.Windows.Forms.Button btnCustomInstantAI;
        private System.Windows.Forms.Timer customInstantAI;
        private System.Windows.Forms.Button btnStopCusInstantAI;
        private System.Windows.Forms.Button btnStopCusBuffAI;
        private System.Windows.Forms.Button btnStopCtrInstantAI;
        private System.Windows.Forms.Button btnStopCtrBuffAI;
    }
}

