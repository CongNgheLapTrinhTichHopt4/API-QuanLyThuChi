using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web_QuanLyThuChi.BaseAddress;
using Web_QuanLyThuChi.Sessions;


namespace Web_QuanLyThuChi.Controllers
{
    public class TongKhoanChoVayTheoNguoiVayController : BaseController
    {
        public string baseAddress = AddressAPI.baseAddress;
        // GET: 
        public ActionResult Index()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                List<TongKhoanChoVayTheoNguoiVay> vt = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"TongKhoanChoVayTheoNguoiVay?thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<TongKhoanChoVayTheoNguoiVay>>();
                        readTask.Wait();

                        vt = readTask.Result;
                        return View(vt);
                    }
                    return Redirect("~/Error/Error");
                }
            }
            catch
            {
                return Redirect("~/Error/Error");
            }
        }
    }
}