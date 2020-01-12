namespace MillionDollarAds.View
{
    partial class EditAdForm
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
            this.components = new System.ComponentModel.Container();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.property = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.priceTB = new System.Windows.Forms.TextBox();
            this.descriptionTB = new System.Windows.Forms.TextBox();
            this.titleTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.deleteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.deleteButton.Location = new System.Drawing.Point(452, 364);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(220, 23);
            this.deleteButton.TabIndex = 20;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.updateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.updateButton.Location = new System.Drawing.Point(200, 364);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(220, 23);
            this.updateButton.TabIndex = 19;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // property
            // 
            this.property.AutoSize = true;
            this.property.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.property.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.property.Location = new System.Drawing.Point(448, 63);
            this.property.Name = "property";
            this.property.Size = new System.Drawing.Size(93, 25);
            this.property.TabIndex = 18;
            this.property.Text = "Property";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(49, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Price";
            // 
            // priceTB
            // 
            this.priceTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource1, "Price", true));
            this.priceTB.Location = new System.Drawing.Point(200, 119);
            this.priceTB.Name = "priceTB";
            this.priceTB.Size = new System.Drawing.Size(195, 20);
            this.priceTB.TabIndex = 15;
            // 
            // descriptionTB
            // 
            this.descriptionTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource2, "Desc", true));
            this.descriptionTB.Location = new System.Drawing.Point(200, 186);
            this.descriptionTB.Multiline = true;
            this.descriptionTB.Name = "descriptionTB";
            this.descriptionTB.Size = new System.Drawing.Size(472, 134);
            this.descriptionTB.TabIndex = 14;
            // 
            // titleTB
            // 
            this.titleTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Title", true));
            this.titleTB.Location = new System.Drawing.Point(200, 68);
            this.titleTB.Name = "titleTB";
            this.titleTB.Size = new System.Drawing.Size(195, 20);
            this.titleTB.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(49, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Description";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.title.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.title.Location = new System.Drawing.Point(49, 68);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(53, 25);
            this.title.TabIndex = 11;
            this.title.Text = "Title";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sell",
            "Buy"});
            this.comboBox1.Location = new System.Drawing.Point(551, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 21;
            // 
            // productBindingSource1
            // 
            this.productBindingSource1.DataSource = typeof(MillionDollarAds.Product);
            // 
            // productBindingSource2
            // 
            this.productBindingSource2.DataSource = typeof(MillionDollarAds.Product);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(MillionDollarAds.Product);
            // 
            // EditAdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 492);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.property);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.priceTB);
            this.Controls.Add(this.descriptionTB);
            this.Controls.Add(this.titleTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.title);
            this.Name = "EditAdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditAdForm";
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label property;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox priceTB;
        private System.Windows.Forms.TextBox descriptionTB;
        private System.Windows.Forms.TextBox titleTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource productBindingSource1;
        private System.Windows.Forms.BindingSource productBindingSource2;
        private System.Windows.Forms.BindingSource productBindingSource;
    }
}