namespace MillionDollarAds.View

{
    partial class HomePage
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
            this.listViewHomePage = new System.Windows.Forms.ListView();
            this.showAdButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewHomePage
            // 
            this.listViewHomePage.HideSelection = false;
            this.listViewHomePage.Location = new System.Drawing.Point(31, 18);
            this.listViewHomePage.Name = "listViewHomePage";
            this.listViewHomePage.Size = new System.Drawing.Size(496, 407);
            this.listViewHomePage.TabIndex = 1;
            this.listViewHomePage.UseCompatibleStateImageBehavior = false;
            // 
            // showAdButton
            // 
            this.showAdButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAdButton.Location = new System.Drawing.Point(553, 390);
            this.showAdButton.Name = "showAdButton";
            this.showAdButton.Size = new System.Drawing.Size(137, 35);
            this.showAdButton.TabIndex = 2;
            this.showAdButton.Text = "Show Ad";
            this.showAdButton.UseVisualStyleBackColor = true;
            this.showAdButton.Click += new System.EventHandler(this.showAdButton_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.showAdButton);
            this.Controls.Add(this.listViewHomePage);
            this.Name = "HomePage";
            this.Size = new System.Drawing.Size(771, 603);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listViewHomePage;
        public System.Windows.Forms.Button showAdButton;
    }
}
