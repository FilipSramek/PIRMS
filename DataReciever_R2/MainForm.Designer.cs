namespace DataReciever
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer100 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chrtFreqSpacePhase = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnConnect = new System.Windows.Forms.Button();
            this.timer1000 = new System.Windows.Forms.Timer(this.components);
            this.chrtFreqSpaceMag = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chrtTimeSpace = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chrtFreqSpacePhase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtFreqSpaceMag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtTimeSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // timer100
            // 
            this.timer100.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud rate";
            // 
            // txtDebug
            // 
            this.txtDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebug.Location = new System.Drawing.Point(14, 139);
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.Size = new System.Drawing.Size(455, 20);
            this.txtDebug.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1473, 898);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Debug";
            // 
            // chrtFreqSpacePhase
            // 
            this.chrtFreqSpacePhase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chrtFreqSpacePhase.CausesValidation = false;
            chartArea1.Name = "ChartArea1";
            this.chrtFreqSpacePhase.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chrtFreqSpacePhase.Legends.Add(legend1);
            this.chrtFreqSpacePhase.Location = new System.Drawing.Point(12, 531);
            this.chrtFreqSpacePhase.Name = "chrtFreqSpacePhase";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.chrtFreqSpacePhase.Series.Add(series1);
            this.chrtFreqSpacePhase.Size = new System.Drawing.Size(1060, 118);
            this.chrtFreqSpacePhase.TabIndex = 7;
            this.chrtFreqSpacePhase.Text = "chart2";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(14, 65);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(149, 56);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // timer1000
            // 
            this.timer1000.Interval = 5000;
            this.timer1000.Tick += new System.EventHandler(this.timer1000_Tick);
            // 
            // chrtFreqSpaceMag
            // 
            this.chrtFreqSpaceMag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chrtFreqSpaceMag.CausesValidation = false;
            chartArea2.Name = "ChartArea1";
            this.chrtFreqSpaceMag.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chrtFreqSpaceMag.Legends.Add(legend2);
            this.chrtFreqSpaceMag.Location = new System.Drawing.Point(14, 369);
            this.chrtFreqSpaceMag.Name = "chrtFreqSpaceMag";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            this.chrtFreqSpaceMag.Series.Add(series2);
            this.chrtFreqSpaceMag.Size = new System.Drawing.Size(1058, 131);
            this.chrtFreqSpaceMag.TabIndex = 9;
            this.chrtFreqSpaceMag.Text = "chart2";
            // 
            // chrtTimeSpace
            // 
            this.chrtTimeSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chrtTimeSpace.CausesValidation = false;
            chartArea3.Name = "ChartArea1";
            this.chrtTimeSpace.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chrtTimeSpace.Legends.Add(legend3);
            this.chrtTimeSpace.Location = new System.Drawing.Point(500, 49);
            this.chrtTimeSpace.Name = "chrtTimeSpace";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.YValuesPerPoint = 4;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chrtTimeSpace.Series.Add(series3);
            this.chrtTimeSpace.Size = new System.Drawing.Size(572, 227);
            this.chrtTimeSpace.TabIndex = 10;
            this.chrtTimeSpace.Text = "chart2";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(505, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Magnitudové spektrum";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(515, 503);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Fázové spektrum";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(683, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Časová doména";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(81, 4);
            this.cmbPort.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(82, 21);
            this.cmbPort.TabIndex = 16;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(81, 35);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(82, 21);
            this.cmbBaudRate.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1084, 677);
            this.Controls.Add(this.cmbBaudRate);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chrtTimeSpace);
            this.Controls.Add(this.chrtFreqSpaceMag);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.chrtFreqSpacePhase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chrtFreqSpacePhase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtFreqSpaceMag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtTimeSpace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer100;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtFreqSpacePhase;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Timer timer1000;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtFreqSpaceMag;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtTimeSpace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.ComboBox cmbBaudRate;
    }
}

