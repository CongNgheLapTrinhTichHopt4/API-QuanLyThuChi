using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_QLThuChi.Entities;
using System.Net.Http;
using System.Web;
using WF_QuanLyThuChi.StaticClass;

namespace WF_QuanLyThuChi.GUI.GUI_TietKiem
{
    public partial class UC_MucDichTietKiem : UserControl
    {
        public UC_MucDichTietKiem()
        {
            InitializeComponent();
        }

        public string baseAddress = "http://localhost:55410/api/";
        string thanhvien = MySession.tendangnhap;

        private void LoadData()
        {
            try
            {
                List<MucDichTietKiem> md = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"MucDichTietKiem?thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<MucDichTietKiem>>();
                        readTask.Wait();

                        md = readTask.Result;
                        gridControl1.DataSource = md;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UC_MucDichTietKiem_Load(object sender, EventArgs e)
        {
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            LoadData();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            MucDichTietKiem_Session.themhoacsua = 1;
            frmThemHoacSuaMDTK md = new frmThemHoacSuaMDTK();
            md.ShowDialog();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa mục đích tiết kiệm", "Bạn có muốn xóa mục đích tiết kiệm này?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string maMD = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maMD").ToString();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var deleteTask = client.DeleteAsync("MucDichTietKiem?MaMD=" + maMD);
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã xóa!");
                        LoadData();
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
            MucDichTietKiem_Session.themhoacsua = 2;
            string maMD = Convert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maMD").ToString());
            MucDichTietKiem_Session.maMD = maMD;
            frmThemHoacSuaMDTK md = new frmThemHoacSuaMDTK();
            md.ShowDialog();
            LoadData();
        }

        private void LoadDataforMucDichDaHoanThanh()
        {
            try
            {
                List<MucDichTietKiem> md = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"MucDichTKHT?thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<MucDichTietKiem>>();
                        readTask.Wait();

                        md = readTask.Result;
                        gridControl1.DataSource = md;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDataforMucDichChuaHT()
        {
            try
            {
                List<MucDichTK_ChuaHT> md = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"MucDichTKChuaHT?thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<MucDichTK_ChuaHT>>();
                        readTask.Wait();

                        md = readTask.Result;
                        gridControl1.DataSource = md;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnTKDaHT_Click(object sender, EventArgs e)
        {
            LoadDataforMucDichDaHoanThanh();
        }

        private void btnDangTK_Click(object sender, EventArgs e)
        {
            LoadDataforMucDichChuaHT();
           
        }
    }
}
