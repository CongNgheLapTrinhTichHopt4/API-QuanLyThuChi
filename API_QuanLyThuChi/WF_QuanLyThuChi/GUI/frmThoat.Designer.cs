namespace WF_QuanLyThuChi
{
    partial class frmThoat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCancle = new System.Windows.Forms.Label();
            this.lblShutdown = new System.Windows.Forms.Label();
            this.lblLogoff = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.PictureBox();
            this.btnShutdown = new System.Windows.Forms.PictureBox();
            this.btnLogOff = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShutdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogOff)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblCancle);
            this.panel1.Controls.Add(this.lblShutdown);
            this.panel1.Controls.Add(this.lblLogoff);
            this.panel1.Controls.Add(this.btnCancle);
            this.panel1.Controls.Add(this.btnShutdown);
            this.panel1.Controls.Add(this.btnLogOff);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 169);
            this.panel1.TabIndex = 1;
            // 
            // lblCancle
            // 
            this.lblCancle.AutoSize = true;
            this.lblCancle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancle.Location = new System.Drawing.Point(349, 134);
            this.lblCancle.Name = "lblCancle";
            this.lblCancle.Size = new System.Drawing.Size(49, 19);
            this.lblCancle.TabIndex = 11;
            this.lblCancle.Text = "label1";
            // 
            // lblShutdown
            // 
            this.lblShutdown.AutoSize = true;
            this.lblShutdown.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShutdown.Location = new System.Drawing.Point(191, 134);
            this.lblShutdown.Name = "lblShutdown";
            this.lblShutdown.Size = new System.Drawing.Size(49, 19);
            this.lblShutdown.TabIndex = 10;
            this.lblShutdown.Text = "label1";
            // 
            // lblLogoff
            // 
            this.lblLogoff.AutoSize = true;
            this.lblLogoff.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogoff.Location = new System.Drawing.Point(41, 134);
            this.lblLogoff.Name = "lblLogoff";
            this.lblLogoff.Size = new System.Drawing.Size(49, 19);
            this.lblLogoff.TabIndex = 9;
            this.lblLogoff.Text = "label1";
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.Color.White;
            this.btnCancle.Image = global::WF_QuanLyThuChi.Properties.Resources.att_navigator;
            this.btnCancle.Location = new System.Drawing.Point(326, 28);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(107, 103);
            this.btnCancle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancle.TabIndex = 8;
            this.btnCancle.TabStop = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            this.btnCancle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancle_MouseMove);
            // 
            // btnShutdown
            // 
            this.btnShutdown.BackColor = System.Drawing.Color.White;
            this.btnShutdown.Image = global::WF_QuanLyThuChi.Properties.Resources.screen_off_conf;
            this.btnShutdown.Location = new System.Drawing.Point(177, 28);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(107, 103);
            this.btnShutdown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnShutdown.TabIndex = 7;
            this.btnShutdown.TabStop = false;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            this.btnShutdown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnShutdown_MouseMove);
            // 
            // btnLogOff
            // 
            this.btnLogOff.BackColor = System.Drawing.Color.White;
            this.btnLogOff.Image = global::WF_QuanLyThuChi.Properties.Resources.snap_lock;
            this.btnLogOff.Location = new System.Drawing.Point(26, 28);
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.Size = new System.Drawing.Size(107, 103);
            this.btnLogOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLogOff.TabIndex = 6;
            this.btnLogOff.TabStop = false;
            this.btnLogOff.Click += new System.EventHandler(this.btnLogOff_Click);
            this.btnLogOff.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnLogOff_MouseMove);
            // 
            // frmThoat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(480, 195);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThoat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmThoat";
            this.Load += new System.EventHandler(this.frmThoat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShutdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogOff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCancle;
        private System.Windows.Forms.Label lblShutdown;
        private System.Windows.Forms.Label lblLogoff;
        private System.Windows.Forms.PictureBox btnCancle;
        private System.Windows.Forms.PictureBox btnShutdown;
        private System.Windows.Forms.PictureBox btnLogOff;
    }
}