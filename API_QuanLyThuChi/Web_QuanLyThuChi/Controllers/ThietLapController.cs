using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_QuanLyThuChi.Controllers
{
    public class ThietLapController : BaseController
    {
        // GET: ThietLap
        public ActionResult ThongTinSanPham()
        {
            return View();
        }

        public ActionResult NgonNgu()
        {
            return View();
        }

        public ActionResult DongTienChinh()
        {
            return View();
        }
    }
}