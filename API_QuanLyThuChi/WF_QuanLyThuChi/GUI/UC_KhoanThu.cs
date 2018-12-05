using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_QLThuChi.DAO;
using Data_QLThuChi.Entities;
using WF_QuanLyThuChi.StaticClass;
using System.Net.Http;

namespace WF_QuanLyThuChi.GUI
{
    public partial class UC_KhoanThu : UserControl
    {
        public string baseAddress = "http://localhost:55410/api/";
        public UC_KhoanThu()
        {
            InitializeComponent();
        }

        KhoanThu_DAO dao = new KhoanThu_DAO();
        string thanhvien = MySession.tendangnhap;
        private void UC_KhoanThu_Load(object sender, EventArgs e)
        {
            string thoigian = DateTime.Now.ToString("yyyy-MM");
            LoadData(thoigian);
        }

        public void LoadData(string thoigian)
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
                    }
                }
            }
            catch
            {

            }


        }
    }
}
