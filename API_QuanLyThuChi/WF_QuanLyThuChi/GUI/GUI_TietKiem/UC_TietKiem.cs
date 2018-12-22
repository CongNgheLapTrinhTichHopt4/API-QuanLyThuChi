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

namespace WF_QuanLyThuChi.GUI.GUI_TietKiem
{
    public partial class UC_TietKiem : UserControl
    {
        public UC_TietKiem()
        {
            InitializeComponent();
        }

        public string baseAddress = "http://localhost:55410/api/";
        string thanhvien = MySession.tendangnhap;

        private void LoadData()
        {
            try
            {
                List<TietKiem> tk = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    var responseTask = client.GetAsync($"TietKiem?thanhvien={thanhvien}");
                    //Hàm này tạm thực thi  cho tới khi phương thức GetAsync() hoàn thành tt và trả về kq
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<TietKiem>>();
                        readTask.Wait();
                        tk = readTask.Result;
                        gridControl1.DataSource = tk;
                    }
                    else
                    {
                        MessageBox.Show("404 Error!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UC_TietKiem_Load(object sender, EventArgs e)
        {
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
            LoadData();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            TietKiem_Session.themhoacsua = 1;// đang thêm
            frmThemMoiHoacSuaTietKiem tk = new frmThemMoiHoacSuaTietKiem();
            tk.ShowDialog();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa khoản tiết kiệm", "Bạn có muốn xóa khoản tiết kiệm này?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string matk = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "matk").ToString();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var deleteTask = client.DeleteAsync("TietKiem?MaTK=" + matk);
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
            TietKiem_Session.themhoacsua = 2;//đang sửa
            int matk = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "matk").ToString());
            TietKiem_Session.matk = matk;
            frmThemMoiHoacSuaTietKiem tk = new frmThemMoiHoacSuaTietKiem();
            tk.ShowDialog();
            LoadData();
        }
    }
}
