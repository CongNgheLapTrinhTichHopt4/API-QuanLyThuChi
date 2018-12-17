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
        public void LoadData()
        {
            try
            {
                string thoigian = dtpThoiGianXem.Text;

                string thanhvien = MySession.tendangnhap;

                List<HanMucChi_View> kt = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"HanMucChi?matv={thanhvien}&thang=12&nam=2018");
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

        private void UC_HanMucChi_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
