namespace NewInterior.componentCards
{
    partial class selectShuttleCard
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
            this.valueTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.valueShuttleName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.valueRoute = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // valueTime
            // 
            this.valueTime.AutoSize = true;
            this.valueTime.Font = new System.Drawing.Font("Century Gothic", 6.5F, System.Drawing.FontStyle.Bold);
            this.valueTime.Location = new System.Drawing.Point(475, 24);
            this.valueTime.Name = "valueTime";
            this.valueTime.Size = new System.Drawing.Size(34, 15);
            this.valueTime.TabIndex = 30;
            this.valueTime.Text = "22:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 6.5F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(435, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Time:";
            // 
            // valueShuttleName
            // 
            this.valueShuttleName.AutoSize = true;
            this.valueShuttleName.Font = new System.Drawing.Font("Century Gothic", 6.5F, System.Drawing.FontStyle.Bold);
            this.valueShuttleName.Location = new System.Drawing.Point(90, 23);
            this.valueShuttleName.Name = "valueShuttleName";
            this.valueShuttleName.Size = new System.Drawing.Size(90, 15);
            this.valueShuttleName.TabIndex = 25;
            this.valueShuttleName.Text = "AIUB transport 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 6.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Shuttle Name:";
            // 
            // valueRoute
            // 
            this.valueRoute.AutoSize = true;
            this.valueRoute.Font = new System.Drawing.Font("Century Gothic", 6.5F, System.Drawing.FontStyle.Bold);
            this.valueRoute.Location = new System.Drawing.Point(233, 24);
            this.valueRoute.Name = "valueRoute";
            this.valueRoute.Size = new System.Drawing.Size(196, 15);
            this.valueRoute.TabIndex = 32;
            this.valueRoute.Text = "Kuratoli-Mohakhali-Mohammedpur";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 6.5F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(186, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "Route:";
            // 
            // selectShuttleCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(149)))), ((int)(((byte)(164)))));
            this.Controls.Add(this.valueRoute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.valueTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.valueShuttleName);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "selectShuttleCard";
            this.Size = new System.Drawing.Size(528, 63);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label valueTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label valueShuttleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label valueRoute;
        private System.Windows.Forms.Label label2;
    }
}
