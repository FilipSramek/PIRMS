namespace CV08_cteni_z_webu
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
            btnDown = new Button();
            lstBox = new ListBox();
            txtDebug = new TextBox();
            SuspendLayout();
            // 
            // btnDown
            // 
            btnDown.Location = new Point(569, 12);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(73, 27);
            btnDown.TabIndex = 0;
            btnDown.Text = "Download";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // lstBox
            // 
            lstBox.FormattingEnabled = true;
            lstBox.ItemHeight = 15;
            lstBox.Location = new Point(20, 12);
            lstBox.Name = "lstBox";
            lstBox.Size = new Size(460, 424);
            lstBox.TabIndex = 1;
            // 
            // txtDebug
            // 
            txtDebug.Location = new Point(573, 123);
            txtDebug.Name = "txtDebug";
            txtDebug.Size = new Size(202, 23);
            txtDebug.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDebug);
            Controls.Add(lstBox);
            Controls.Add(btnDown);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDown;
        private ListBox lstBox;
        private TextBox txtDebug;
    }
}
