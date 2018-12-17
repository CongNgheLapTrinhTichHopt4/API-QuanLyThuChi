namespace WF_QuanLyThuChi.GUI.GUI_HanMucChiTieu
{
    partial class frmThemHoacSuaHanMuc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemHoacSuaHanMuc));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpThangHM = new System.Windows.Forms.DateTimePicker();
            this.txtHanMuc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLoaKC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpThangHM);
            this.panel1.Controls.Add(this.txtHanMuc);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboLoaKC);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 380);
            this.panel1.TabIndex = 0;
            // 
            // dtpThangHM
            // 
            this.dtpThangHM.CustomFormat = "MM-yyyy";
            this.dtpThangHM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThangHM.Location = new System.Drawing.Point(154, 233);
            this.dtpThangHM.Name = "dtpThangHM";
            this.dtpThangHM.Size = new System.Drawing.Size(216, 22);
            this.dtpThangHM.TabIndex = 5;
            // 
            // txtHanMuc
            // 
            this.txtHanMuc.Location = new System.Drawing.Point(154, 150);
            this.txtHanMuc.Name = "txtHanMuc";
            this.txtHanMuc.Size = new System.Drawing.Size(216, 22);
            this.txtHanMuc.TabIndex = 4;
            this.txtHanMuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHanMuc_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tháng Hạn Mức";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hạn Mức";
            // 
            // cboLoaKC
            // 
            this.cboLoaKC.FormattingEnabled = true;
            this.cboLoaKC.Location = new System.Drawing.Point(154, 62);
            this.cboLoaKC.Name = "cboLoaKC";
            this.cboLoaKC.Size = new System.Drawing.Size(216, 23);
            this.cboLoaKC.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại Khoản Chi";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.btnHuy);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 391);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 62);
            this.panel2.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(113, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(141, 62);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(254, 0);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(128, 62);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Hủy";
            // 
            // frmThemHoacSuaHanMuc
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 453);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmThemHoacSuaHanMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Hoặc Sửa Hạn Mức";
            this.Load += new System.EventHandler(this.frmThemHoacSuaHanMuc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboLoaKC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private System.Windows.Forms.TextBox txtHanMuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpThangHM;
    }
}