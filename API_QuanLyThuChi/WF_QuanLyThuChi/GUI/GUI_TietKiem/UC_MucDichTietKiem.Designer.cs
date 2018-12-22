namespace WF_QuanLyThuChi.GUI.GUI_TietKiem
{
    partial class UC_MucDichTietKiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_MucDichTietKiem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDangTK = new DevExpress.XtraEditors.SimpleButton();
            this.btnTKDaHT = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.maMD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tenmucdich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sotiendukien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sotiendatietkiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ngaybatdau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ngayketthuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.trangthai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Xoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnXoa = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.Sua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSua = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1675, 38);
            this.panel1.TabIndex = 6;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(694, 6);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(284, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "QUẢN LÝ MỤC ĐÍCH TIẾT KIỆM";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDangTK);
            this.panel3.Controls.Add(this.btnTKDaHT);
            this.panel3.Controls.Add(this.btnThemMoi);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1675, 68);
            this.panel3.TabIndex = 8;
            // 
            // btnDangTK
            // 
            this.btnDangTK.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangTK.Appearance.Options.UseFont = true;
            this.btnDangTK.Location = new System.Drawing.Point(256, 4);
            this.btnDangTK.Name = "btnDangTK";
            this.btnDangTK.Size = new System.Drawing.Size(177, 56);
            this.btnDangTK.TabIndex = 8;
            this.btnDangTK.Text = "Đang Tiết Kiệm";
            this.btnDangTK.Click += new System.EventHandler(this.btnDangTK_Click);
            // 
            // btnTKDaHT
            // 
            this.btnTKDaHT.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKDaHT.Appearance.Options.UseFont = true;
            this.btnTKDaHT.Location = new System.Drawing.Point(3, 3);
            this.btnTKDaHT.Name = "btnTKDaHT";
            this.btnTKDaHT.Size = new System.Drawing.Size(247, 56);
            this.btnTKDaHT.TabIndex = 7;
            this.btnTKDaHT.Text = "Khoản Tiết Kiệm Đã Hoàn Thành";
            this.btnTKDaHT.Click += new System.EventHandler(this.btnTKDaHT_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoi.Appearance.Options.UseFont = true;
            this.btnThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMoi.Image")));
            this.btnThemMoi.Location = new System.Drawing.Point(1514, 6);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(158, 59);
            this.btnThemMoi.TabIndex = 6;
            this.btnThemMoi.Text = "Thêm Mới";
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 106);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.btnXoa,
            this.btnSua});
            this.gridControl1.Size = new System.Drawing.Size(1675, 774);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.maMD,
            this.tenmucdich,
            this.sotiendukien,
            this.sotiendatietkiem,
            this.ngaybatdau,
            this.ngayketthuc,
            this.trangthai,
            this.Xoa,
            this.Sua});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Danh sách mục đích tiết kiệm";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            // 
            // maMD
            // 
            this.maMD.Caption = "Mã";
            this.maMD.FieldName = "maMD";
            this.maMD.Name = "maMD";
            this.maMD.Width = 82;
            // 
            // tenmucdich
            // 
            this.tenmucdich.Caption = "Tên Mục Đích";
            this.tenmucdich.FieldName = "tenmucdich";
            this.tenmucdich.Name = "tenmucdich";
            this.tenmucdich.Visible = true;
            this.tenmucdich.VisibleIndex = 0;
            this.tenmucdich.Width = 112;
            // 
            // sotiendukien
            // 
            this.sotiendukien.Caption = "Số Tiền Dự Kiến";
            this.sotiendukien.DisplayFormat.FormatString = "0,000";
            this.sotiendukien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.sotiendukien.FieldName = "sotiendukien";
            this.sotiendukien.Name = "sotiendukien";
            this.sotiendukien.Visible = true;
            this.sotiendukien.VisibleIndex = 1;
            this.sotiendukien.Width = 150;
            // 
            // sotiendatietkiem
            // 
            this.sotiendatietkiem.Caption = "Số Tiền Đã Tiết Kiệm";
            this.sotiendatietkiem.FieldName = "sotiendatietkiem";
            this.sotiendatietkiem.Name = "sotiendatietkiem";
            this.sotiendatietkiem.Visible = true;
            this.sotiendatietkiem.VisibleIndex = 2;
            this.sotiendatietkiem.Width = 175;
            // 
            // ngaybatdau
            // 
            this.ngaybatdau.Caption = "Ngày Bắt Đầu";
            this.ngaybatdau.FieldName = "ngaybatdau";
            this.ngaybatdau.Name = "ngaybatdau";
            this.ngaybatdau.Visible = true;
            this.ngaybatdau.VisibleIndex = 3;
            this.ngaybatdau.Width = 165;
            // 
            // ngayketthuc
            // 
            this.ngayketthuc.Caption = "Ngày Kết Thúc";
            this.ngayketthuc.FieldName = "ngayketthuc";
            this.ngayketthuc.Name = "ngayketthuc";
            this.ngayketthuc.Visible = true;
            this.ngayketthuc.VisibleIndex = 4;
            this.ngayketthuc.Width = 141;
            // 
            // trangthai
            // 
            this.trangthai.Caption = "Trạng Thái";
            this.trangthai.FieldName = "trangthai";
            this.trangthai.Name = "trangthai";
            this.trangthai.Visible = true;
            this.trangthai.VisibleIndex = 5;
            this.trangthai.Width = 191;
            // 
            // Xoa
            // 
            this.Xoa.ColumnEdit = this.btnXoa;
            this.Xoa.Name = "Xoa";
            this.Xoa.Visible = true;
            this.Xoa.VisibleIndex = 6;
            this.Xoa.Width = 83;
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Name = "btnXoa";
            // 
            // Sua
            // 
            this.Sua.ColumnEdit = this.btnSua;
            this.Sua.Name = "Sua";
            this.Sua.Visible = true;
            this.Sua.VisibleIndex = 7;
            this.Sua.Width = 84;
            // 
            // btnSua
            // 
            this.btnSua.AutoHeight = false;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Name = "btnSua";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // UC_MucDichTietKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "UC_MucDichTietKiem";
            this.Size = new System.Drawing.Size(1675, 880);
            this.Load += new System.EventHandler(this.UC_MucDichTietKiem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnThemMoi;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn maMD;
        private DevExpress.XtraGrid.Columns.GridColumn tenmucdich;
        private DevExpress.XtraGrid.Columns.GridColumn sotiendukien;
        private DevExpress.XtraGrid.Columns.GridColumn sotiendatietkiem;
        private DevExpress.XtraGrid.Columns.GridColumn ngaybatdau;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit btnXoa;
        private DevExpress.XtraGrid.Columns.GridColumn ngayketthuc;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit btnSua;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn trangthai;
        private DevExpress.XtraGrid.Columns.GridColumn Xoa;
        private DevExpress.XtraGrid.Columns.GridColumn Sua;
        private DevExpress.XtraEditors.SimpleButton btnDangTK;
        private DevExpress.XtraEditors.SimpleButton btnTKDaHT;
    }
}
