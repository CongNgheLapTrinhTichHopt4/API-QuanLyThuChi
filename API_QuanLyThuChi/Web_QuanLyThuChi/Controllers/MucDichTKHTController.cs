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
    public class MucDichTKHTController : BaseController
    {
        public string baseAddress = AddressAPI.baseAddress;

        public ActionResult Index()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                List<MucDichTietKiem> md = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"MucDichTKHT?thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<MucDichTietKiem>>();
                        readTask.Wait();

                        md = readTask.Result;
                        return View(md);
                    }
                    return View();
                }
            }
            catch

            {
                return View();
            }
        }
    }
}
