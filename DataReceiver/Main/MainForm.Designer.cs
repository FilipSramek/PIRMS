namespace Project
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            timerZeroPointOneHz = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            btnSetConfig = new Button();
            label3 = new Label();
            cmbBoxPort = new ComboBox();
            cmbBoxBoud = new ComboBox();
            listView2 = new ListView();
            txtDebug = new TextBox();
            SuspendLayout();
            // 
            // timerZeroPointOneHz
            // 
            timerZeroPointOneHz.Enabled = true;
            timerZeroPointOneHz.Tick += timerZeroPointOneHz_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(153, 12);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 0;
            label1.Text = "Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(153, 44);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 1;
            label2.Text = "Bould Rate";
            // 
            // btnSetConfig
            // 
            btnSetConfig.Location = new Point(12, 70);
            btnSetConfig.Name = "btnSetConfig";
            btnSetConfig.Size = new Size(135, 23);
            btnSetConfig.TabIndex = 4;
            btnSetConfig.Text = "Set port config";
            btnSetConfig.UseVisualStyleBackColor = true;
            btnSetConfig.Click += btnSetConfig_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(257, 12);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 5;
            label3.Text = "Debug";
            label3.Click += label3_Click;
            // 
            // cmbBoxPort
            // 
            cmbBoxPort.FormattingEnabled = true;
            cmbBoxPort.Items.AddRange(new object[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13", "COM14", "COM15" });
            cmbBoxPort.Location = new Point(12, 9);
            cmbBoxPort.Name = "cmbBoxPort";
            cmbBoxPort.Size = new Size(135, 23);
            cmbBoxPort.TabIndex = 7;
            cmbBoxPort.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // cmbBoxBoud
            // 
            cmbBoxBoud.FormattingEnabled = true;
            cmbBoxBoud.Items.AddRange(new object[] { "9600" });
            cmbBoxBoud.Location = new Point(12, 38);
            cmbBoxBoud.Name = "cmbBoxBoud";
            cmbBoxBoud.Size = new Size(135, 23);
            cmbBoxBoud.TabIndex = 8;
            // 
            // listView2
            // 
            listView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listView2.Location = new Point(12, 99);
            listView2.Name = "listView2";
            listView2.Size = new Size(346, 410);
            listView2.TabIndex = 10;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            // 
            // txtDebug
            // 
            txtDebug.Location = new Point(364, 486);
            txtDebug.Name = "txtDebug";
            txtDebug.Size = new Size(736, 23);
            txtDebug.TabIndex = 11;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 521);
            Controls.Add(txtDebug);
            Controls.Add(listView2);
            Controls.Add(cmbBoxBoud);
            Controls.Add(cmbBoxPort);
            Controls.Add(label3);
            Controls.Add(btnSetConfig);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timerZeroPointOneHz;
        private Label label1;
        private Label label2;
        private Button btnSetConfig;
        private Label label3;
        private ComboBox cmbBoxPort;
        private ComboBox cmbBoxBoud;
        private ListView listView2;
        private TextBox txtDebug;
    }
}
