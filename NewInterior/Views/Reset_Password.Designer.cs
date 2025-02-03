namespace NewInterior.Views
{
    partial class Reset_Password
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
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnResetpass = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkShowpass = new System.Windows.Forms.CheckBox();
            this.txtConfirmpass = new System.Windows.Forms.TextBox();
            this.txtNewpass = new System.Windows.Forms.TextBox();
            this.lblconfirmpass = new System.Windows.Forms.Label();
            this.lblnewpass = new System.Windows.Forms.Label();
            this.txtOldpass = new System.Windows.Forms.TextBox();
            this.lbloldpass = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Image = global::NewInterior.Properties.Resources.close_24;
            this.closeBtn.Location = new System.Drawing.Point(774, -1);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(45, 37);
            this.closeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeBtn.TabIndex = 259;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(239, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(323, 36);
            this.label4.TabIndex = 1;
            this.label4.Text = "Reset Your Password";
            // 
            // btnResetpass
            // 
            this.btnResetpass.Location = new System.Drawing.Point(333, 480);
            this.btnResetpass.Name = "btnResetpass";
            this.btnResetpass.Size = new System.Drawing.Size(123, 33);
            this.btnResetpass.TabIndex = 2;
            this.btnResetpass.Text = "SUBMIT";
            this.btnResetpass.UseVisualStyleBackColor = true;
            this.btnResetpass.Click += new System.EventHandler(this.btnResetpass_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkShowpass);
            this.panel2.Controls.Add(this.txtConfirmpass);
            this.panel2.Controls.Add(this.txtNewpass);
            this.panel2.Controls.Add(this.lblconfirmpass);
            this.panel2.Controls.Add(this.lblnewpass);
            this.panel2.Controls.Add(this.txtOldpass);
            this.panel2.Controls.Add(this.lbloldpass);
            this.panel2.Location = new System.Drawing.Point(144, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(510, 304);
            this.panel2.TabIndex = 3;
            // 
            // chkShowpass
            // 
            this.chkShowpass.AutoSize = true;
            this.chkShowpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowpass.Location = new System.Drawing.Point(61, 245);
            this.chkShowpass.Name = "chkShowpass";
            this.chkShowpass.Size = new System.Drawing.Size(161, 26);
            this.chkShowpass.TabIndex = 6;
            this.chkShowpass.Text = "Show Password";
            this.chkShowpass.UseVisualStyleBackColor = true;
            this.chkShowpass.CheckedChanged += new System.EventHandler(this.chkShowpass_CheckedChanged_1);
            // 
            // txtConfirmpass
            // 
            this.txtConfirmpass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmpass.Location = new System.Drawing.Point(61, 199);
            this.txtConfirmpass.Name = "txtConfirmpass";
            this.txtConfirmpass.Size = new System.Drawing.Size(384, 32);
            this.txtConfirmpass.TabIndex = 5;
            this.txtConfirmpass.UseSystemPasswordChar = true;
            // 
            // txtNewpass
            // 
            this.txtNewpass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewpass.Location = new System.Drawing.Point(61, 128);
            this.txtNewpass.Name = "txtNewpass";
            this.txtNewpass.Size = new System.Drawing.Size(384, 32);
            this.txtNewpass.TabIndex = 4;
            this.txtNewpass.UseSystemPasswordChar = true;
            // 
            // lblconfirmpass
            // 
            this.lblconfirmpass.AutoSize = true;
            this.lblconfirmpass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblconfirmpass.Location = new System.Drawing.Point(57, 173);
            this.lblconfirmpass.Name = "lblconfirmpass";
            this.lblconfirmpass.Size = new System.Drawing.Size(189, 23);
            this.lblconfirmpass.TabIndex = 3;
            this.lblconfirmpass.Text = "Confirm Password:";
            // 
            // lblnewpass
            // 
            this.lblnewpass.AutoSize = true;
            this.lblnewpass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnewpass.Location = new System.Drawing.Point(57, 102);
            this.lblnewpass.Name = "lblnewpass";
            this.lblnewpass.Size = new System.Drawing.Size(160, 23);
            this.lblnewpass.TabIndex = 2;
            this.lblnewpass.Text = "New Password:";
            // 
            // txtOldpass
            // 
            this.txtOldpass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldpass.Location = new System.Drawing.Point(61, 55);
            this.txtOldpass.Name = "txtOldpass";
            this.txtOldpass.Size = new System.Drawing.Size(384, 32);
            this.txtOldpass.TabIndex = 1;
            this.txtOldpass.UseSystemPasswordChar = true;
            // 
            // lbloldpass
            // 
            this.lbloldpass.AutoSize = true;
            this.lbloldpass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbloldpass.Location = new System.Drawing.Point(57, 29);
            this.lbloldpass.Name = "lbloldpass";
            this.lbloldpass.Size = new System.Drawing.Size(150, 23);
            this.lbloldpass.TabIndex = 0;
            this.lbloldpass.Text = "Old Password:";
            // 
            // Reset_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(818, 547);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnResetpass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reset_Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset_Password";
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnResetpass;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbloldpass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConfirmpass;
        private System.Windows.Forms.TextBox txtNewpass;
        private System.Windows.Forms.Label lblconfirmpass;
        private System.Windows.Forms.Label lblnewpass;
        private System.Windows.Forms.TextBox txtOldpass;
        private System.Windows.Forms.PictureBox closeBtn;
        private System.Windows.Forms.CheckBox chkShowpass;
    }
}