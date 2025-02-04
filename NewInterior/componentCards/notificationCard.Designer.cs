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
            this.valueNotifiactionString = new System.Windows.Forms.Label();
            this.valueNotificationDateTime = new System.Windows.Forms.Label();
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
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // valueNotifiactionString
            // 
            this.valueNotifiactionString.AutoSize = true;
            this.valueNotifiactionString.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueNotifiactionString.ForeColor = System.Drawing.Color.Black;
            this.valueNotifiactionString.Location = new System.Drawing.Point(107, 22);
            this.valueNotifiactionString.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.valueNotifiactionString.Name = "valueNotifiactionString";
            this.valueNotifiactionString.Size = new System.Drawing.Size(443, 19);
            this.valueNotifiactionString.TabIndex = 4;
            this.valueNotifiactionString.Text = "--------------------------------------------------------------";
            // 
            // valueNotificationDateTime
            // 
            this.valueNotificationDateTime.AutoSize = true;
            this.valueNotificationDateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.valueNotificationDateTime.Location = new System.Drawing.Point(823, 34);
            this.valueNotificationDateTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.valueNotificationDateTime.Name = "valueNotificationDateTime";
            this.valueNotificationDateTime.Size = new System.Drawing.Size(71, 16);
            this.valueNotificationDateTime.TabIndex = 3;
            this.valueNotificationDateTime.Text = "11/09/2025";
            // 
            // notificationCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.valueNotifiactionString);
            this.Controls.Add(this.valueNotificationDateTime);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "notificationCard";
            this.Size = new System.Drawing.Size(1005, 63);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label valueNotifiactionString;
        private System.Windows.Forms.Label valueNotificationDateTime;
    }
}
