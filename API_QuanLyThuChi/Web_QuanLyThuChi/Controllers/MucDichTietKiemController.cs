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
    public class MucDichTietKiemController : BaseController
    {
        public string baseAddress = "http://localhost:55410/api/";

        public ActionResult Index()
        {
            try
            {
                string thanhvien = (string)Session[Sessions.Ses_Admin.Admin];
                List<MucDichTietKiem> md = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //HTTP GET
                    var responseTask = client.GetAsync($"MucDichTietKiem?thanhvien={thanhvien}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<MucDichTietKiem>>();
                        readTask.Wait();

                        md = readTask.Result;
                        return View(md);
                    }
                    return Redirect("~/Error/Error");
                }
            }
            catch

            {
                return Redirect("~/Error/Error");
            }
        }

        [HttpGet]
        public ActionResult ThemMucDichTietKiem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMucDichTietKiem(string maMD, string tenmucdich, int sotiendukien, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            MucDichTietKiem md = new MucDichTietKiem();
            md.matv = (string)Session[Ses_Admin.Admin];
            md.maMD = maMD;
            md.tenmucdich = tenmucdich;
            md.sotiendukien = sotiendukien;
            md.ngaybatdau = ngaybatdau;
            md.ngayketthuc = ngayketthuc;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<MucDichTietKiem>("MucDichTietKiem", md);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                
            }
            return Redirect("~/Error/Error");
        }

        public MucDichTietKiem LayMucDichTKTheoMa(string maMD)
        {
            MucDichTietKiem md = new MucDichTietKiem();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"MucDichTietKiem?MaMD={maMD}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<MucDichTietKiem>();
                    readTask.Wait();
                    md = readTask.Result;
                    return md;
                }
            }
            return md;
        }

        [HttpGet]
        public ActionResult SuaMucDichTietKiem(string maMD)
        {
            MucDichTietKiem res = new MucDichTietKiem();
            res = LayMucDichTKTheoMa(maMD);
            return View(res);
        }

        [HttpPost]
        public ActionResult SuaMucDichTietKiem(string maMD, string tenmucdich, int sotiendukien, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            MucDichTietKiem md = new MucDichTietKiem();
            md.maMD = maMD;
            md.tenmucdich = tenmucdich;
            md.sotiendukien = sotiendukien;
            md.ngaybatdau = ngaybatdau;
            md.ngayketthuc = ngayketthuc;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<MucDichTietKiem>("MucDichTietkiem", md);
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

        public ActionResult Delete(string maMD)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var deleteTask = client.DeleteAsync("MucDichTietKiem?MaMD=" + maMD);
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
