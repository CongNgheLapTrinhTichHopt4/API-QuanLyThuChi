using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_QuanLyThuChi.Controllers
{
    public class TestChartController : BaseController
    {
        
        // GET: TestChart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadChart()
        {
            Item item = new Item();
            item.num1 = 20;
            item.num2 = 50;
            item.num3 = 30;

            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}