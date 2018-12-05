namespace Test_QuanLyThuChi
{
    partial class Form2
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tv = new System.Windows.Forms.TextBox();
            this.txtloai = new System.Windows.Forms.TextBox();
            this.hm = new System.Windows.Forms.TextBox();
            this.thoigian = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "matv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "loai";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "hanmuc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "thoigian";
            // 
            // tv
            // 
            this.tv.Location = new System.Drawing.Point(156, 53);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(196, 20);
            this.tv.TabIndex = 4;
            // 
            // txtloai
            // 
            this.txtloai.Location = new System.Drawing.Point(156, 90);
            this.txtloai.Name = "txtloai";
            this.txtloai.Size = new System.Drawing.Size(196, 20);
            this.txtloai.TabIndex = 5;
            // 
            // hm
            // 
            this.hm.Location = new System.Drawing.Point(156, 127);
            this.hm.Name = "hm";
            this.hm.Size = new System.Drawing.Size(196, 20);
            this.hm.TabIndex = 6;
            // 
            // thoigian
            // 
            this.thoigian.Location = new System.Drawing.Point(156, 164);
            this.thoigian.Name = "thoigian";
            this.thoigian.Size = new System.Drawing.Size(196, 20);
            this.thoigian.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 473);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.thoigian);
            this.Controls.Add(this.hm);
            this.Controls.Add(this.txtloai);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tv;
        private System.Windows.Forms.TextBox txtloai;
        private System.Windows.Forms.TextBox hm;
        private System.Windows.Forms.TextBox thoigian;
        private System.Windows.Forms.Button button1;
    }
}