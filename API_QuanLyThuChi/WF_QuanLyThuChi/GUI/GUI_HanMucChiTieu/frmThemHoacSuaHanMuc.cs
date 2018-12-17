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
using Data_QLThuChi.Entities;
using System.Net.Http;
using WF_QuanLyThuChi.StaticClass;

namespace WF_QuanLyThuChi.GUI.GUI_HanMucChiTieu
{
    public partial class frmThemHoacSuaHanMuc : DevExpress.XtraEditors.XtraForm
    {

        public frmThemHoacSuaHanMuc()
        {
            InitializeComponent();
        }

        public string baseAddress = "http://localhost:55410/api/";
        private void LoadDataForComboLoaiKhoanChi()
        {
            try
            {
                List<LoaiKhoanChi> lkc = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"LoaiKhoanChi");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<LoaiKhoanChi>>();
                        readTask.Wait();

                        lkc = readTask.Result;

                        cboLoaKC.DataSource = lkc;
                        cboLoaKC.DisplayMember = "tenlkc";
                        cboLoaKC.ValueMember = "malkc";
                    }
                }
            }
            catch
            {
            }
        }

        int themhoacsua = HanMuc_Session.themhoacsua;
        private void frmThemHoacSuaHanMuc_Load(object sender, EventArgs e)
        {
            LoadDataForComboLoaiKhoanChi();
           
            if(themhoacsua == 1) //đang thêm
            {
                btnThem.Text = "Thêm";
            }
            else //đang sửa
            {
                btnThem.Text = "Sửa";
                HanMucChi hmc = LayHanMucTheoMa();
                cboLoaKC.SelectedValue = hmc.loaikhoanchi;
                txtHanMuc.Text = Convert.ToString(hmc.hanmuc);
                dtpThangHM.Text = hmc.thoigian;
            }
        }

        private HanMucChi LayHanMucTheoMa()
        {
            int mahm = HanMuc_Session.mahm;
            HanMucChi hmc = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"HanMucChi/{mahm}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<HanMucChi>();
                    readTask.Wait();

                    hmc = readTask.Result;
                    return hmc;
                }
                else
                {
                    return null;
                }             
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (themhoacsua == 1)
            {
                HanMucChi hmc = new HanMucChi();
                hmc.matv = MySession.tendangnhap;
                hmc.loaikhoanchi = (string)cboLoaKC.SelectedValue;
                hmc.hanmuc = Convert.ToInt32(txtHanMuc.Text.Trim());
                hmc.thoigian = dtpThangHM.Text;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<HanMucChi>("HanMucChi", hmc);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã thêm hạn mức!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi Server :(");
                    }
                }
            }
            else
            {
                HanMucChi hmc = new HanMucChi();
                hmc.id = HanMuc_Session.mahm;
                hmc.matv = MySession.tendangnhap;
                hmc.loaikhoanchi = (string)cboLoaKC.SelectedValue;
                hmc.hanmuc = Convert.ToInt32(txtHanMuc.Text.Trim());
                hmc.thoigian = dtpThangHM.Text;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<HanMucChi>("HanMucChi", hmc);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã sửa hạn mức!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi!");
                    }
                }
                
            }
            
        }

        private void txtHanMuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}