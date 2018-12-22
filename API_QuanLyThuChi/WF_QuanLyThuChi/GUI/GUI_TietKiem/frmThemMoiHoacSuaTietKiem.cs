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

namespace WF_QuanLyThuChi.GUI.GUI_TietKiem
{
    public partial class frmThemMoiHoacSuaTietKiem : Form
    {
        public frmThemMoiHoacSuaTietKiem()
        {
            InitializeComponent();
        }
        public string baseAddress = "http://localhost:55410/api/";
        string thanhvien = MySession.tendangnhap;

        public void LoadDataForMucDich(string matv)
        {
            List<MucDichTietKiem> md = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                var responseTask = client.GetAsync($"TietKiem?loaddata=true&matv={matv}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<MucDichTietKiem>>();
                    readTask.Wait();
                    md = readTask.Result;

                    cboMucDich.DataSource = md;
                    cboMucDich.DisplayMember = "tenmucdich";
                    cboMucDich.ValueMember = "maMD";
                }
            }
        }

        public TietKiem LayTKTheoMa(int matk)
        {
            TietKiem tk = new TietKiem();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"TietKiem?MaTK={matk}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TietKiem>();
                    readTask.Wait();

                    tk = readTask.Result;
                    return tk;
                }
            }
            return tk;
        }

        private void frmThemMoiHoacSuaTietKiem_Load(object sender, EventArgs e)
        {
            LoadDataForMucDich(thanhvien);

            if (TietKiem_Session.themhoacsua == 2) // click vào sửa bên UC
            {
                btnThem.Text = "Sửa";
                int matk = TietKiem_Session.matk;
                TietKiem tk = LayTKTheoMa(matk);
                cboMucDich.SelectedValue = tk.mucdich;
                dtpNgay.Value = tk.ngay;
                txtSoTien.Text = tk.sotien.ToString();

            }
            else
            {
                btnThem.Text = "Thêm";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (TietKiem_Session.themhoacsua == 2)
            {

                TietKiem tk = new TietKiem();
                tk.matk = TietKiem_Session.matk;
                tk.matv = MySession.tendangnhap;
                tk.ngay = dtpNgay.Value;
                tk.sotien = Convert.ToInt32(txtSoTien.Text.Trim());
                tk.mucdich = (string)cboMucDich.SelectedValue;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<TietKiem>("TietKiem", tk);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        MessageBox.Show("Đã sửa!");
                    }
                    else
                    {
                        MessageBox.Show("404 Error");
                    }
                }
            }
            else
            {
                TietKiem tk = new TietKiem();
                tk.matk = TietKiem_Session.matk;
                tk.matv = MySession.tendangnhap;
                tk.ngay = dtpNgay.Value;
                tk.sotien = Convert.ToInt32(txtSoTien.Text.Trim());
                tk.mucdich = (string)cboMucDich.SelectedValue;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    var postTask = client.PostAsJsonAsync<TietKiem>("TietKiem", tk);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        MessageBox.Show("Đã thêm!");
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
