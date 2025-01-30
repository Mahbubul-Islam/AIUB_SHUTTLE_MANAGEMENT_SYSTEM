namespace NewInterior.userComponents
{
    partial class formUserManageAccount
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
            this.lblid = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(104, 106);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(23, 16);
            this.lblid.TabIndex = 0;
            this.lblid.Text = "ID:";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(80, 151);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(47, 16);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "Name:";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(83, 193);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(44, 16);
            this.lblemail.TabIndex = 2;
            this.lblemail.Text = "Email:";
            // 
            // formUserManageAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.lblid);
            this.Name = "formUserManageAccount";
            this.Size = new System.Drawing.Size(1005, 643);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblemail;
    }
}
