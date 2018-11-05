using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Web_QuanLyThuChi.Controllers
{
    public class KhoanThuController : BaseController
    {
        public string baseAddress = "http://localhost:55410/api/";
        // GET: KhoanThu
        public ActionResult Index()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                List<KhoanThu> kt = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"KhoanThu?thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<KhoanThu>>();
                        readTask.Wait();

                        kt = readTask.Result;
                        return View(kt);
                    }
                    return View(); 
                }
            }
            catch
            {
                return View();
            }
        }

        public void LoadDataForComboLoaiTaiKhoan()
        {
            List<TaiKhoanChiTieu> tkct = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("TaiKhoanChiTieu");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<TaiKhoanChiTieu>>();
                    readTask.Wait();

                    tkct = readTask.Result;
                    ViewBag.LoaiTaiKhoan = tkct;
                }
            }
        }

        public void LoadDataForComboLKT()
        {
            List<LoaiKhoanThu> lkt = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhoanThu?loaddata={true}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<LoaiKhoanThu>>();
                    readTask.Wait();

                    lkt = readTask.Result;

                    ViewBag.LoaiKhoanThu = lkt;
                }
            }
        }

        [HttpGet]
        public ActionResult ThemKhoanThu()
        {
            LoadDataForComboLKT();
            LoadDataForComboLoaiTaiKhoan();
            return View();
        }

        [HttpPost]
        public ActionResult ThemKhoanThu(string thanhvien, DateTime ngay, string loaikt, string khoanthu, float sotien, string ghichu)
        {
            KhoanThu kt = new KhoanThu();
            kt.matv = thanhvien;
            kt.ngay = ngay;
            kt.loaikt = loaikt;
            kt.khoanthu = khoanthu;
            kt.sotien = sotien;
            kt.ghichu = ghichu;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<KhoanThu>("KhoanThu", kt);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return View();
                }
                else
                {
                    //MessageBox.Show(":(");
                }
            }
            return View();
        }

    }
}