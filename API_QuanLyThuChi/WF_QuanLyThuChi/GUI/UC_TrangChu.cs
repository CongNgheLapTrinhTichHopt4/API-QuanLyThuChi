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
using Data_QLThuChi.Entities.thongke;
using System.Net.Http;
using DevExpress.XtraCharts;

namespace WF_QuanLyThuChi
{
    public partial class UC_TrangChu : UserControl
    {
        public UC_TrangChu()
        {
            InitializeComponent();
        }

        public string baseAddress = "http://localhost:55410/api/";
        string thanhvien = MySession.tendangnhap;
        private void UC_TrangChu_Load(object sender, EventArgs e)
        {
            LoadTongThuChiThang();
            progressBar1.Value = 25;
            LoadViTienVaATM();
            progressBar1.Value = 50;
            LoadBieuDoPhanTichThu();
            progressBar1.Value = 75;
            LoadBieuDoPhanTichChi();
            progressBar1.Value = 100;
        }

        public void LoadTongThuChiThang()
        {
            try
            {
                List<TinhHinhThuChi> res = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"BaoCao?thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<TinhHinhThuChi>>();
                        readTask.Wait();

                        res = readTask.Result;
                        //Tháng này
                        tieudechi.Text = "Tổng Chi: " + res[2].ThoiGian.ToString();
                        tieudethu.Text = "Tổng Thu: " + res[2].ThoiGian.ToString();
                        lblTongThu.Text = res[2].TongThu.ToString("N0");
                        lblTongChi.Text = res[2].TongChi.ToString("N0");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadViTienVaATM()
        {
            try
            {
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string thoigian = DateTime.Now.ToString("yyyy-MM");
        public void LoadBieuDoPhanTichThu()
        {
            try
            {
                Series ser = new Series("Biểu đồ phân tích thu", ViewType.Pie);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadBieuDoPhanTichChi()
        {
            Series ser = new Series("Biểu đồ phân tích chi", ViewType.Pie);

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
        }

    }
}
