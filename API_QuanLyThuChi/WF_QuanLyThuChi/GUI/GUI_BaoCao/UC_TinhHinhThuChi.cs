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
using WF_QuanLyThuChi.StaticClass;
using System.Net.Http;

namespace WF_QuanLyThuChi.GUI.GUI_BaoCao
{
    public partial class UC_TinhHinhThuChi : UserControl
    {
        public UC_TinhHinhThuChi()
        {
            InitializeComponent();
        }

        public string baseAddress = "http://localhost:55410/api/";
        string thanhvien = MySession.tendangnhap;
        private void UC_TinhHinhThuChi_Load(object sender, EventArgs e)
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

                        //Hôm nay
                        lblHomNay.Text = "Hôm Nay: "+ res[0].ThoiGian.ToString();
                        lblTongThuHomNay.Text = res[0].TongThu.ToString("N0");
                        lblTongChiHomNay.Text = res[0].TongChi.ToString("N0");

                        //Tuần này
                        lblTuanNay.Text = "Tuần Này: " + res[1].ThoiGian.ToString();
                        lblTongThuTuanNay.Text = res[1].TongThu.ToString("N0");
                        lblTongChiTuanNay.Text = res[1].TongChi.ToString("N0");

                        //Tháng này
                        lblThangNay.Text = "Tháng Này: " + res[2].ThoiGian.ToString();
                        lblTongThuThangNay.Text = res[2].TongThu.ToString("N0");
                        lblTongChiThangNay.Text = res[2].TongChi.ToString("N0");

                        //Năm nay
                        lblNamNay.Text = "Năm Nay: " + res[3].ThoiGian.ToString();
                        lblTongThuNamNay.Text = res[3].TongThu.ToString("N0");
                        lblTongChiNamNay.Text = res[3].TongChi.ToString("N0");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
