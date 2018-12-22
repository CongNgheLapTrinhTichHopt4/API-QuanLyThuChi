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
    public partial class frmThemHoacSuaMDTK : Form
    {
        public frmThemHoacSuaMDTK()
        {
            InitializeComponent();
        }
        public string baseAddress = "http://localhost:55410/api/";
        string thanhvien = MySession.tendangnhap;


        public MucDichTietKiem LayMucDichTKTheoMa(string maMD)
        {
            MucDichTietKiem md = new MucDichTietKiem();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"MucDichTietKiem?MaMD={maMD}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<MucDichTietKiem>();
                    readTask.Wait();
                    md = readTask.Result;
                    return md;
                }
            }
            return md;
        }

        private void frmThemHoacSuaMDTK_Load(object sender, EventArgs e)
        {
            if (MucDichTietKiem_Session.themhoacsua == 2)
            {
                btnThem.Text = "Sửa";
                string maMD = MucDichTietKiem_Session.maMD;
                MucDichTietKiem md = LayMucDichTKTheoMa(maMD);
                txttenmucdich.Text = md.tenmucdich;
                txtSotiendukien.Text = md.sotiendukien.ToString();
                dtpNgaybd.Value = md.ngaybatdau;
                dtpNgaykt.Value = md.ngayketthuc;
               
            }
            else
            {
                btnThem.Text = "Thêm";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MucDichTietKiem_Session.themhoacsua == 2)
            {
                MucDichTietKiem md = new MucDichTietKiem();
                md.maMD = MucDichTietKiem_Session.maMD;
                md.tenmucdich = txttenmucdich.Text.Trim();
                md.ngaybatdau = dtpNgaybd.Value;
                md.ngayketthuc = dtpNgaykt.Value;
                md.matv = MySession.tendangnhap;
                md.sotiendukien = Convert.ToInt32(txtSotiendukien.Text.Trim());
               

                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    var postTask = client.PutAsJsonAsync<MucDichTietKiem>("MucDichTietKiem", md);
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
                MucDichTietKiem md = new MucDichTietKiem();
                md.maMD = MucDichTietKiem_Session.maMD;
                md.tenmucdich = txttenmucdich.Text.Trim();
                md.ngaybatdau = dtpNgaybd.Value;
                md.ngayketthuc = dtpNgaykt.Value;
                md.matv = MySession.tendangnhap;
                md.sotiendukien = Convert.ToInt32(txtSotiendukien.Text.Trim());
               

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    var postTask = client.PostAsJsonAsync<MucDichTietKiem>("MucDichTietKiem", md);
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

        private void txtSotiendukien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
    }
}
