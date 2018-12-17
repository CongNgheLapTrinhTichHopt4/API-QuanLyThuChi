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
    public class KhoanChiController : BaseController
    {
        public string baseAddress = AddressAPI.baseAddress;
        // GET: KhoanChi
        public ActionResult IndexKhoanChi()
        {
            try
            {
                string matv = (string)Session[Sessions.Ses_Admin.Admin];
                string thoigian = Session["Thoigianxemkhoanchi"].ToString();
                string thang = thoigian.Substring(0, 2);
                string nam = thoigian.Substring(3, 4);
                string namthang = nam + "-" + thang;

                List<KhoanChi> kc = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"KhoanChi?matv={matv}&thoigian={namthang}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<KhoanChi>>();
                        readTask.Wait();

                        kc = readTask.Result;
                        return View(kc);
                    }
                    return Redirect("~/Error/Error");
                }
            }
            catch
            {
                return Redirect("~/Error/Error");
            }
        }

        [HttpPost]
        public ActionResult XemKhoanChiTheoThang(string thoigian)
        {
            Session["Thoigianxemkhoanchi"] = thoigian;
            return Redirect("~/KhoanChi/IndexKhoanChi");
        }

        [ChildActionOnly]
        public PartialViewResult KhoanChiTrongNgay()
        {
            string a = Convert.ToDateTime(Session["NgayXemThuChi"]).ToString("yyyy-MM-dd");
            string username = (string)Session[Ses_Admin.Admin];
            List<KhoanChi> kt = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GETKhoanChiTrongNgay?matv=tuanvm1&ngay=2018-11-21
                var responseTask = client.GetAsync($"KhoanChiTrongNgay?matv={username}&ngay={a}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<KhoanChi>>();
                    readTask.Wait();

                    kt = readTask.Result;

                    return PartialView(kt);

                }
                return PartialView();
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

        public void LoadDataForComboLKC()
        {
            List<LoaiKhoanChi> lkc = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhoanChi?loaddata={true}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<LoaiKhoanChi>>();
                    readTask.Wait();

                    lkc = readTask.Result;

                    ViewBag.LoaiKhoanChi = lkc;
                }
            }
        }

        [HttpGet]
        public ActionResult ThemKhoanChi()
        {
            LoadDataForComboLKC();
            LoadDataForComboLoaiTaiKhoan();
            return View();
        }

        [HttpPost]
        public ActionResult ThemKhoanChi(DateTime ngaythem, string loaikc, int sotien, string ghichu, string loaitaikhoan)
        {
            KhoanChi kc = new KhoanChi();
            kc.matv = (string)Session[Ses_Admin.Admin];
            kc.ngay = ngaythem;
            kc.loaikc = loaikc;

            kc.sotien = sotien;
            kc.ghichu = ghichu;
            kc.tutaikhoan = loaitaikhoan;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<KhoanChi>("KhoanChi", kc);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("IndexKhoanChi");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được!");
                }
            }
            return Redirect("~/Error/Error");
        }

        public ActionResult Delete(int makc)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var deleteTask = client.DeleteAsync("KhoanChi?MaKC=" + makc);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Redirect("~/Error/Error");
                }
            }
            return Redirect("~/Error/Error");
        }

        public KhoanChi LayKhoanChiTheoMa(int makc)
        {
            KhoanChi kc = new KhoanChi();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhoanChi?MaKC={makc}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<KhoanChi>();
                    readTask.Wait();

                    kc = readTask.Result;
                    return kc;
                }
            }
            return kc;
        }

        [HttpGet]
        public ActionResult SuaKhoanChi(int makc)
        {
            LoadDataForComboLKC();
            LoadDataForComboLoaiTaiKhoan();
            KhoanChi res = new KhoanChi();
            res = LayKhoanChiTheoMa(makc);

            return View(res);
        }

        [HttpPost]
        public ActionResult SuaKhoanChi(int makc, DateTime ngaythem, string loaikc, int sotien, string ghichu, string loaitaikhoan)
        {
            KhoanChi kc = new KhoanChi();
            kc.makc = makc;
            kc.ngay = ngaythem;
            kc.loaikc = loaikc;

            kc.sotien = sotien;
            kc.ghichu = ghichu;
            kc.tutaikhoan = loaitaikhoan;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<KhoanChi>("KhoanChi", kc);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Redirect("~/Error/Error");
                }
            }
        }
        // GET: KhoanChi

    }
}