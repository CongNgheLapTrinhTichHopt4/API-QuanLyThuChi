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

        private void btnKhoanThu_Above_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnMain.Controls.Clear();
            UC_KhoanThu uc = new UC_KhoanThu();
            uc.Dock = DockStyle.Fill;
            pnMain.Controls.Add(uc);
        }

        private void btnKhoanChi_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnKhoanVay__Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnKhoanChoVay_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnNguoiVay_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnMucDichTK_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnTinhHinhThuChi_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnTaiChinhHienTai_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnPhanTichThuChi_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnTienIch_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnPhanHoi__Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnNgonNgu_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnDongTienChinh_Above_ItemClick(object sender, ItemClickEventArgs e)
        {

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
        }
    }
}