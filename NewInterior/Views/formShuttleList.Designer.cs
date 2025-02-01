namespace NewInterior.Views
{
    partial class formShuttleList
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
            this.pnlDisplayShuttleList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDeleteShuttle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlDisplayShuttleList
            // 
            this.pnlDisplayShuttleList.Location = new System.Drawing.Point(2, 3);
            this.pnlDisplayShuttleList.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDisplayShuttleList.Name = "pnlDisplayShuttleList";
            this.pnlDisplayShuttleList.Size = new System.Drawing.Size(940, 337);
            this.pnlDisplayShuttleList.TabIndex = 0;
            // 
            // btnDeleteShuttle
            // 
            this.btnDeleteShuttle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteShuttle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteShuttle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteShuttle.Location = new System.Drawing.Point(666, 415);
            this.btnDeleteShuttle.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteShuttle.Name = "btnDeleteShuttle";
            this.btnDeleteShuttle.Size = new System.Drawing.Size(148, 39);
            this.btnDeleteShuttle.TabIndex = 256;
            this.btnDeleteShuttle.Text = "Delete";
            this.btnDeleteShuttle.UseVisualStyleBackColor = false;
            // 
            // formShuttleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 500);
            this.Controls.Add(this.btnDeleteShuttle);
            this.Controls.Add(this.pnlDisplayShuttleList);
            this.Name = "formShuttleList";
            this.Text = "formShuttleList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlDisplayShuttleList;
        private System.Windows.Forms.Button btnDeleteShuttle;
    }
}