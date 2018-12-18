using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Data_QLThuChi.Entities.thongke;
using System.Net.Http;
using WF_QuanLyThuChi.StaticClass;

namespace WF_QuanLyThuChi.GUI.GUI_BaoCao
{
    public partial class UC_ThuChiTheoNam : UserControl
    {
        public UC_ThuChiTheoNam()
        {
            InitializeComponent();
        }

        public string baseAddress = "http://localhost:55410/api/";
        private void UserControl2_Load(object sender, EventArgs e)
        {
            string nam = DateTime.Now.ToString("yyyy");
            string thanhvien = MySession.tendangnhap;

            lblHeader.Text = "THU CHI TRONG NĂM " + nam;
            Series ser1 = new Series("Thu", ViewType.Bar);
            Series ser2 = new Series("Chi", ViewType.Bar);

            List<ThuChiTheoThang> res = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"BaoCao?nam={nam}&thanhvien={thanhvien}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<ThuChiTheoThang>>();
                    readTask.Wait();

                    res = readTask.Result;
                    for (int i = 0; i < res.Count; i++)
                    {
                        ser1.Points.Add(new SeriesPoint(res[i].thang, res[i].tongthu.ToString("N0")));
                        ser2.Points.Add(new SeriesPoint(res[i].thang, res[i].tongchi.ToString("N0")));
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi Server!");
                }
            }

            chartControl1.Series.Add(ser1);
            chartControl1.Series.Add(ser2);

        }
    }
}
