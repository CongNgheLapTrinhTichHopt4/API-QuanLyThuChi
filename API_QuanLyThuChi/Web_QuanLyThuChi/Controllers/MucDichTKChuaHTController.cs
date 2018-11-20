using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web_QuanLyThuChi.Sessions;
using Data_QLThuChi.Entities;

namespace Web_QuanLyThuChi.Controllers
{
    public class MucDichTKChuaHTController : BaseController
    {
        public string baseAddress = "http://localhost:55410/api/";
        public ActionResult Index()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                List<MucDichTK_ChuaHT> md = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"MucDichTKChuaHT?thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<MucDichTK_ChuaHT>>();
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


        public MucDichTK_ChuaHT LayMucDichTKTheoMa(string maMD)
        {
            MucDichTK_ChuaHT md = new MucDichTK_ChuaHT();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"MucDichTKChuaHT?MaMD={maMD}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<MucDichTK_ChuaHT>();
                    readTask.Wait();
                    md = readTask.Result;
                    return md;
                }
            }
            return md;
        }
    }
}
