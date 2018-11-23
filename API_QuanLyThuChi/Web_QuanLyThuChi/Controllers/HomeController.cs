using Data_QLThuChi.Entities;
using Data_QLThuChi.Entities.thongke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web_QuanLyThuChi.Sessions;

namespace Web_QuanLyThuChi.Controllers
{
    public class HomeController : BaseController
    {
        public string baseAddress = "http://localhost:55410/api/";
        // GET: Home
        public ActionResult Index()
        {
            //Khi vào trang chủ thì thiết lập thời gian xem luôn
            Session["Thoigianxemkhoanthu"] = DateTime.Now.ToString("MM-yyyy");
            Session["Thoigianphantichthu"] = DateTime.Now.ToString("yyyy-MM");
            Session["ThoigianphantichthuView"] = DateTime.Now.ToString("MM-yyyy");
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult TenHienThi()
        {
            string username = (string)Session[Ses_Admin.Admin];
            ThanhVien tv = new ThanhVien();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"Account?Username={username}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ThanhVien>();
                    readTask.Wait();

                    tv = readTask.Result;

                    Session["TenHienThi"] = tv.tenhienthi;
                    return PartialView();

                }
                return PartialView();
            }
        }

        [ChildActionOnly]
        public PartialViewResult AnhDaiDien()
        {
            string username = (string)Session[Ses_Admin.Admin];
            ThanhVien tv = new ThanhVien();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"Account?Username={username}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ThanhVien>();
                    readTask.Wait();

                    tv = readTask.Result;

                    Session["AnhDaiDien"] = tv.anhdaidien;
                    return PartialView();

                }
                return PartialView();
            }
        }


        [ChildActionOnly]
        public PartialViewResult ViTienVaATM()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
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
                        return PartialView(res);
                    }
                    return PartialView();
                }
            }
            catch
            {
                return PartialView();
            }
        }

        [ChildActionOnly]
        public PartialViewResult TongThuChiThangNay()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                TongThuChi res = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"ThuChiThang?thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<TongThuChi>();
                        readTask.Wait();

                        res = readTask.Result;
                        return PartialView(res);
                    }
                    return PartialView();
                }
            }
            catch
            {
                return PartialView();
            }
        }

        public ActionResult Logout()
        {
            Session[Ses_Admin.Admin] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}