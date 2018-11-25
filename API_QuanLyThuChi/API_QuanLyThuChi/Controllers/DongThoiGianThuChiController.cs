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
    public class DongThoiGianThuChiController : ApiController
    {
        DongThoiGianThuChi_DAO dao = new DongThoiGianThuChi_DAO();
        public IHttpActionResult Get(string matv)
        {
            List<DongThoiGianThuChi> res = dao.DongThoiGianThuChi(matv);
            if(res == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
