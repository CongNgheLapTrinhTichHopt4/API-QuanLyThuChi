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
    public class IntroController : Controller
    {
        public string baseAddress = AddressAPI.baseAddress;
        // GET: Intro
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        
    }
}