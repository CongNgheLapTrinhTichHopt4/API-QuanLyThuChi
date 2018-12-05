using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanLyThuChi.StaticClass;

namespace WF_QuanLyThuChi.GUI.GUI_KhoanThu
{
    public partial class frmThemMoiKhoanThu : Form
    {
        public frmThemMoiKhoanThu()
        {
            InitializeComponent();
        }

        public string baseAddress = "http://localhost:55410/api/";
        string thanhvien = MySession.tendangnhap;
        private void frmThemMoiKhoanThu_Load(object sender, EventArgs e)
        {
            LoadDataForComboLKT();
            LoadDataForComboLoaiTaiKhoan();

            if (KhoanThu_Session.themhoacsua == 2)
            {
                btnThem.Text = "Sửa";
                int makt = KhoanThu_Session.makt;
                KhoanThu kt = LayKhoanThuTheoMa(makt);
                cboLoaiKT.SelectedValue = kt.loaikt;
                dtpNgay.Value = kt.ngay;
                txtSoTien.Text = kt.sotien.ToString();
                txtGhiChu.Text = kt.ghichu;
                cboTaiKhoan.SelectedValue = kt.dentaikhoan;
            }
            else
            {
                btnThem.Text = "Thêm";
            }
            
        }

        public KhoanThu LayKhoanThuTheoMa(int makt)
        {
            KhoanThu kt = new KhoanThu();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhoanThu?MaKT={makt}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<KhoanThu>();
                    readTask.Wait();

                    kt = readTask.Result;
                    return kt;
                }
            }
            return kt;
        }

        public void LoadDataForComboLKT()
        {
            List<LoaiKhoanThu> lkt = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhoanThu?loaddata={true}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<LoaiKhoanThu>>();
                    readTask.Wait();

                    lkt = readTask.Result;

                    cboLoaiKT.DataSource = lkt;
                    cboLoaiKT.DisplayMember = "tenlkt";
                    cboLoaiKT.ValueMember = "malkt";
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KhoanThu_Session.themhoacsua == 2)
            {
                KhoanThu kt = new KhoanThu();
                kt.loaikt = (string)cboLoaiKT.SelectedValue;
                kt.ngay = dtpNgay.Value;
                kt.sotien = Convert.ToInt32(txtSoTien.Text.Trim());
                kt.ghichu = txtGhiChu.Text.Trim();
                kt.dentaikhoan = (string)cboTaiKhoan.SelectedValue;
                kt.makt = KhoanThu_Session.makt;
                kt.matv = thanhvien;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<KhoanThu>("KhoanThu", kt);
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
                KhoanThu kt = new KhoanThu();
                kt.loaikt = (string)cboLoaiKT.SelectedValue;
                kt.ngay = dtpNgay.Value;
                kt.sotien = Convert.ToInt32(txtSoTien.Text.Trim());
                kt.ghichu = txtGhiChu.Text.Trim();
                kt.dentaikhoan = (string)cboTaiKhoan.SelectedValue;
                kt.matv = thanhvien;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<KhoanThu>("KhoanThu", kt);
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
