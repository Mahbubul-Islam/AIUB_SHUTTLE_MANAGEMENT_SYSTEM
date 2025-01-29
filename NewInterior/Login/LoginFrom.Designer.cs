namespace NewInterior.Login
{
    partial class LoginFrom
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
            this.buttonLog = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonLog
            // 
            this.buttonLog.BackColor = System.Drawing.Color.Sienna;
            this.buttonLog.FlatAppearance.BorderSize = 0;
            this.buttonLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLog.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLog.Location = new System.Drawing.Point(39, 333);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(312, 30);
            this.buttonLog.TabIndex = 71;
            this.buttonLog.Text = "LOGIN";
            this.buttonLog.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(37, 255);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(314, 27);
            this.textBox2.TabIndex = 70;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.Location = new System.Drawing.Point(35, 232);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(79, 20);
            this.labelPass.TabIndex = 69;
            this.labelPass.Text = "Password";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(37, 191);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(314, 27);
            this.textBox1.TabIndex = 68;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(35, 170);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(89, 20);
            this.labelUser.TabIndex = 67;
            this.labelUser.Text = "User Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(320, 33);
            this.label4.TabIndex = 66;
            this.label4.Text = "LOGIN YOUR ACCOUNT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 41);
            this.label1.TabIndex = 64;
            this.label1.Text = "AIUB SHUTTLE";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(39, 289);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 72;
            this.checkBox1.Text = "Show Password";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // LoginFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 513);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "LoginFrom";
            this.Text = "LoginFrom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}