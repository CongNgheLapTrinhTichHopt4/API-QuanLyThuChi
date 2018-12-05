using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanLyThuChi.StaticClass;
using Data_QLThuChi.Entities;
using System.Net.Http;

namespace WF_QuanLyThuChi.GUI.GUI_KhoanThu
{
    public partial class UC_KhoanThu : UserControl
    {
        public UC_KhoanThu()
        {
            InitializeComponent();
        }
        public string baseAddress = "http://localhost:55410/api/";
        string thanhvien = MySession.tendangnhap;
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            KhoanThu_Session.themhoacsua = 1; // là đang thêm
            frmThemMoiKhoanThu kt = new frmThemMoiKhoanThu();
            kt.ShowDialog();
            string thoigian = DateTime.Now.ToString("yyyy-MM");
            LoadData(thoigian);
        }

        private void UC_KhoanThu_Load(object sender, EventArgs e)
        {
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
            string thoigian = DateTime.Now.ToString("yyyy-MM");
            LoadData(thoigian);
        }

        private void LoadData(string thoigian)
        {
            try
            {
                List<KhoanThu> kt = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"KhoanThu?thanhvien={thanhvien}&thoigian={thoigian}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<KhoanThu>>();
                        readTask.Wait();

                        kt = readTask.Result;
                        gridControl1.DataSource = kt;
                        lblHeader.Text = "QUẢN LÝ KHOẢN THU "+ dtpThoiGianXem.Value.ToString("MM-yyyy");
                    }
                    else
                    {
                        MessageBox.Show("404 Error!");
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string thoigian = dtpThoiGianXem.Text;
            LoadData(thoigian);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Xóa khoản thu", "Bạn có muốn xóa khoản thu này?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string makt = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "makt").ToString();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var deleteTask = client.DeleteAsync("KhoanThu?MaKT=" + makt);
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã xóa");
                        string thoigian = dtpThoiGianXem.Text;
                        LoadData(thoigian);
                    }
                    else
                    {
                        MessageBox.Show("404 Error!");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KhoanThu_Session.themhoacsua = 2;
            int makt = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "makt").ToString());
            KhoanThu_Session.makt = makt;
            frmThemMoiKhoanThu kt = new frmThemMoiKhoanThu();
            kt.ShowDialog();
            string thoigian = dtpThoiGianXem.Text;
            LoadData(thoigian);
        }
    }
}
