﻿namespace Atm_Machine
{
    partial class AddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            label5 = new Label();
            textBox4 = new TextBox();
            button2 = new Button();
            label1 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(871, 711);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(310, 170);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(282, 27);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(235, 231, 228);
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(40, 106, 77);
            label2.Location = new Point(234, 169);
            label2.Name = "label2";
            label2.Size = new Size(66, 28);
            label2.TabIndex = 3;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(235, 231, 228);
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(40, 106, 77);
            label3.Location = new Point(204, 227);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(310, 228);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(282, 27);
            textBox2.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(235, 231, 228);
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(40, 106, 77);
            label4.Location = new Point(124, 286);
            label4.Name = "label4";
            label4.Size = new Size(176, 28);
            label4.TabIndex = 7;
            label4.Text = "Confirm Password";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(310, 286);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(282, 27);
            textBox3.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(40, 106, 77);
            button1.ForeColor = Color.White;
            button1.Location = new Point(412, 548);
            button1.Name = "button1";
            button1.Size = new Size(162, 49);
            button1.TabIndex = 8;
            button1.Text = "Add User";
            button1.UseVisualStyleBackColor = false;
            button1.Click += AddUserClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(235, 231, 228);
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(40, 106, 77);
            label5.Location = new Point(156, 344);
            label5.Name = "label5";
            label5.Size = new Size(144, 28);
            label5.TabIndex = 10;
            label5.Text = "Initial Amount";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(310, 345);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(282, 27);
            textBox4.TabIndex = 9;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.ForeColor = Color.FromArgb(40, 106, 77);
            button2.Location = new Point(194, 548);
            button2.Name = "button2";
            button2.Size = new Size(162, 49);
            button2.TabIndex = 11;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = false;
            button2.Click += BackClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(235, 231, 228);
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(40, 106, 77);
            label1.Location = new Point(234, 399);
            label1.Name = "label1";
            label1.Size = new Size(63, 28);
            label1.TabIndex = 12;
            label1.Text = "Email";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(310, 401);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(282, 27);
            textBox5.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(235, 231, 228);
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(40, 106, 77);
            label6.Location = new Point(234, 456);
            label6.Name = "label6";
            label6.Size = new Size(69, 28);
            label6.TabIndex = 14;
            label6.Text = "Phone";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(310, 456);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(282, 27);
            textBox6.TabIndex = 15;
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(871, 711);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(textBox5);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Name = "AddUser";
            Text = "AddUser";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private Button button1;
        private Label label5;
        private TextBox textBox4;
        private Button button2;
        private Label label1;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox6;
    }
}