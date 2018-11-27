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
    public class KhoanChiTrongNgayController : ApiController
    {
        KhoanChi_DAO dao = new KhoanChi_DAO();
        public IHttpActionResult GetKhoanChi(string matv, string ngay)
        {
            List<KhoanChi> list = dao.GetKhoanChiTrongNgay(matv, ngay);

            return Ok(list);
        }
    }
}
