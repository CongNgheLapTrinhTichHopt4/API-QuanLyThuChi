using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Web_QuanLyThuChi.Controllers
{
    public class IntroController : Controller
    {
        public string baseAddress = "http://localhost:55410/api/";
        // GET: Intro
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Uname, string Pass)
        {
            int res = 0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"Account?username={Uname}&password={Pass}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();

                    res = readTask.Result;

                    if(res == 1)
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
                return RedirectToAction("Index", "Intro");
            }

        }
    }
}