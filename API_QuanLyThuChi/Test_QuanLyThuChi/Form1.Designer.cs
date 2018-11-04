namespace Test_QuanLyThuChi
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvKhoanThu = new System.Windows.Forms.DataGridView();
            this.MaKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhoanThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.cboLoaiKT = new System.Windows.Forms.ComboBox();
            this.cboMaTV = new System.Windows.Forms.ComboBox();
            this.txtKhoanThu = new System.Windows.Forms.TextBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtMakt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHienTen = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoanThu)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Xem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvKhoanThu
            // 
            this.dgvKhoanThu.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvKhoanThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoanThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKT,
            this.Ngay,
            this.LoaiKT,
            this.KhoanThu,
            this.SoTien,
            this.GhiChu});
            this.dgvKhoanThu.Location = new System.Drawing.Point(387, 26);
            this.dgvKhoanThu.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKhoanThu.Name = "dgvKhoanThu";
            this.dgvKhoanThu.Size = new System.Drawing.Size(846, 534);
            this.dgvKhoanThu.TabIndex = 5;
            // 
            // MaKT
            // 
            this.MaKT.DataPropertyName = "MaKT";
            this.MaKT.HeaderText = "Mã Khoản Thu";
            this.MaKT.Name = "MaKT";
            // 
            // Ngay
            // 
            this.Ngay.DataPropertyName = "Ngay";
            this.Ngay.HeaderText = "Ngày";
            this.Ngay.Name = "Ngay";
            // 
            // LoaiKT
            // 
            this.LoaiKT.DataPropertyName = "LoaiKT";
            this.LoaiKT.HeaderText = "Loại Khoản Thu";
            this.LoaiKT.Name = "LoaiKT";
            // 
            // KhoanThu
            // 
            this.KhoanThu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KhoanThu.DataPropertyName = "KhoanThu";
            this.KhoanThu.HeaderText = "KhoảnThu";
            this.KhoanThu.Name = "KhoanThu";
            // 
            // SoTien
            // 
            this.SoTien.DataPropertyName = "SoTien";
            dataGridViewCellStyle1.Format = "0,000";
            this.SoTien.DefaultCellStyle = dataGridViewCellStyle1;
            this.SoTien.HeaderText = "Số Tiền";
            this.SoTien.Name = "SoTien";
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PowderBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Controls.Add(this.btnSua);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.txtTimKiem);
            this.panel3.Controls.Add(this.btnThem);
            this.panel3.Location = new System.Drawing.Point(12, 367);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(366, 193);
            this.panel3.TabIndex = 7;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(247, 144);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(97, 23);
            this.btnTimKiem.TabIndex = 31;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(247, 78);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 46);
            this.btnRefresh.TabIndex = 30;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(247, 17);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 46);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(136, 78);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 46);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(23, 144);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(213, 22);
            this.txtTimKiem.TabIndex = 24;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(23, 78);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 46);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtpNgay);
            this.panel1.Controls.Add(this.cboLoaiKT);
            this.panel1.Controls.Add(this.cboMaTV);
            this.panel1.Controls.Add(this.txtKhoanThu);
            this.panel1.Controls.Add(this.txtSoTien);
            this.panel1.Controls.Add(this.txtGhiChu);
            this.panel1.Controls.Add(this.txtMakt);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(11, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 333);
            this.panel1.TabIndex = 6;
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(137, 103);
            this.dtpNgay.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(209, 22);
            this.dtpNgay.TabIndex = 29;
            // 
            // cboLoaiKT
            // 
            this.cboLoaiKT.FormattingEnabled = true;
            this.cboLoaiKT.Location = new System.Drawing.Point(137, 148);
            this.cboLoaiKT.Margin = new System.Windows.Forms.Padding(4);
            this.cboLoaiKT.Name = "cboLoaiKT";
            this.cboLoaiKT.Size = new System.Drawing.Size(209, 24);
            this.cboLoaiKT.TabIndex = 28;
            // 
            // cboMaTV
            // 
            this.cboMaTV.FormattingEnabled = true;
            this.cboMaTV.Location = new System.Drawing.Point(137, 57);
            this.cboMaTV.Margin = new System.Windows.Forms.Padding(4);
            this.cboMaTV.Name = "cboMaTV";
            this.cboMaTV.Size = new System.Drawing.Size(209, 24);
            this.cboMaTV.TabIndex = 26;
            // 
            // txtKhoanThu
            // 
            this.txtKhoanThu.Location = new System.Drawing.Point(137, 193);
            this.txtKhoanThu.Margin = new System.Windows.Forms.Padding(4);
            this.txtKhoanThu.Name = "txtKhoanThu";
            this.txtKhoanThu.Size = new System.Drawing.Size(209, 22);
            this.txtKhoanThu.TabIndex = 25;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(137, 238);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(209, 22);
            this.txtSoTien.TabIndex = 24;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(137, 282);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(209, 22);
            this.txtGhiChu.TabIndex = 23;
            // 
            // txtMakt
            // 
            this.txtMakt.Location = new System.Drawing.Point(137, 12);
            this.txtMakt.Margin = new System.Windows.Forms.Padding(4);
            this.txtMakt.Name = "txtMakt";
            this.txtMakt.Size = new System.Drawing.Size(209, 22);
            this.txtMakt.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 112);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Ngày";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 158);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Loại Khoản Thu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 202);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Khoản Thu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 246);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Số Tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 290);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ghi Chú";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Thành Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mã Khoản Thu";
            // 
            // btnHienTen
            // 
            this.btnHienTen.Location = new System.Drawing.Point(611, 584);
            this.btnHienTen.Name = "btnHienTen";
            this.btnHienTen.Size = new System.Drawing.Size(97, 23);
            this.btnHienTen.TabIndex = 33;
            this.btnHienTen.Text = "Hiện Tên";
            this.btnHienTen.UseVisualStyleBackColor = true;
            this.btnHienTen.Click += new System.EventHandler(this.btnHienTen_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(387, 584);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(213, 22);
            this.txtUserName.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 655);
            this.Controls.Add(this.btnHienTen);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.dgvKhoanThu);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Test QL Khoan Thu";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoanThu)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvKhoanThu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.ComboBox cboLoaiKT;
        private System.Windows.Forms.ComboBox cboMaTV;
        private System.Windows.Forms.TextBox txtKhoanThu;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtMakt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhoanThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnHienTen;
        private System.Windows.Forms.TextBox txtUserName;
    }
}

