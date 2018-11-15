using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data_QLThuChi.DAO;
using Data_QLThuChi.Entities;

namespace API_QuanLyThuChi.Controllers
{
    public class LoaiKhoanChiController : ApiController
    {
        LoaiKhoanChi_DAO dao = new LoaiKhoanChi_DAO();
        public IHttpActionResult GetLoaiKhoanChi()
        {
            List<LoaiKhoanChi> res = dao.GetLoaiKhoanChi();
            return Ok(res);
        }
    }
}
