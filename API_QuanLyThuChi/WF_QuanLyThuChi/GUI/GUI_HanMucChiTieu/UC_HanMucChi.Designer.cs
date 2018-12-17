namespace WF_QuanLyThuChi.GUI.GUI_HanMucChiTieu
{
    partial class UC_HanMucChi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_HanMucChi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpThoiGianXem = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loaikc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hanmuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DaTieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.phantram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnXoa = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSua = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSua)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1430, 38);
            this.panel1.TabIndex = 5;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(624, 6);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(181, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "HẠN MỨC CHI TIÊU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thời gian xem";
            // 
            // dtpThoiGianXem
            // 
            this.dtpThoiGianXem.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThoiGianXem.CustomFormat = "yyyy-MM";
            this.dtpThoiGianXem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThoiGianXem.Location = new System.Drawing.Point(82, 17);
            this.dtpThoiGianXem.Name = "dtpThoiGianXem";
            this.dtpThoiGianXem.Size = new System.Drawing.Size(200, 20);
            this.dtpThoiGianXem.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnXem);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnThemMoi);
            this.panel3.Controls.Add(this.dtpThoiGianXem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1430, 55);
            this.panel3.TabIndex = 7;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(288, 17);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 9;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMoi.Image")));
            this.btnThemMoi.Location = new System.Drawing.Point(1308, 0);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(122, 55);
            this.btnThemMoi.TabIndex = 6;
            this.btnThemMoi.Text = "Thêm Mới";
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1430, 769);
            this.panel2.TabIndex = 8;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnXoa,
            this.btnSua});
            this.gridControl1.Size = new System.Drawing.Size(1430, 769);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.loaikc,
            this.hanmuc,
            this.SoTien,
            this.DaTieu,
            this.phantram,
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Hạn mức chi tiêu";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // id
            // 
            this.id.Caption = "Mã Hạn Mức";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // loaikc
            // 
            this.loaikc.Caption = "Loại Khoản Chi";
            this.loaikc.FieldName = "tenlkc";
            this.loaikc.Name = "loaikc";
            this.loaikc.Visible = true;
            this.loaikc.VisibleIndex = 0;
            this.loaikc.Width = 201;
            // 
            // hanmuc
            // 
            this.hanmuc.Caption = "Hạn Mức";
            this.hanmuc.DisplayFormat.FormatString = "0,000";
            this.hanmuc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.hanmuc.FieldName = "hanmuc";
            this.hanmuc.Name = "hanmuc";
            this.hanmuc.Visible = true;
            this.hanmuc.VisibleIndex = 1;
            this.hanmuc.Width = 201;
            // 
            // SoTien
            // 
            this.SoTien.Caption = "Số Tiền Đã Tiêu";
            this.SoTien.DisplayFormat.FormatString = "0,000";
            this.SoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.SoTien.FieldName = "sotien";
            this.SoTien.Name = "SoTien";
            this.SoTien.Visible = true;
            this.SoTien.VisibleIndex = 2;
            this.SoTien.Width = 201;
            // 
            // DaTieu
            // 
            this.DaTieu.Caption = "Số Tiền Còn Lại";
            this.DaTieu.DisplayFormat.FormatString = "0,000";
            this.DaTieu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DaTieu.FieldName = "sotienconlai";
            this.DaTieu.Name = "DaTieu";
            this.DaTieu.Visible = true;
            this.DaTieu.VisibleIndex = 3;
            this.DaTieu.Width = 365;
            // 
            // phantram
            // 
            this.phantram.Caption = "Phần Trăm";
            this.phantram.FieldName = "phantram";
            this.phantram.Name = "phantram";
            this.phantram.Visible = true;
            this.phantram.VisibleIndex = 4;
            this.phantram.Width = 313;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Xóa";
            this.gridColumn1.ColumnEdit = this.btnXoa;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 67;
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Appearance.Image")));
            this.btnXoa.Appearance.Options.UseImage = true;
            this.btnXoa.AutoHeight = false;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Name = "btnXoa";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Sửa";
            this.gridColumn2.ColumnEdit = this.btnSua;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            this.gridColumn2.Width = 64;
            // 
            // btnSua
            // 
            this.btnSua.AutoHeight = false;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Name = "btnSua";
            // 
            // UC_HanMucChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "UC_HanMucChi";
            this.Size = new System.Drawing.Size(1430, 880);
            this.Load += new System.EventHandler(this.UC_HanMucChi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpThoiGianXem;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraEditors.SimpleButton btnThemMoi;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn loaikc;
        private DevExpress.XtraGrid.Columns.GridColumn hanmuc;
        private DevExpress.XtraGrid.Columns.GridColumn SoTien;
        private DevExpress.XtraGrid.Columns.GridColumn DaTieu;
        private DevExpress.XtraGrid.Columns.GridColumn phantram;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit btnXoa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit btnSua;
        private DevExpress.XtraGrid.Columns.GridColumn id;
    }
}
