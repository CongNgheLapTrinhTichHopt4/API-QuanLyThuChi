using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Data_QLThuChi.Entities;
using Web_QuanLyThuChi.Sessions;
using Web_QuanLyThuChi.BaseAddress;

namespace Web_QuanLyThuChi.Controllers
{
    public class TietKiemController : BaseController
    {
        public string baseAddress = AddressAPI.baseAddress;
        //Get: Tiet Kiem
        public ActionResult Index()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                List<TietKiem> tk = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    //Phương thức GetAsync() gửi 1 yêu cầu GET Http tới url đc chỉ định .
                    //Nó trả về 1 nhiệm vụ
                    var responseTask = client.GetAsync($"TietKiem?thanhvien={thanhvien}");
                    //Hàm này tạm thực thi  cho tới khi phương thức GetAsync() hoàn thành tt và trả về kq
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<TietKiem>>();
                        readTask.Wait();
                        tk = readTask.Result;
                        return View(tk);
                    }
                    return Redirect("~/Error/Error");
                }
            }
            catch 
            {
                return Redirect("~/Error/Error");
            }
        }

        public void LoadDataForMucDich(string matv)
        {
            List<MucDichTietKiem> md = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                var responseTask = client.GetAsync($"TietKiem?loaddata=true&matv={matv}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<MucDichTietKiem>>();
                    readTask.Wait();
                    md = readTask.Result;
                    ViewBag.MucDichTietKiem = md;
                }
            }
        }

        [HttpGet]
        public ActionResult ThemTietKiem()
        {
            LoadDataForMucDich((string)Session[Ses_Admin.Admin]);
            return View();
        }

        [HttpPost]
        public ActionResult ThemTietKiem(DateTime ngay, int sotien, string mucdich)
        {
            TietKiem tk = new TietKiem();
            tk.matv = (string)Session[Ses_Admin.Admin];
            tk.ngay = ngay;
            tk.sotien = sotien;
            tk.mucdich = mucdich;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<TietKiem>("TietKiem", tk);
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
            return Redirect("~/Error/Error");
        }

       
        public TietKiem LayTKTheoMa(int matk)
        {
            TietKiem tk = new TietKiem();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"TietKiem?MaTK={matk}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TietKiem>();
                    readTask.Wait();

                    tk = readTask.Result;
                    return tk;
                }
            }
            return tk;
        }

        [HttpGet]
        public ActionResult SuaTietKiem(int matk)
        {
            LoadDataForMucDich((string)Session[Ses_Admin.Admin]);
            TietKiem resp = new TietKiem();
            resp = LayTKTheoMa(matk);
            return View(resp);
        }

        [HttpPost]
        public ActionResult SuaTietKiem(int matk,DateTime ngay, int sotien, string mucdich)
        {
            TietKiem tk = new TietKiem();
            tk.matk = matk;
            tk.ngay = ngay;
            tk.sotien = sotien;
            tk.mucdich = mucdich;
            //  tk.matv = (string)Session[Ses_Admin.Admin];
            //  tk.loai = loai;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<TietKiem>("TietKiem", tk);
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
          //  return RedirectToAction("Index");
        }

        public ActionResult Delete(int matk)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var deleteTask = client.DeleteAsync("TietKiem?MaTK=" + matk);
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
        }
    }
}
