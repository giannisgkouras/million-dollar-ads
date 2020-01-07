namespace MillionDollarAds
{
    partial class AddAdv
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saleRB = new System.Windows.Forms.RadioButton();
            this.demandRB = new System.Windows.Forms.RadioButton();
            this.subcategorylabel = new System.Windows.Forms.Label();
            this.subcategoryCB = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(245, 214);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(134, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "title";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(245, 240);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(134, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "description";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Προσθήκη";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(245, 268);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(134, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "imageurl";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(245, 296);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(134, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "price";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Προσθήκη αγγελιας";
            // 
            // categoryCB
            // 
            this.categoryCB.FormattingEnabled = true;
            this.categoryCB.Location = new System.Drawing.Point(245, 131);
            this.categoryCB.Name = "categoryCB";
            this.categoryCB.Size = new System.Drawing.Size(134, 21);
            this.categoryCB.TabIndex = 7;
            this.categoryCB.SelectedIndexChanged += new System.EventHandler(this.categoryCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Επιλέξτε κατηγορία";
            // 
            // saleRB
            // 
            this.saleRB.AutoSize = true;
            this.saleRB.Checked = true;
            this.saleRB.Location = new System.Drawing.Point(245, 158);
            this.saleRB.Name = "saleRB";
            this.saleRB.Size = new System.Drawing.Size(64, 17);
            this.saleRB.TabIndex = 11;
            this.saleRB.TabStop = true;
            this.saleRB.Text = "Πώληση";
            this.saleRB.UseVisualStyleBackColor = true;
            // 
            // demandRB
            // 
            this.demandRB.AutoSize = true;
            this.demandRB.Location = new System.Drawing.Point(245, 181);
            this.demandRB.Name = "demandRB";
            this.demandRB.Size = new System.Drawing.Size(62, 17);
            this.demandRB.TabIndex = 12;
            this.demandRB.Text = "Ζήτηση";
            this.demandRB.UseVisualStyleBackColor = true;
            // 
            // subcategorylabel
            // 
            this.subcategorylabel.AutoSize = true;
            this.subcategorylabel.Location = new System.Drawing.Point(405, 137);
            this.subcategorylabel.Name = "subcategorylabel";
            this.subcategorylabel.Size = new System.Drawing.Size(123, 13);
            this.subcategorylabel.TabIndex = 14;
            this.subcategorylabel.Text = "Επιλέξτε υποκατηγορία";
            this.subcategorylabel.Visible = false;
            // 
            // subcategoryCB
            // 
            this.subcategoryCB.FormattingEnabled = true;
            this.subcategoryCB.Location = new System.Drawing.Point(531, 134);
            this.subcategoryCB.Name = "subcategoryCB";
            this.subcategoryCB.Size = new System.Drawing.Size(134, 21);
            this.subcategoryCB.TabIndex = 13;
            this.subcategoryCB.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // AddAdv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.subcategorylabel);
            this.Controls.Add(this.subcategoryCB);
            this.Controls.Add(this.demandRB);
            this.Controls.Add(this.saleRB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.categoryCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "AddAdv";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoryCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton saleRB;
        private System.Windows.Forms.RadioButton demandRB;
        private System.Windows.Forms.Label subcategorylabel;
        private System.Windows.Forms.ComboBox subcategoryCB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}