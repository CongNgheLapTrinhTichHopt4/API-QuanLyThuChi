using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Web_QuanLyThuChi.Controllers
{
    public class TraNoController : BaseController
    {
        public string baseAddress = "http://localhost:55410/api/";
        // GET: TraNo
        [HttpGet]
        public ActionResult NguoiVayTraNo(int id)
        {
            Session["IdKhoanNo"] = id;
            KhoanChoVay kt = new KhoanChoVay();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"TraNo/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<KhoanChoVay>();
                    readTask.Wait();

                    kt = readTask.Result;
                    return View(kt);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult NguoiVayTraNo(DateTime ngaytra, int sotientra, int loaitaikhoan)
        {
            TraNo tn = new TraNo();
            tn.KhoanVay = Convert.ToInt32(Session["IdKhoanNo"]);
            tn.NgayTra = ngaytra;
            tn.SoTienTra = sotientra;
            tn.TaiKhoan = loaitaikhoan;

            int id = Convert.ToInt32(Session["IdKhoanNo"]);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<TraNo>("TraNo", tn);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("NguoiVayTraNo", new { @id = id});
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được!");
                }
            }
            return Redirect("~/Error/Error");
        }

        [HttpGet]
        public ActionResult ToiTraNo(int id)
        {
            Session["IdKhoanNo"] = id;
            KhoanChoVay kt = new KhoanChoVay();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"TraNo/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<KhoanChoVay>();
                    readTask.Wait();

                    kt = readTask.Result;
                    return View(kt);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult ToiTraNo(DateTime ngaytra, int sotientra, int loaitaikhoan)
        {
            TraNo tn = new TraNo();
            tn.KhoanVay = Convert.ToInt32(Session["IdKhoanNo"]);
            tn.NgayTra = ngaytra;
            tn.SoTienTra = sotientra;
            tn.TaiKhoan = loaitaikhoan;

            int id = Convert.ToInt32(Session["IdKhoanNo"]);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<TraNo>("TraNo", tn);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ToiTraNo", new { @id = id });
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được!");
                }
            }
            return Redirect("~/Error/Error");
        }

        public ActionResult XemLichSuTraNo(int id)
        {
            Session["IdKhoanNo"] = id;
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult LichSuTraNo()
        {
            int IdKhoanVay = Convert.ToInt32(Session["IdKhoanNo"]);
            List<TraNo> res = new List<TraNo>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"TraNo?IdKhoanVay={IdKhoanVay}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<TraNo>>();
                    readTask.Wait();

                    res = readTask.Result;

                    return PartialView(res);

                }
                return PartialView();
            }
        }



    }
}