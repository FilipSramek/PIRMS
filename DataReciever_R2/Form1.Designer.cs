namespace DataReciever
{
    partial class Form1
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
            this.chrtTimeSpace = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer100 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBould = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chrtFreqSpace = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnConnect = new System.Windows.Forms.Button();
            this.timer1000 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chrtTimeSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtFreqSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // chrtTimeSpace
            // 
            chartArea1.Name = "ChartArea1";
            this.chrtTimeSpace.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtTimeSpace.Legends.Add(legend1);
            this.chrtTimeSpace.Location = new System.Drawing.Point(12, 369);
            this.chrtTimeSpace.Name = "chrtTimeSpace";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrtTimeSpace.Series.Add(series1);
            this.chrtTimeSpace.Size = new System.Drawing.Size(716, 520);
            this.chrtTimeSpace.TabIndex = 0;
            this.chrtTimeSpace.Text = "chart1";
            // 
            // timer100
            // 
            this.timer100.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bould rate";
            // 
            // txtBould
            // 
            this.txtBould.Location = new System.Drawing.Point(13, 39);
            this.txtBould.Name = "txtBould";
            this.txtBould.Size = new System.Drawing.Size(100, 20);
            this.txtBould.TabIndex = 3;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(12, 13);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 4;
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(12, 895);
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.Size = new System.Drawing.Size(1375, 20);
            this.txtDebug.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1393, 898);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Debug";
            // 
            // chrtFreqSpace
            // 
            chartArea2.Name = "ChartArea1";
            this.chrtFreqSpace.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrtFreqSpace.Legends.Add(legend2);
            this.chrtFreqSpace.Location = new System.Drawing.Point(746, 369);
            this.chrtFreqSpace.Name = "chrtFreqSpace";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chrtFreqSpace.Series.Add(series2);
            this.chrtFreqSpace.Size = new System.Drawing.Size(686, 520);
            this.chrtFreqSpace.TabIndex = 7;
            this.chrtFreqSpace.Text = "chart2";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(13, 65);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(161, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // timer1000
            // 
            this.timer1000.Interval = 1000;
            this.timer1000.Tick += new System.EventHandler(this.timer1000_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 924);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.chrtFreqSpace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtBould);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chrtTimeSpace);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chrtTimeSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtFreqSpace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrtTimeSpace;
        private System.Windows.Forms.Timer timer100;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBould;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtFreqSpace;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Timer timer1000;
    }
}

