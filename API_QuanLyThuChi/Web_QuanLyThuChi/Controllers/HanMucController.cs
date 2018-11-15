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
    public class HanMucController : BaseController
    {
        public string baseAddress = "http://localhost:55410/api/";
        // GET: HanMuc
        public ActionResult IndexHanMuc()
        {
            try
            {
                string thang = DateTime.Now.Month.ToString();
                string nam = DateTime.Now.Year.ToString();
                string thoigian = nam + "-" + thang;

                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                List<HanMucChi_View> kt = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"HanMucChi?matv={thanhvien}&thoigian={thoigian}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<HanMucChi_View>>();
                        readTask.Wait();

                        kt = readTask.Result;
                        return View(kt);
                    }
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public void LoadDataForComboLKC()
        {
            try
            {
                List<LoaiKhoanChi> lkc = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"LoaiKhoanChi");
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
            catch
            {
            }
        }

        [HttpGet]
        public ActionResult ThemHanMuc()
        {
            LoadDataForComboLKC();
            return View();
        }

        [HttpPost]
        public ActionResult ThemHanMuc(int loaikc, int hanmuc, string thoigian)
        {
            HanMucChi hmc = new HanMucChi();
            hmc.matv = (string)Session[Ses_Admin.Admin];
            hmc.loaikhoanchi = loaikc;
            hmc.hanmuc = hanmuc;
            hmc.thoigian = thoigian;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<HanMucChi>("HanMucChi", hmc);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("IndexHanMuc");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được!");
                }
            }
            return RedirectToAction("IndexHanMuc");
        }

        public HanMucChi GetHanMucChiTheoId(int id)
        {
            HanMucChi hmc = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"HanMucChi/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<HanMucChi>();
                    readTask.Wait();

                    hmc = readTask.Result;
                    return hmc;
                }
                return null;
            }
        }

        [HttpGet]
        public ActionResult SuaHanMuc(int id)
        {
            LoadDataForComboLKC();
            HanMucChi res = GetHanMucChiTheoId(id);
            return View(res);
        }

        [HttpPost]
        public ActionResult SuaHanMuc(int id, int loaikc, int hanmuc, string thoigian)
        {
            HanMucChi hmc = new HanMucChi();
            hmc.id = id;
            hmc.matv = (string)Session[Ses_Admin.Admin];
            hmc.loaikhoanchi = loaikc;
            hmc.hanmuc = hanmuc;
            hmc.thoigian = thoigian;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<HanMucChi>("HanMucChi", hmc);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("IndexHanMuc");
                }
                else
                {
                    ModelState.AddModelError("", "Không sửa được!");
                }
            }
            return RedirectToAction("IndexHanMuc");
        }

    }
}