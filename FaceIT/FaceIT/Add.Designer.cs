﻿namespace FaceIT
{
    partial class Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Add_Button = new System.Windows.Forms.Button();
            this.ClassName = new System.Windows.Forms.TextBox();
            this.AmountStudents = new System.Windows.Forms.TextBox();
            this.AmountLessons = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 295);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Add_Button
            // 
            this.Add_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(8)))), ((int)(((byte)(29)))));
            this.Add_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add_Button.Font = new System.Drawing.Font("Calibri", 20.2F, System.Drawing.FontStyle.Bold);
            this.Add_Button.ForeColor = System.Drawing.Color.White;
            this.Add_Button.Location = new System.Drawing.Point(832, 738);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(246, 97);
            this.Add_Button.TabIndex = 1;
            this.Add_Button.Text = "Add class";
            this.Add_Button.UseVisualStyleBackColor = false;
            this.Add_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClassName
            // 
            this.ClassName.Location = new System.Drawing.Point(769, 434);
            this.ClassName.Name = "ClassName";
            this.ClassName.Size = new System.Drawing.Size(364, 22);
            this.ClassName.TabIndex = 2;
            // 
            // AmountStudents
            // 
            this.AmountStudents.Location = new System.Drawing.Point(769, 532);
            this.AmountStudents.Name = "AmountStudents";
            this.AmountStudents.Size = new System.Drawing.Size(364, 22);
            this.AmountStudents.TabIndex = 3;
            // 
            // AmountLessons
            // 
            this.AmountLessons.Location = new System.Drawing.Point(769, 619);
            this.AmountLessons.Name = "AmountLessons";
            this.AmountLessons.Size = new System.Drawing.Size(364, 22);
            this.AmountLessons.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(866, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 41);
            this.label1.TabIndex = 5;
            this.label1.Text = "Classname:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 20.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(798, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 41);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of students:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 20.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(791, 575);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 41);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of lessons:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 50.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(751, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(429, 103);
            this.label4.TabIndex = 8;
            this.label4.Text = "Add a class";
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AmountLessons);
            this.Controls.Add(this.AmountStudents);
            this.Controls.Add(this.ClassName);
            this.Controls.Add(this.Add_Button);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add";
            this.Text = "Add";
            this.Load += new System.EventHandler(this.Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.TextBox ClassName;
        private System.Windows.Forms.TextBox AmountStudents;
        private System.Windows.Forms.TextBox AmountLessons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}