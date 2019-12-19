namespace MillionDollarAds
{
    partial class RegistrationForm
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
            this.registerBtn = new System.Windows.Forms.Button();
            this.passwordTbox = new System.Windows.Forms.TextBox();
            this.usernameTbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.emailTbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cPassordTbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(105, 330);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(123, 23);
            this.registerBtn.TabIndex = 10;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // passwordTbox
            // 
            this.passwordTbox.Location = new System.Drawing.Point(117, 199);
            this.passwordTbox.Name = "passwordTbox";
            this.passwordTbox.PasswordChar = '*';
            this.passwordTbox.Size = new System.Drawing.Size(100, 20);
            this.passwordTbox.TabIndex = 9;
            // 
            // usernameTbox
            // 
            this.usernameTbox.Location = new System.Drawing.Point(117, 56);
            this.usernameTbox.Name = "usernameTbox";
            this.usernameTbox.Size = new System.Drawing.Size(100, 20);
            this.usernameTbox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username";
            // 
            // emailTbox
            // 
            this.emailTbox.Location = new System.Drawing.Point(117, 121);
            this.emailTbox.Name = "emailTbox";
            this.emailTbox.Size = new System.Drawing.Size(100, 20);
            this.emailTbox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email";
            // 
            // cPassordTbox
            // 
            this.cPassordTbox.Location = new System.Drawing.Point(117, 274);
            this.cPassordTbox.Name = "cPassordTbox";
            this.cPassordTbox.PasswordChar = '*';
            this.cPassordTbox.Size = new System.Drawing.Size(100, 20);
            this.cPassordTbox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Confrim your Passoword";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 499);
            this.Controls.Add(this.cPassordTbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.emailTbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.passwordTbox);
            this.Controls.Add(this.usernameTbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.TextBox passwordTbox;
        private System.Windows.Forms.TextBox usernameTbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox emailTbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cPassordTbox;
        private System.Windows.Forms.Label label4;
    }
}