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
    public class TaiKhoanChiTieuController : ApiController
    {
        TaiKhoanChiTieu_DAO dao = new TaiKhoanChiTieu_DAO();
        public IHttpActionResult GetAll()
        {
            List<TaiKhoanChiTieu> res = dao.GetAll();
            return Ok(res);
        }
    }
}
