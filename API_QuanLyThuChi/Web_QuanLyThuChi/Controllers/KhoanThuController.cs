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
    public class KhoanThuController : BaseController
    {
        public string baseAddress = "http://localhost:55410/api/";
        // GET: KhoanThu
        public ActionResult IndexKhoanThu(string thoigian)
        {
            try
            {
                Session["Thoigianxemkhoanthu"] = thoigian;
                string thang = thoigian.Substring(0, 2);
                string nam = thoigian.Substring(3, 4);
                string namthang = nam + "-" + thang;

                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];

                List<KhoanThu> kt = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"KhoanThu?thanhvien={thanhvien}&thoigian={namthang}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<KhoanThu>>();
                        readTask.Wait();

                        kt = readTask.Result;
                        return View(kt);
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
        public ActionResult XemKhoanThuTheoThang(string thoigian)
        {
            return RedirectToAction("IndexKhoanThu", new { @thoigian = thoigian});
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

        public void LoadDataForComboLKT()
        {
            List<LoaiKhoanThu> lkt = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhoanThu?loaddata={true}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<LoaiKhoanThu>>();
                    readTask.Wait();

                    lkt = readTask.Result;

                    ViewBag.LoaiKhoanThu = lkt;
                }
            }
        }

        [HttpGet]
        public ActionResult ThemKhoanThu()
        {
            LoadDataForComboLKT();
            LoadDataForComboLoaiTaiKhoan();
            return View();
        }

        [HttpPost]
        public ActionResult ThemKhoanThu(DateTime ngaythem, string loaikt, int sotien, string ghichu, string loaitaikhoan)
        {
            KhoanThu kt = new KhoanThu();
            kt.matv = (string)Session[Ses_Admin.Admin];
            kt.ngay = ngaythem;
            kt.loaikt = loaikt;
            kt.sotien = sotien;
            kt.ghichu = ghichu;
            kt.dentaikhoan = loaitaikhoan;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<KhoanThu>("KhoanThu", kt);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("IndexKhoanThu", new { @thoigian = DateTime.Now.ToString("MM-yyyy") });
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được!");
                }
            }
            return RedirectToAction("ThemKhoanThu");
        }

        public ActionResult Delete(int makt)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var deleteTask = client.DeleteAsync("KhoanThu?MaKT="+makt);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("IndexKhoanThu", new { @thoigian = DateTime.Now.ToString("MM-yyyy") });
                }
                else
                {
                    return Redirect("~/Error/Error");
                }
            }
            
        }

        public KhoanThu LayKhoanThuTheoMa(int makt)
        {
            KhoanThu kt = new KhoanThu();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhoanThu?MaKT={makt}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<KhoanThu>();
                    readTask.Wait();

                    kt = readTask.Result;
                    return kt;
                }
            }
            return kt;
        }

        [HttpGet]
        public ActionResult SuaKhoanThu(int makt)
        {
            LoadDataForComboLKT();
            LoadDataForComboLoaiTaiKhoan();
            KhoanThu res = new KhoanThu();
            res = LayKhoanThuTheoMa(makt);

            return View(res);
        }

        [HttpPost]
        public ActionResult SuaKhoanThu(int makt, DateTime ngaythem, string loaikt, int sotien, string ghichu, string loaitaikhoan)
        {
            KhoanThu kt = new KhoanThu();
            kt.makt = makt;
            kt.ngay = ngaythem;
            kt.loaikt = loaikt;
            kt.sotien = sotien;
            kt.ghichu = ghichu;
            kt.dentaikhoan = loaitaikhoan;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<KhoanThu>("KhoanThu", kt);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("IndexKhoanThu", new { @thoigian = DateTime.Now.ToString("MM-yyyy") });
                }
                else
                {
                    return Redirect("~/Error/Error");
                }
            }
        }
    }
}