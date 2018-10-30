using Data_QLThuChi.DAO;
using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_QuanLyThuChi.Controllers
{
    public class KhoanChiController : ApiController
    {
        KhoanChi_DAO dao = new KhoanChi_DAO();
        public IHttpActionResult GetKhoanChi(string matv, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            List<KhoanChi> list = dao.GetKhoanChi(matv, ngaybatdau, ngayketthuc);

            if (list.Count <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(list);
            }
        }
    }
}
