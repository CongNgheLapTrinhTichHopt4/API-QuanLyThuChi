using Data_QLThuChi.Entities.thongke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Web_QuanLyThuChi.Controllers
{
    public class BaoCaoController : BaseController
    {
        public string baseAddress = "http://localhost:55410/api/";
        // GET: BaoCao
        public ActionResult ThongKeThuChiTheoNam()
        {
            return View();
        }

        public ActionResult BieuDoCotDoi()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                List<ThuChiTheoThang> res = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"BaoCao?nam=2018&thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<ThuChiTheoThang>>();
                        readTask.Wait();

                        res = readTask.Result;
                        return Json(res, JsonRequestBehavior.AllowGet);
                    }
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult TinhHinhThuChi()
        {
            return View();
        }

    }
}