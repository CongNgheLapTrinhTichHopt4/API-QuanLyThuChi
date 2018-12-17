using Data_QLThuChi.Entities.thongke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web_QuanLyThuChi.BaseAddress;

namespace Web_QuanLyThuChi.Controllers
{
    public class DongThoiGianController : BaseController
    {
        public string baseAddress = AddressAPI.baseAddress;
        // GET: DongThoiGian
        public ActionResult Index()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];

                List<DongThoiGianThuChi> res = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"DongThoiGianThuChi?matv={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<DongThoiGianThuChi>>();
                        readTask.Wait();

                        res = readTask.Result;
                        return View(res);
                    }
                    return Redirect("~/Error/Error");
                }
            }
            catch
            {
                return Redirect("~/Error/Error");
            }
        }

        [HttpGet]
        public ActionResult CacKhoanThuChiTrongNgay(DateTime ngay)
        {
            Session["NgayXemThuChi"] = ngay;
            return View(ngay);
        }
    }
}