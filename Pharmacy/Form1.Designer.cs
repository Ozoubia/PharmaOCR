namespace Pharmacy
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
            this.CamPictureBox = new System.Windows.Forms.PictureBox();
            this.ProcessBtn = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.autoProcess = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.CamPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CamPictureBox
            // 
            this.CamPictureBox.Location = new System.Drawing.Point(0, 0);
            this.CamPictureBox.Name = "CamPictureBox";
            this.CamPictureBox.Size = new System.Drawing.Size(380, 240);
            this.CamPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CamPictureBox.TabIndex = 0;
            this.CamPictureBox.TabStop = false;
            this.CamPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CamPictureBox_Paint);
            // 
            // ProcessBtn
            // 
            this.ProcessBtn.Location = new System.Drawing.Point(12, 263);
            this.ProcessBtn.Name = "ProcessBtn";
            this.ProcessBtn.Size = new System.Drawing.Size(75, 23);
            this.ProcessBtn.TabIndex = 1;
            this.ProcessBtn.Text = "Process";
            this.ProcessBtn.UseVisualStyleBackColor = true;
            this.ProcessBtn.Click += new System.EventHandler(this.ProcessBtn_Click);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(125, 266);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(189, 20);
            this.ResultTextBox.TabIndex = 2;
            // 
            // timer
            // 
            this.timer.Interval = 4000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // autoProcess
            // 
            this.autoProcess.AutoSize = true;
            this.autoProcess.Location = new System.Drawing.Point(13, 305);
            this.autoProcess.Name = "autoProcess";
            this.autoProcess.Size = new System.Drawing.Size(113, 17);
            this.autoProcess.TabIndex = 3;
            this.autoProcess.Text = "Automatic process";
            this.autoProcess.UseVisualStyleBackColor = true;
            this.autoProcess.CheckedChanged += new System.EventHandler(this.autoProcess_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 343);
            this.Controls.Add(this.autoProcess);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.ProcessBtn);
            this.Controls.Add(this.CamPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CamPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ProcessBtn;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox autoProcess;
        public System.Windows.Forms.PictureBox CamPictureBox;
    }
}

