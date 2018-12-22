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

namespace WF_QuanLyThuChi.GUI.GUI_KhoanChi
{
    public partial class UC_KhoanChi : UserControl
    {
        public UC_KhoanChi()
        {
            InitializeComponent();
        }
        public string baseAddress = "http://localhost:55410/api/";
        string matv = MySession.tendangnhap;
     
        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            KhoanChi_Session.themhoacsua = 1; // là đang thêm
            frmThemhoacsuaKC kc = new frmThemhoacsuaKC();
            kc.ShowDialog();
            string thoigian = DateTime.Now.ToString("yyyy-MM");
            LoadData(thoigian);
        }
        private void LoadData(string thoigian)
        {
            try
            {
                List<KhoanChi> kc = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"KhoanChi?matv={matv}&thoigian={thoigian}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<KhoanChi>>();
                        readTask.Wait();

                        kc = readTask.Result;
                        gridControl1.DataSource = kc;
                        lblHeader.Text = "QUẢN LÝ KHOẢN CHI " + dtpThoiGianXem.Value.ToString("MM-yyyy");
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            string thoigian = dtpThoiGianXem.Text;
            LoadData(thoigian);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void UC_KhoanChi_Load_1(object sender, EventArgs e)
        {
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
            string thoigian = DateTime.Now.ToString("yyyy-MM");
            LoadData(thoigian);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa khoản thu", "Bạn có muốn xóa khoản chi này?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string makc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "makc").ToString();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var deleteTask = client.DeleteAsync("KhoanChi?MaKC=" + makc);
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
            KhoanChi_Session.themhoacsua = 2;
            int makc = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "makc").ToString());
            KhoanChi_Session.makc = makc;
            frmThemhoacsuaKC kc = new frmThemhoacsuaKC();
            kc.ShowDialog();
            string thoigian = dtpThoiGianXem.Text;
            LoadData(thoigian);
        }

    }
}
