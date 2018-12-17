using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_QLThuChi.Entities.thongke;
using System.Net.Http;
using WF_QuanLyThuChi.StaticClass;

namespace WF_QuanLyThuChi.GUI.GUI_BaoCao
{
    public partial class UC_TaiChinhHienTai : UserControl
    {
        public UC_TaiChinhHienTai()
        {
            InitializeComponent();
        }

        public string baseAddress = "http://localhost:55410/api/";
        private void UC_TaiChinhHienTai_Load(object sender, EventArgs e)
        {
            try
            {
                string thanhvien = MySession.tendangnhap;
                List<TaiChinhHienTai> res = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"BaoCao?thanhvien={thanhvien}&taichinh=true");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<TaiChinhHienTai>>();
                        readTask.Wait();

                        res = readTask.Result;

                        lblTienTrongVi.Text = res[0].TienTrongVi.ToString("N0");
                        lblTienTrongATM.Text = res[0].ATM.ToString("N0");
                        lblTongChoVay.Text = res[0].TongChoVay.ToString("N0");
                        lblTongVay.Text = res[0].TongVay.ToString("N0");

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
