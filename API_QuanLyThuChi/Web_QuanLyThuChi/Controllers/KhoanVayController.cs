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
    public class KhoanVayController : BaseController
    {
        public string baseAddress = AddressAPI.baseAddress;
        // GET: KhoanVay_ChoVay


        public ActionResult Index()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                List<KhoanVay> vt = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"KhoanVay?thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<KhoanVay>>();
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
                    ViewBag.TaiKhoanChiTieu = tkct;
                }
            }
        }

        public void LoadDataForComboNguoiVay()
        {
            List<NguoiVay> nv = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("NguoiVay");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<NguoiVay>>();
                    readTask.Wait();

                    nv = readTask.Result;
                    ViewBag.NguoiVay = nv;
                }
            }
        }

        [HttpGet]
        public ActionResult ThemKhoanVay()
        {
            LoadDataForComboLoaiTaiKhoan();
            LoadDataForComboNguoiVay();
           
            return View();
        }
        [HttpPost]
        public ActionResult ThemKhoanVay(DateTime ngayvay, int sotien, string nguoivay, string taikhoanchitieu)
        {
            KhoanVay_ChoVay kt = new KhoanVay_ChoVay();
          
            kt.ngayvay = ngayvay;
            kt.sotien = sotien;
            kt.thanhvien = (string)Session[Ses_Admin.Admin];
            kt.loai = "1";
            kt.nguoivay = nguoivay;
          
            kt.taikhoanchitieu = taikhoanchitieu;
           

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<KhoanVay_ChoVay>("KhoanVay", kt);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được!");
                }
            }
            return RedirectToAction("ThemKhoanVay");
        }

        public KhoanVay_ChoVay LayKhoanVayTheoMa(int id)
        {
            KhoanVay_ChoVay kt = new KhoanVay_ChoVay();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"KhoanVay?id={id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<KhoanVay_ChoVay>();
                    readTask.Wait();

                    kt = readTask.Result;
                    return kt;
                }
            }
            return kt;
        }

        [HttpGet]
        public ActionResult SuaKhoanVay(int id)
        {
            LoadDataForComboLoaiTaiKhoan();
            LoadDataForComboNguoiVay();

            KhoanVay_ChoVay res = new KhoanVay_ChoVay();
            res = LayKhoanVayTheoMa(id);

            return View(res);
        }

        [HttpPost]
        public ActionResult SuaKhoanVay(int id ,DateTime ngayvay, int sotien, string nguoivay, string taikhoanchitieu)
        {
            KhoanVay_ChoVay kt = new KhoanVay_ChoVay();
            kt.id = id;
            kt.ngayvay = ngayvay;
            kt.sotien = sotien;
            kt.thanhvien = (string)Session[Ses_Admin.Admin];
            kt.loai = "1";
            kt.nguoivay = nguoivay;

            kt.taikhoanchitieu = taikhoanchitieu;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<KhoanVay_ChoVay>("KhoanVay", kt);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(kt);
                }
            }
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var deleteTask = client.DeleteAsync("KhoanVay?id=" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {

                }
            }
            return RedirectToAction("Index");
        }
       

    }
}