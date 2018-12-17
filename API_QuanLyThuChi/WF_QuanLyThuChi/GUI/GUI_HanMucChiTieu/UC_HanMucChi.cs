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

namespace WF_QuanLyThuChi.GUI.GUI_HanMucChiTieu
{
    public partial class UC_HanMucChi : UserControl
    {
        public UC_HanMucChi()
        {
            InitializeComponent();
        }

        public string baseAddress = "http://localhost:55410/api/";
        public void LoadData(string thoigian)
        {
            try
            {
                lblHeader.Text = "HẠN MỨC CHI TIÊU " + thoigian;
                string nam = thoigian.Substring(0, 4);
                string thang = thoigian.Substring(5, 2);

                string thanhvien = MySession.tendangnhap;

                List<HanMucChi_View> kt = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"HanMucChi?matv={thanhvien}&thang={thang}&nam={nam}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<HanMucChi_View>>();
                        readTask.Wait();

                        kt = readTask.Result;
                        gridControl1.DataSource = kt;
                    }
                   
                }
            }
            catch
            {
                
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string thoigian = dtpThoiGianXem.Text;
            LoadData(thoigian);
        }

        private void UC_HanMucChi_Load(object sender, EventArgs e)
        {
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
            string thoigian = dtpThoiGianXem.Text;
            LoadData(thoigian);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            HanMuc_Session.themhoacsua = 1; //1 tức là đang thêm
            frmThemHoacSuaHanMuc hm = new frmThemHoacSuaHanMuc();
            hm.ShowDialog();
            string thoigian = dtpThoiGianXem.Text;
            LoadData(thoigian);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int mahm = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString());
            if (MessageBox.Show("Xóa khoản hạn mức", "Bạn có muốn xóa hạn mức không?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var deleteTask = client.DeleteAsync($"HanMucChi/{mahm}");
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã Xóa");
                        string thoigian = dtpThoiGianXem.Text;
                        LoadData(thoigian);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi!");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HanMuc_Session.themhoacsua = 0; //0 tức là đang sửa
            int mahm = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString());
            HanMuc_Session.mahm = mahm;
            frmThemHoacSuaHanMuc hm = new frmThemHoacSuaHanMuc();
            hm.ShowDialog();
            string thoigian = dtpThoiGianXem.Text;
            LoadData(thoigian);
        }

        
    }
}
