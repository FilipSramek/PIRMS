namespace DataMaker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxPort = new ComboBox();
            comboBoxBaud = new ComboBox();
            btnStartSending = new Button();
            label1 = new Label();
            label2 = new Label();
            btnLoadCsv = new Button();
            openFileDialog1 = new OpenFileDialog();
            buttonInitSerial = new Button();
            SuspendLayout();
            // 
            // comboBoxPort
            // 
            comboBoxPort.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPort.FormattingEnabled = true;
            comboBoxPort.Location = new Point(138, 39);
            comboBoxPort.Name = "comboBoxPort";
            comboBoxPort.Size = new Size(182, 33);
            comboBoxPort.TabIndex = 0;
            // 
            // comboBoxBaud
            // 
            comboBoxBaud.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBaud.FormattingEnabled = true;
            comboBoxBaud.Location = new Point(138, 95);
            comboBoxBaud.Name = "comboBoxBaud";
            comboBoxBaud.Size = new Size(182, 33);
            comboBoxBaud.TabIndex = 1;
            // 
            // btnStartSending
            // 
            btnStartSending.Location = new Point(174, 160);
            btnStartSending.Name = "btnStartSending";
            btnStartSending.Size = new Size(114, 73);
            btnStartSending.TabIndex = 2;
            btnStartSending.Text = "Start";
            btnStartSending.UseVisualStyleBackColor = true;
            btnStartSending.Click += btnStartSending_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 47);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 3;
            label1.Text = "Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 103);
            label2.Name = "label2";
            label2.Size = new Size(52, 25);
            label2.TabIndex = 4;
            label2.Text = "Baud";
            // 
            // btnLoadCsv
            // 
            btnLoadCsv.Location = new Point(51, 158);
            btnLoadCsv.Name = "btnLoadCsv";
            btnLoadCsv.Size = new Size(117, 75);
            btnLoadCsv.TabIndex = 6;
            btnLoadCsv.Text = "načtení dat";
            btnLoadCsv.UseVisualStyleBackColor = true;
            btnLoadCsv.Click += btnLoadCsv_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonInitSerial
            // 
            buttonInitSerial.Location = new Point(294, 160);
            buttonInitSerial.Name = "buttonInitSerial";
            buttonInitSerial.Size = new Size(172, 73);
            buttonInitSerial.TabIndex = 7;
            buttonInitSerial.Text = "Inicializovat port";
            buttonInitSerial.UseVisualStyleBackColor = true;
            buttonInitSerial.Click += buttonInitSerial_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(buttonInitSerial);
            Controls.Add(btnLoadCsv);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnStartSending);
            Controls.Add(comboBoxBaud);
            Controls.Add(comboBoxPort);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBoxPort;
        private ComboBox comboBoxBaud;
        private Button btnStartSending;
        private Label label1;
        private Label label2;
        private Button btnLoadCsv;
        private OpenFileDialog openFileDialog1;
        private Button buttonInitSerial;
    }
}
