﻿using System;
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

namespace WF_QuanLyThuChi.GUI.GUI_KhoanVay_Chovay
{
    public partial class frmThemHoacSuaKhoanChoVay : DevExpress.XtraEditors.XtraForm
    {
        public frmThemHoacSuaKhoanChoVay()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadDataForComboLoaiTaiKhoan()
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
        private void LoadDataForComboNguoivay()
        {
            List<NguoiVay> nv = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("NguoiVay");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<NguoiVay>>();
                    readTask.Wait();

                    nv = readTask.Result;
                    cboNguoiVay.DataSource = nv;
                    cboNguoiVay.DisplayMember = "ten";
                    cboNguoiVay.ValueMember = "id";
                }
            }
        }
        int themhoacsua = KhoanChoVay_Session.themhoacsua;
        private void frmThemHoacSuaKhoanChoVay_Load(object sender, EventArgs e)
        {
            LoadDataForComboLoaiTaiKhoan();
            LoadDataForComboNguoivay();
            if (KhoanChoVay_Session.themhoacsua == 1)//vua click them
            {
                btnThem.Text = "Thêm";

            }
            else//vua click sua
            {
                btnThem.Text = "Sửa";
                KhoanVay_ChoVay nv = LaykhoanChoVayTheoMa();
                dtpNgay.Value = nv.ngayvay;
                txtSoTien.Text = Convert.ToString( nv.sotien);
                cboNguoiVay.SelectedValue = nv.nguoivay;
                cboTaiKhoan.SelectedValue = nv.taikhoanchitieu;
                //txtTen.Text = nv.ten;
                //txtSDT.Text = Convert.ToString(nv.sdt);
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
        private KhoanVay_ChoVay LaykhoanChoVayTheoMa()
        {
            int manv = KhoanChoVay_Session.ma;

            KhoanVay_ChoVay kt = new KhoanVay_ChoVay();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhoanChoVay/{manv}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<KhoanVay_ChoVay>();
                    readTask.Wait();

                    kt = readTask.Result;
                    return kt;
                }
                else
                {
                    return null;
                }
            }
           

        }
        public string baseAddress = "http://localhost:55410/api/";
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (themhoacsua == 1)
            {
                KhoanVay_ChoVay kt = new KhoanVay_ChoVay();

                kt.ngayvay = dtpNgay.Value;
                kt.sotien = Convert.ToInt32(txtSoTien.Text.Trim());
                kt.thanhvien =MySession.tendangnhap;
                kt.loai = "2";
                kt.nguoivay = Convert.ToString(cboNguoiVay.SelectedValue);

                kt.taikhoanchitieu = Convert.ToString(cboTaiKhoan.SelectedValue);


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<KhoanVay_ChoVay>("KhoanChoVay", kt);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi");
                    }
                }
               
            }
            else
            {

                KhoanVay_ChoVay kt = new KhoanVay_ChoVay();
                kt.id = KhoanChoVay_Session.ma;
                kt.ngayvay = dtpNgay.Value;
                kt.sotien = Convert.ToInt32(txtSoTien.Text.Trim());
                kt.thanhvien = MySession.tendangnhap;
                kt.loai = "2";
                kt.nguoivay = Convert.ToString(cboNguoiVay.SelectedValue);

                kt.taikhoanchitieu = Convert.ToString(cboTaiKhoan.SelectedValue);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<KhoanVay_ChoVay>("KhoanChoVay", kt);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi");
                    }
                }
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}