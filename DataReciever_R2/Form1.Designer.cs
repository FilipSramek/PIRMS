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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer100 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBould = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.chrtFreqSpacePhase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtFreqSpaceMag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtTimeSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // timer100
            // 
            this.timer100.Enabled = true;
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
            this.txtDebug.Size = new System.Drawing.Size(1455, 20);
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
            this.chrtFreqSpacePhase.CausesValidation = false;
            chartArea4.Name = "ChartArea1";
            this.chrtFreqSpacePhase.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chrtFreqSpacePhase.Legends.Add(legend4);
            this.chrtFreqSpacePhase.Location = new System.Drawing.Point(12, 744);
            this.chrtFreqSpacePhase.Name = "chrtFreqSpacePhase";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            series4.YValuesPerPoint = 4;
            this.chrtFreqSpacePhase.Series.Add(series4);
            this.chrtFreqSpacePhase.Size = new System.Drawing.Size(1500, 145);
            this.chrtFreqSpacePhase.TabIndex = 7;
            this.chrtFreqSpacePhase.Text = "chart2";
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
            this.timer1000.Enabled = true;
            this.timer1000.Interval = 1000;
            this.timer1000.Tick += new System.EventHandler(this.timer1000_Tick);
            // 
            // chrtFreqSpaceMag
            // 
            this.chrtFreqSpaceMag.CausesValidation = false;
            chartArea5.Name = "ChartArea1";
            this.chrtFreqSpaceMag.ChartAreas.Add(chartArea5);
            legend5.Enabled = false;
            legend5.Name = "Legend1";
            this.chrtFreqSpaceMag.Legends.Add(legend5);
            this.chrtFreqSpaceMag.Location = new System.Drawing.Point(12, 593);
            this.chrtFreqSpaceMag.Name = "chrtFreqSpaceMag";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            series5.YValuesPerPoint = 4;
            this.chrtFreqSpaceMag.Series.Add(series5);
            this.chrtFreqSpaceMag.Size = new System.Drawing.Size(1500, 145);
            this.chrtFreqSpaceMag.TabIndex = 9;
            this.chrtFreqSpaceMag.Text = "chart2";
            // 
            // chrtTimeSpace
            // 
            this.chrtTimeSpace.CausesValidation = false;
            chartArea6.Name = "ChartArea1";
            this.chrtTimeSpace.ChartAreas.Add(chartArea6);
            legend6.Enabled = false;
            legend6.Name = "Legend1";
            this.chrtTimeSpace.Legends.Add(legend6);
            this.chrtTimeSpace.Location = new System.Drawing.Point(915, 37);
            this.chrtTimeSpace.Name = "chrtTimeSpace";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.IsVisibleInLegend = false;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            series6.YValuesPerPoint = 4;
            this.chrtTimeSpace.Series.Add(series6);
            this.chrtTimeSpace.Size = new System.Drawing.Size(597, 248);
            this.chrtTimeSpace.TabIndex = 10;
            this.chrtTimeSpace.Text = "chart2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(726, 580);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Magnitudové spektrum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(754, 729);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Fázové spektrum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(1128, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Časová doména";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1524, 924);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chrtTimeSpace);
            this.Controls.Add(this.chrtFreqSpaceMag);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.chrtFreqSpacePhase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtBould);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.TextBox txtBould;
        private System.Windows.Forms.TextBox txtPort;
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
    }
}

