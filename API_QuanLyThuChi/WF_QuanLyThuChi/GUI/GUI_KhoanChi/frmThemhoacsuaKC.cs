using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WF_QuanLyThuChi.StaticClass;
using Data_QLThuChi.Entities;
using System.Net.Http;

namespace WF_QuanLyThuChi.GUI.GUI_KhoanChi
{
    public partial class frmThemhoacsuaKC : DevExpress.XtraEditors.XtraForm
    {
        public frmThemhoacsuaKC()
        {
            InitializeComponent();
        }
        public string baseAddress = "http://localhost:55410/api/";
        string matv = MySession.tendangnhap;

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KhoanChi_Session.themhoacsua == 2)
            {
                KhoanChi kc = new KhoanChi();
                kc.loaikc = (string)cboLoaiKC.SelectedValue;
                kc.ngay = dtpNgay.Value;
                kc.sotien = Convert.ToInt32(txtSoTien.Text.Trim());
                kc.ghichu = txtGhiChu.Text.Trim();
                kc.tutaikhoan = (string)cboTaiKhoan.SelectedValue;
                kc.makc = KhoanChi_Session.makc;
                kc.matv = matv;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<KhoanChi>("KhoanChi", kc);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã Sửa!");
                    }
                    else
                    {
                        MessageBox.Show("404 Error");
                    }
                }
            }
            else
            {
                KhoanChi kc = new KhoanChi();
                kc.loaikc = (string)cboLoaiKC.SelectedValue;
                kc.ngay = dtpNgay.Value;
                kc.sotien = Convert.ToInt32(txtSoTien.Text.Trim());
                kc.ghichu = txtGhiChu.Text.Trim();
                kc.tutaikhoan = (string)cboTaiKhoan.SelectedValue;
                kc.matv = matv;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<KhoanChi>("KhoanChi", kc);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã Thêm!");
                    }
                    else
                    {
                        MessageBox.Show("404 Error");
                    }
                }
            }
        }
        public KhoanChi LayKhoanChiTheoMa(int makc)
        {
            KhoanChi kc = new KhoanChi();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhoanChi?MaKC={makc}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<KhoanChi>();
                    readTask.Wait();

                    kc = readTask.Result;
                    return kc;
                }
            }
            return kc;
        }

        public void LoadDataForComboLKC()
        {
            List<LoaiKhoanChi> lkc = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhoanChi?loaddata={true}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<LoaiKhoanChi>>();
                    readTask.Wait();

                    lkc = readTask.Result;

                    cboLoaiKC.DataSource = lkc;
                    cboLoaiKC.DisplayMember = "tenlkc";
                    cboLoaiKC.ValueMember = "malkc";
                }
            }
        }

        public void LoadDataForComboLoaiTaiKhoan()
        {
            List<TaiKhoanChiTieu> tkct = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("TaiKhoanChiTieu");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<TaiKhoanChiTieu>>();
                    readTask.Wait();

                    tkct = readTask.Result;
                    cboTaiKhoan.DataSource = tkct;
                    cboTaiKhoan.DisplayMember = "tentaikhoan";
                    cboTaiKhoan.ValueMember = "id";
                }
            }
        }
        private void frmThemhoacsuaKC_Load(object sender, EventArgs e)
        {
            LoadDataForComboLKC();
            LoadDataForComboLoaiTaiKhoan();

            if (KhoanChi_Session.themhoacsua == 2)
            {
                btnThem.Text = "Sửa";
                int makc = KhoanChi_Session.makc;
                KhoanChi kc = LayKhoanChiTheoMa(makc);
                cboLoaiKC.SelectedValue = kc.loaikc;
                dtpNgay.Value = kc.ngay;
                txtSoTien.Text = kc.sotien.ToString();
                txtGhiChu.Text = kc.ghichu;
                cboTaiKhoan.SelectedValue = kc.tutaikhoan;
            }
            else
            {
                btnThem.Text = "Thêm";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}