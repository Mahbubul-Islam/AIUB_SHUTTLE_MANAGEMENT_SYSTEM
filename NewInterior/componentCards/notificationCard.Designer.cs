namespace NewInterior.componentCards
{
    partial class notificationCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(notificationCard));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNotificationMessage = new System.Windows.Forms.Label();
            this.lblNotificationDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 28);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblNotificationMessage
            // 
            this.lblNotificationMessage.AutoSize = true;
            this.lblNotificationMessage.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotificationMessage.ForeColor = System.Drawing.Color.Gold;
            this.lblNotificationMessage.Location = new System.Drawing.Point(172, 23);
            this.lblNotificationMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotificationMessage.Name = "lblNotificationMessage";
            this.lblNotificationMessage.Size = new System.Drawing.Size(382, 21);
            this.lblNotificationMessage.TabIndex = 4;
            this.lblNotificationMessage.Text = "--------------------------------------------------------------";
            // 
            // lblNotificationDate
            // 
            this.lblNotificationDate.AutoSize = true;
            this.lblNotificationDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNotificationDate.Location = new System.Drawing.Point(67, 24);
            this.lblNotificationDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotificationDate.Name = "lblNotificationDate";
            this.lblNotificationDate.Size = new System.Drawing.Size(71, 16);
            this.lblNotificationDate.TabIndex = 3;
            this.lblNotificationDate.Text = "11/09/2025";
            // 
            // notificationCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(149)))), ((int)(((byte)(164)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblNotificationMessage);
            this.Controls.Add(this.lblNotificationDate);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "notificationCard";
            this.Size = new System.Drawing.Size(1013, 63);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNotificationMessage;
        private System.Windows.Forms.Label lblNotificationDate;
    }
}
