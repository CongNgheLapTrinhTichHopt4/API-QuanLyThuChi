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
    public class NguoiVayController : BaseController
    {
        
        public string baseAddress = AddressAPI.baseAddress;
        // GET: NguoiVay
        public ActionResult Index()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                List<NguoiVay> nv = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"NguoiVay");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<NguoiVay>>();
                        readTask.Wait();

                        nv = readTask.Result;
                        return View(nv);
                    }
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ThemNguoiVay()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult ThemNguoiVay(string ten,int sdt)
        {
            NguoiVay nv = new NguoiVay();
         
            nv.ten = ten;
            nv.sdt = sdt;
           

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<NguoiVay>("NguoiVay", nv);
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
            return RedirectToAction("ThemNguoiVay");
        }

        public NguoiVay LayNguoiVayTheoMa(int id)
        {
            NguoiVay kt = new NguoiVay();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"NguoiVay/{id}");
    
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<NguoiVay>();
                    readTask.Wait();

                    kt = readTask.Result;
                    return kt;
                }
            }
            return kt;
        }

        [HttpGet]
        public ActionResult SuaNguoiVay(int id)
        {
            

            NguoiVay res = new NguoiVay();
            res = LayNguoiVayTheoMa(id);

            return View(res);
        }

        [HttpPost]
        public ActionResult SuaNguoiVay(string id,string ten,int sdt)
        {
            NguoiVay nv = new NguoiVay();
            nv.id = id;
            nv.ten = ten;
            nv.sdt = sdt;
           

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<NguoiVay>("NguoiVay", nv);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(nv);
                }
            }
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var deleteTask = client.DeleteAsync("NguoiVay?id=" + id);
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