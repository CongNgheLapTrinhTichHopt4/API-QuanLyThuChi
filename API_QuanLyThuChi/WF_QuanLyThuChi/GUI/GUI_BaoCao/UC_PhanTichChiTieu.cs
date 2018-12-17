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
    public partial class UC_PhanTichChiTieu : UserControl
    {
        public UC_PhanTichChiTieu()
        {
            InitializeComponent();
        }

        public string baseAddress = "http://localhost:55410/api/";
        string thanhvien = MySession.tendangnhap;
        string thoigian = DateTime.Now.ToString("yyyy-MM");
        private void UserControl1_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "PHÂN TÍCH THU CHI " + DateTime.Now.ToString("MM-yyyy");
            PieCharPhanTichThu();
            PieCharPhanTichChi();
        }

        public void PieCharPhanTichThu()
        {
            try
            {
                Series ser = new Series("Biểu đồ phân tích thu", ViewType.Pie3D);

                List<PhanTichThuChi> res = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"BaoCao?thanhvien={thanhvien}&thoigian={thoigian}&phantichthu=true");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<PhanTichThuChi>>();
                        readTask.Wait();

                        res = readTask.Result;

                        for (int i = 0; i < res.Count; i++)
                        {
                            ser.Points.Add(new SeriesPoint(res[i].Loai, res[i].SoTien));
                        }

                        piechartThu.Series.Add(ser);
                        ser.Label.TextPattern = "{A}: {VP:p0}";
                    }
                    else
                    {
                        MessageBox.Show("Lỗi Server!");
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PieCharPhanTichChi()
        {
            Series ser = new Series("Biểu đồ phân tích chi", ViewType.Pie3D);

            List<PhanTichThuChi> res = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"BaoCao?thanhvien={thanhvien}&thoigian={thoigian}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<PhanTichThuChi>>();
                    readTask.Wait();

                    res = readTask.Result;

                    for (int i = 0; i < res.Count; i++)
                    {
                        ser.Points.Add(new SeriesPoint(res[i].Loai, res[i].SoTien));
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi Server!");
                }
            }

            piechartChi.Series.Add(ser);
            ser.Label.TextPattern = "{A}: {VP:p0}";

            //PieSeriesView view = (PieSeriesView)ser.View;
        }


    }
}
