using Data_QLThuChi.Entities;
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

        public ActionResult Logout()
        {
            Session[Ses_Admin.Admin] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}