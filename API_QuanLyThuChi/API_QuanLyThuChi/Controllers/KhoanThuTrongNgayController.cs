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
    public class KhoanThuTrongNgayController : ApiController
    {
        KhoanThu_DAO dao = new KhoanThu_DAO();
        public IHttpActionResult GetKTNgay(string thanhvien, string ngay)
        {
            List<KhoanThu> list = dao.GetKhoanThuTrongNgay(thanhvien, ngay);

            return Ok(list);
        }
    }
}
