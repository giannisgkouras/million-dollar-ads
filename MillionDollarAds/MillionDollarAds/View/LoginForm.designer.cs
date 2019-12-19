namespace MillionDollarAds
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameTbox = new System.Windows.Forms.TextBox();
            this.passwordTbox = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.passwordRecoveryBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // usernameTbox
            // 
            this.usernameTbox.Location = new System.Drawing.Point(117, 70);
            this.usernameTbox.Name = "usernameTbox";
            this.usernameTbox.Size = new System.Drawing.Size(100, 20);
            this.usernameTbox.TabIndex = 2;
            this.usernameTbox.TextChanged += new System.EventHandler(this.usernameTbox_TextChanged);
            // 
            // passwordTbox
            // 
            this.passwordTbox.Location = new System.Drawing.Point(117, 156);
            this.passwordTbox.Name = "passwordTbox";
            this.passwordTbox.PasswordChar = '*';
            this.passwordTbox.Size = new System.Drawing.Size(100, 20);
            this.passwordTbox.TabIndex = 3;
            this.passwordTbox.TextChanged += new System.EventHandler(this.passwordTbox_TextChanged);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(97, 238);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(141, 31);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(218, 437);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(123, 23);
            this.registerBtn.TabIndex = 5;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // passwordRecoveryBtn
            // 
            this.passwordRecoveryBtn.Location = new System.Drawing.Point(30, 437);
            this.passwordRecoveryBtn.Name = "passwordRecoveryBtn";
            this.passwordRecoveryBtn.Size = new System.Drawing.Size(156, 23);
            this.passwordRecoveryBtn.TabIndex = 6;
            this.passwordRecoveryBtn.Text = "Forgot your password?";
            this.passwordRecoveryBtn.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 536);
            this.Controls.Add(this.passwordRecoveryBtn);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordTbox);
            this.Controls.Add(this.usernameTbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameTbox;
        private System.Windows.Forms.TextBox passwordTbox;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button passwordRecoveryBtn;
    }
}