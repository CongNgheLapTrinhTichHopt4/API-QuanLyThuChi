namespace WF_QuanLyThuChi.GUI.GUI_KhoanVay_Chovay
{
    partial class UC_KhoanChoVay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_KhoanChoVay));
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ngayvay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nguoivay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sotien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sotiendatra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sotienchuatra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tinhtrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Xoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnXoa = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.Sua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSua = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(709, 6);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(255, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "QUẢN LÝ KHOẢN CHO VAY";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMoi.Image")));
            this.btnThemMoi.Location = new System.Drawing.Point(1536, 0);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(139, 55);
            this.btnThemMoi.TabIndex = 6;
            this.btnThemMoi.Text = "Thêm Mới";
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1675, 767);
            this.panel2.TabIndex = 12;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.btnSua,
            this.btnXoa});
            this.gridControl1.Size = new System.Drawing.Size(1675, 767);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click_1);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.ngayvay,
            this.nguoivay,
            this.sotien,
            this.sotiendatra,
            this.sotienchuatra,
            this.tinhtrang,
            this.Xoa,
            this.Sua});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Danh sách khoản cho vay";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // id
            // 
            this.id.Caption = "Id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.Width = 264;
            // 
            // ngayvay
            // 
            this.ngayvay.Caption = "Ngày vay";
            this.ngayvay.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.ngayvay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ngayvay.FieldName = "ngayvay";
            this.ngayvay.Name = "ngayvay";
            this.ngayvay.Visible = true;
            this.ngayvay.VisibleIndex = 0;
            this.ngayvay.Width = 114;
            // 
            // nguoivay
            // 
            this.nguoivay.Caption = "Người vay";
            this.nguoivay.FieldName = "nguoivay";
            this.nguoivay.Name = "nguoivay";
            this.nguoivay.Visible = true;
            this.nguoivay.VisibleIndex = 1;
            this.nguoivay.Width = 88;
            // 
            // sotien
            // 
            this.sotien.Caption = "Số tiền cho vay";
            this.sotien.DisplayFormat.FormatString = "0.000";
            this.sotien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.sotien.FieldName = "sotien";
            this.sotien.Name = "sotien";
            this.sotien.Visible = true;
            this.sotien.VisibleIndex = 2;
            this.sotien.Width = 146;
            // 
            // sotiendatra
            // 
            this.sotiendatra.Caption = "Số tiền đã trả";
            this.sotiendatra.DisplayFormat.FormatString = "0.000";
            this.sotiendatra.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.sotiendatra.FieldName = "sotiendatra";
            this.sotiendatra.Name = "sotiendatra";
            this.sotiendatra.Visible = true;
            this.sotiendatra.VisibleIndex = 3;
            this.sotiendatra.Width = 153;
            // 
            // sotienchuatra
            // 
            this.sotienchuatra.Caption = "Số tiền chưa trả";
            this.sotienchuatra.DisplayFormat.FormatString = "0.000";
            this.sotienchuatra.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.sotienchuatra.FieldName = "sotienchuatra";
            this.sotienchuatra.Name = "sotienchuatra";
            this.sotienchuatra.Visible = true;
            this.sotienchuatra.VisibleIndex = 4;
            this.sotienchuatra.Width = 156;
            // 
            // tinhtrang
            // 
            this.tinhtrang.Caption = "Tình trạng";
            this.tinhtrang.FieldName = "trangthai";
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Visible = true;
            this.tinhtrang.VisibleIndex = 5;
            this.tinhtrang.Width = 98;
            // 
            // Xoa
            // 
            this.Xoa.Caption = "Xóa";
            this.Xoa.ColumnEdit = this.btnXoa;
            this.Xoa.Name = "Xoa";
            this.Xoa.Visible = true;
            this.Xoa.VisibleIndex = 6;
            this.Xoa.Width = 105;
            // 
            // btnXoa
            // 
            this.btnXoa.AutoHeight = false;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Name = "btnXoa";
            // 
            // Sua
            // 
            this.Sua.Caption = "Sửa";
            this.Sua.ColumnEdit = this.btnSua;
            this.Sua.Name = "Sua";
            this.Sua.Visible = true;
            this.Sua.VisibleIndex = 7;
            this.Sua.Width = 189;
            // 
            // btnSua
            // 
            this.btnSua.AutoHeight = false;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Name = "btnSua";
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnThemMoi);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1675, 55);
            this.panel3.TabIndex = 11;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
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
            this.panel1.TabIndex = 10;
            // 
            // UC_KhoanChoVay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "UC_KhoanChoVay";
            this.Size = new System.Drawing.Size(1675, 866);
            this.Load += new System.EventHandler(this.UC_KhoanChoVay_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblHeader;
        private DevExpress.XtraEditors.SimpleButton btnThemMoi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn ngayvay;
        private DevExpress.XtraGrid.Columns.GridColumn nguoivay;
        private DevExpress.XtraGrid.Columns.GridColumn sotien;
        private DevExpress.XtraGrid.Columns.GridColumn sotiendatra;
        private DevExpress.XtraGrid.Columns.GridColumn sotienchuatra;
        private DevExpress.XtraGrid.Columns.GridColumn tinhtrang;
        private DevExpress.XtraGrid.Columns.GridColumn Xoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit btnXoa;
        private DevExpress.XtraGrid.Columns.GridColumn Sua;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit btnSua;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
    }
}
