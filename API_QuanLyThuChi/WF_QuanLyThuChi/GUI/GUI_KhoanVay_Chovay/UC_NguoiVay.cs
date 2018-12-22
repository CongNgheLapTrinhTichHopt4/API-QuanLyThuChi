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
    public partial class UC_NguoiVay : UserControl
    {
        public UC_NguoiVay()
        {
            InitializeComponent();
        }
        public string baseAddress = "http://localhost:55410/api/";
        public void loadData()
        {
            try
            {
                string thanhvien = MySession.tendangnhap;
                List<NguoiVay> nv = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"NguoiVay");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<NguoiVay>>();
                        readTask.Wait();

                        nv = readTask.Result;
                        gridControl1.DataSource = nv;

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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void UC_NguoiVay_Load(object sender, EventArgs e)
        {
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
            loadData();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            NguoiVay_Session.themhoacsua = 1;// đang thêm
            frmThemHoacSuaNguoiVay nv = new frmThemHoacSuaNguoiVay();
            nv.ShowDialog();
            loadData();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int manv = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString());
            if (MessageBox.Show("Xóa người vay", "Bạn có muốn xóa người vay không?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var deleteTask = client.DeleteAsync("NguoiVay?id="+manv);
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
            NguoiVay_Session.themhoacsua = 0;// đang sửa
            int manv = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString());
            NguoiVay_Session.ma = manv;
            frmThemHoacSuaNguoiVay nv = new frmThemHoacSuaNguoiVay();
            nv.ShowDialog();
            loadData();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
