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

namespace Test_QuanLyThuChi
{
    public partial class Form1 : Form
    {
        public string baseAddress = "http://localhost:55410/api/";
        public Form1()
        {
            InitializeComponent();
        }

        public void BindingData()
        {
            txtMakt.DataBindings.Clear();
            txtMakt.DataBindings.Add("Text", dgvKhoanThu.DataSource, "MaKT");

            //cboMaTV.DataBindings.Clear();
            //cboMaTV.DataBindings.Add("Text", dgvKhoanThu.DataSource, "MaThanhVien");

            dtpNgay.DataBindings.Clear();
            dtpNgay.DataBindings.Add("Text", dgvKhoanThu.DataSource, "Ngay");

            cboLoaiKT.DataBindings.Clear();
            cboLoaiKT.DataBindings.Add("Text", dgvKhoanThu.DataSource, "LoaiKT");

            txtKhoanThu.DataBindings.Clear();
            txtKhoanThu.DataBindings.Add("Text", dgvKhoanThu.DataSource, "KhoanThu");

            txtSoTien.DataBindings.Clear();
            txtSoTien.DataBindings.Add("Text", dgvKhoanThu.DataSource, "SoTien");

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", dgvKhoanThu.DataSource, "GhiChu");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<KhoanThu> kt = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("KhoanThu");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<KhoanThu>>();
                    readTask.Wait();

                    kt = readTask.Result;
                }

                dgvKhoanThu.DataSource = kt;
            }

            BindingData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhoanThu kt = new KhoanThu();
            
            kt.matv = cboMaTV.Text;
            kt.ngay = dtpNgay.Value;
            kt.loaikt = cboLoaiKT.Text;
            kt.khoanthu = txtKhoanThu.Text.Trim();
            float sotien;
            float.TryParse(txtSoTien.Text.Trim(), out sotien);
            kt.sotien = sotien;
            kt.ghichu = txtGhiChu.Text.Trim();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<KhoanThu>("KhoanThu", kt);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm dữ liệu thành công");
                }
                else
                {
                    MessageBox.Show(":(");
                }
            }


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KhoanThu kt = new KhoanThu();
            kt.makt = txtMakt.Text.Trim();
            kt.matv = cboMaTV.Text;
            kt.ngay = dtpNgay.Value;
            kt.loaikt = cboLoaiKT.Text;
            kt.khoanthu = txtKhoanThu.Text.Trim();
            float sotien;
            float.TryParse(txtSoTien.Text.Trim(), out sotien);
            kt.sotien = sotien;
            kt.ghichu = txtGhiChu.Text.Trim();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<KhoanThu>("KhoanThu", kt);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sửa dữ liệu thành công");
                }
                else
                {
                    MessageBox.Show(":(");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string makt = txtMakt.Text.Trim();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var deleteTask = client.DeleteAsync("KhoanThu?MaKT="+makt);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã xóa");
                }
                else
                {
                    MessageBox.Show(":(");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string makt = txtTimKiem.Text.Trim();

            List<KhoanThu> kt = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhoanThu?MaKT={makt}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<KhoanThu>>();
                    readTask.Wait();

                    kt = readTask.Result;
                    MessageBox.Show("Tìm Thấy!");
                    dgvKhoanThu.DataSource = kt;
                }
                else
                {
                    MessageBox.Show("K Thấy!");
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
