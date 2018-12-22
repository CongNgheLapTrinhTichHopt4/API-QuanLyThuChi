using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using WF_QuanLyThuChi.StaticClass;
using Data_QLThuChi.Entities;
using System.Net.Http;
using WF_QuanLyThuChi.GUI;
using WF_QuanLyThuChi.GUI.GUI_KhoanThu;
using WF_QuanLyThuChi.GUI.GUI_HanMucChiTieu;
using WF_QuanLyThuChi.GUI.GUI_BaoCao;
using WF_QuanLyThuChi.GUI.GUI_ThietLap;
using WF_QuanLyThuChi.GUI.GUI_TietKiem;
using WF_QuanLyThuChi.GUI.GUI_KhoanChi;
using WF_QuanLyThuChi.GUI.GUI_KhoanVay_Chovay;

namespace WF_QuanLyThuChi
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //Menu ngang

        private void btnTrangChu_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_TrangChu uc = new UC_TrangChu();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnTrangCaNhan_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTrangCaNhan tcn = new frmTrangCaNhan();
            tcn.ShowDialog();
            LoadInfoUser();
        }

        private void btnDoiMatKhau_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoiMatKhau tcn = new frmDoiMatKhau();
            tcn.ShowDialog();
            this.Close();
        }

        private void btnKhoanThu_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_KhoanThu uc = new UC_KhoanThu();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnKhoanChi_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_KhoanChi uc = new UC_KhoanChi();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnHanMuc_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_HanMucChi uc = new UC_HanMucChi();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnKhoanVay_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_KhoanVay uc = new UC_KhoanVay();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnKhoanChoVay_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_KhoanChoVay uc = new UC_KhoanChoVay();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnNguoiVay_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_NguoiVay uc = new UC_NguoiVay();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnTietKiem_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_TietKiem uc = new UC_TietKiem();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnMucDichTK_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_MucDichTietKiem uc = new UC_MucDichTietKiem();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnTinhHinhThuChi_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_TinhHinhThuChi uc = new UC_TinhHinhThuChi();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnTaiChinhHienTai_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_TaiChinhHienTai uc = new UC_TaiChinhHienTai();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnPhanTichThuChi_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_PhanTichChiTieu uc = new UC_PhanTichChiTieu();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnThuChiTheoNam_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_ThuChiTheoNam uc = new UC_ThuChiTheoNam();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnTienIch_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnPhanHoi__Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnNgonNgu_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_NgonNgu uc = new UC_NgonNgu();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnDongTienChinh_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_DongTienChinh uc = new UC_DongTienChinh();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnThongTinSP_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void btnDangXuat_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        ///Menu dọc
        ///
        private void btnTrangChu_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_TrangChu uc = new UC_TrangChu();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        //Sự kiện form
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmThoat t = new frmThoat();
            t.ShowDialog();

            if (MyProgram.Exit == 0)
            {
                e.Cancel = true;
            }
            else if (MyProgram.Exit == 1)
            {
                e.Cancel = false;
            }
            else if (MyProgram.Exit == 2)
            {
                e.Cancel = false;
                this.Dispose();
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ThoiGian.Caption = DateTime.Now.ToString();
            float t = pRam.NextValue();
            RAM.Caption = string.Format("{0:00.00}", pRam.NextValue()) + "%";
            CPU.Caption = string.Format("{0:00.00}", pCPU.NextValue()) + "%";
            SUT.Caption = string.Format("{0:00.00}", pSUT.NextValue() / 60 / 60) + " H";
        }

        public string baseAddress = "http://localhost:55410/api/";
        public void LoadInfoUser()
        {
            string username = MySession.tendangnhap;
            ThanhVien tv = new ThanhVien();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"Account?Username={username}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ThanhVien>();
                    readTask.Wait();

                    tv = readTask.Result;
                    MySession.thongtinnguoidung = tv;

                    pcbUser.Image = Image.FromFile(@"..\..\Img\"+tv.anhdaidien);
                    lblUserName.Text = tv.tenhienthi;
                }
                else
                {

                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadInfoUser();
            pnMain.Controls.Clear();
            UC_TrangChu uc = new UC_TrangChu();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        

        private void bbtnTrangCaNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTrangCaNhan tcn = new frmTrangCaNhan();
            tcn.ShowDialog();
            LoadInfoUser();
        }

        private void bbtnDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoiMatKhau tcn = new frmDoiMatKhau();
            tcn.ShowDialog();
            this.Close();
        }

        private void btnTrangCaNhan_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmTrangCaNhan tcn = new frmTrangCaNhan();
            tcn.ShowDialog();
            LoadInfoUser();
        }

        private void btnKhoanThu_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_KhoanThu uc = new UC_KhoanThu();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnKhoanChi_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_KhoanChi uc = new UC_KhoanChi();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnHanMuc_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_HanMucChi uc = new UC_HanMucChi();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnTietKiemLeft_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_TietKiem uc = new UC_TietKiem();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnMucDichTietKiem_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_MucDichTietKiem uc = new UC_MucDichTietKiem();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnTinhHinhThuChi_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_TinhHinhThuChi uc = new UC_TinhHinhThuChi();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnTaiChinhHienTai_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_TaiChinhHienTai uc = new UC_TaiChinhHienTai();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnPhanTichThuChi_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_PhanTichChiTieu uc = new UC_PhanTichChiTieu();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnThuChiTheoNam_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_ThuChiTheoNam uc = new UC_ThuChiTheoNam();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnNgonNgu_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_NgonNgu uc = new UC_NgonNgu();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnDongTien_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_DongTienChinh uc = new UC_DongTienChinh();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnKhoanVay_left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_KhoanVay uc = new UC_KhoanVay();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnChoVay_Left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_KhoanChoVay uc = new UC_KhoanChoVay();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnNguoiVay1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_NguoiVay uc = new UC_NguoiVay();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }
    }
}

