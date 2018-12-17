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

namespace WF_QuanLyThuChi.GUI.GUI_BaoCao
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public string baseAddress = "http://localhost:55410/api/";
        private void UserControl1_Load(object sender, EventArgs e)
        {
            Series ser = new Series("Pie chart", ViewType.Pie);

            List<PhanTichThuChi> res = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"BaoCao?thanhvien=tuanvm1&thoigian=2018-12");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<PhanTichThuChi>>();
                    readTask.Wait();

                    res = readTask.Result;
                    
                    for(int i=0; i< res.Count; i++)
                    {
                        ser.Points.Add(new SeriesPoint(res[i].Loai, res[i].SoTien));
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi Server!");
                }
            }

            chartControl1.Series.Add(ser);
            ser.Label.TextPattern = "{A}: {VP:p0}";

            PieSeriesView view = (PieSeriesView)ser.View;
        }
    }
}
