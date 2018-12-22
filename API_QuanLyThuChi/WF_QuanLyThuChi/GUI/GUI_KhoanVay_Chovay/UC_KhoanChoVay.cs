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

namespace WF_QuanLyThuChi.GUI.GUI_KhoanVay_Chovay
{
    public partial class UC_KhoanChoVay : UserControl
    {
        public UC_KhoanChoVay()
        {
            InitializeComponent();
        }
        public string baseAddress = "http://localhost:55410/api/";
        public void loadData()
        {

            try
            {
                string thanhvien = MySession.tendangnhap;
                List<KhoanChoVay> vt = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"KhoanChoVay?thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<KhoanChoVay>>();
                        readTask.Wait();

                        vt = readTask.Result;
                        gridControl1.DataSource = vt;

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

        private void UC_KhoanChoVay_Load(object sender, EventArgs e)
        {
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
            loadData();

        }

       
        private void btnThemMoi_Click_1(object sender, EventArgs e)
        {
            KhoanChoVay_Session.themhoacsua = 1;// đang thêm
            frmThemHoacSuaKhoanChoVay nv = new frmThemHoacSuaKhoanChoVay();
            nv.ShowDialog();
            loadData();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int makv = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString());
            if (MessageBox.Show("Xóa khoản cho vay", "Bạn có muốn xóa khoản cho vay không?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var deleteTask = client.DeleteAsync("KhoanChoVay?id="+makv);
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã Xóa");
                        loadData();
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
            KhoanChoVay_Session.themhoacsua = 0;// đang sửa
            int makv = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString());
            KhoanChoVay_Session.ma = makv;
            frmThemHoacSuaKhoanChoVay nv = new frmThemHoacSuaKhoanChoVay();
            nv.ShowDialog();
            loadData();
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
