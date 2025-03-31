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
            txtPort = new TextBox();
            txtBoud = new TextBox();
            btnSetConfig = new Button();
            label3 = new Label();
            txtSetConfig = new TextBox();
            SuspendLayout();
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
            // txtPort
            // 
            txtPort.Location = new Point(12, 12);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(135, 23);
            txtPort.TabIndex = 2;
            txtPort.Text = "COM1";
            // 
            // txtBoud
            // 
            txtBoud.Location = new Point(12, 41);
            txtBoud.Name = "txtBoud";
            txtBoud.Size = new Size(135, 23);
            txtBoud.TabIndex = 3;
            txtBoud.Text = "9600";
            // 
            // btnSetConfig
            // 
            btnSetConfig.Location = new Point(12, 70);
            btnSetConfig.Name = "btnSetConfig";
            btnSetConfig.Size = new Size(185, 23);
            btnSetConfig.TabIndex = 4;
            btnSetConfig.Text = "Set port config";
            btnSetConfig.UseVisualStyleBackColor = true;
            btnSetConfig.Click += btnSetConfig_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(203, 102);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 5;
            label3.Text = "Actual Config";
            // 
            // txtSetConfig
            // 
            txtSetConfig.Location = new Point(12, 99);
            txtSetConfig.Name = "txtSetConfig";
            txtSetConfig.Size = new Size(185, 23);
            txtSetConfig.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 521);
            Controls.Add(txtSetConfig);
            Controls.Add(label3);
            Controls.Add(btnSetConfig);
            Controls.Add(txtBoud);
            Controls.Add(txtPort);
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
        private TextBox txtPort;
        private TextBox txtBoud;
        private Button btnSetConfig;
        private Label label3;
        private TextBox txtSetConfig;
    }
}
