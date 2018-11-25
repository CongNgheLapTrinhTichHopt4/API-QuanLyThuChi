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

        [HttpPost]
        public ActionResult ThongKeThuChiTheoNam(string nam)
        {
            Session["NamThongKe"] = nam;
            return View();
        }

        public ActionResult BieuDoCotDoi()
        {
            try
            {
                string nam = Session["NamThongKe"].ToString();
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                List<ThuChiTheoThang> res = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"BaoCao?nam={nam}&thanhvien={thanhvien}");
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
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
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
                        return View(res);
                    }
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }



        public ActionResult PhanTichThuChi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PhanTichThuChiTheoThang(string thoigian)
        {
            Session["ThoigianphantichthuView"] = thoigian;
             string thang = thoigian.Substring(0, 2);
            string nam = thoigian.Substring(3, 4);
            string namthang = nam + "-" + thang;
            Session["Thoigianphantichthu"] = namthang;
            return RedirectToAction("PhanTichThuChi");
        }

        public ActionResult BieuDoTronPhanTichChi()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                string thoigian = Session["Thoigianphantichthu"].ToString();
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

        public ActionResult BieuDoTronPhanTichThu()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                string thoigian = Session["Thoigianphantichthu"].ToString();
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


        public ActionResult TaiChinhHienTai()
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
                        return View(res);
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