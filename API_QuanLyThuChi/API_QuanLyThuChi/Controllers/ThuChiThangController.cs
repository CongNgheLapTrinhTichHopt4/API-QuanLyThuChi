using Data_QLThuChi.DAO;
using Data_QLThuChi.Entities.thongke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_QuanLyThuChi.Controllers
{
    public class ThuChiThangController : ApiController
    {
        Home_DAO dao = new Home_DAO();
        public IHttpActionResult Get_TongThuChiThangNay(string thanhvien)
        {
            TongThuChi res = dao.TongThuChiThangNay(thanhvien);
            if(res == null)
            {
                return NotFound();
            }

            return Json(res);
        }
    }
}
