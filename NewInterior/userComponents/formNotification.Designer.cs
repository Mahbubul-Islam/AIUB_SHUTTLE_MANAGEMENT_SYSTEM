namespace NewInterior.userComponents
{
    partial class formNotification
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
            this.pnlNotificationShow = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // pnlNotificationShow
            // 
            this.pnlNotificationShow.Location = new System.Drawing.Point(0, 45);
            this.pnlNotificationShow.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNotificationShow.Name = "pnlNotificationShow";
            this.pnlNotificationShow.Size = new System.Drawing.Size(1005, 598);
            this.pnlNotificationShow.TabIndex = 0;
            // 
            // formNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlNotificationShow);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "formNotification";
            this.Size = new System.Drawing.Size(1005, 643);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlNotificationShow;
    }
}
