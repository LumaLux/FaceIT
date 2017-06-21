namespace FaceIT
{
    partial class Presence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Presence));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Image = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Aanwezig = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.presence_in_percentage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 195);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(8)))), ((int)(((byte)(29)))));
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Calibri", 11.2F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(836, 660);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(158, 49);
            this.button5.TabIndex = 7;
            this.button5.Text = "Back";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Image,
            this.Aanwezig,
            this.presence_in_percentage});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HoverSelection = true;
            this.listView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(227, 210);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(550, 447);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Image
            // 
            this.Image.Text = "ClassName";
            this.Image.Width = 90;
            // 
            // Aanwezig
            // 
            this.Aanwezig.Text = "Presence";
            this.Aanwezig.Width = 90;
            // 
            // presence_in_percentage
            // 
            this.presence_in_percentage.Text = "Presence in %";
            this.presence_in_percentage.Width = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "KLAS - Periode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 50.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(319, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(358, 103);
            this.label4.TabIndex = 10;
            this.label4.Text = "Presence";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // Presence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Presence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FaceIT - Smart Absense 2017";
            this.Load += new System.EventHandler(this.Presence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader Image;
        private System.Windows.Forms.ColumnHeader Aanwezig;
        private System.Windows.Forms.ColumnHeader presence_in_percentage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}