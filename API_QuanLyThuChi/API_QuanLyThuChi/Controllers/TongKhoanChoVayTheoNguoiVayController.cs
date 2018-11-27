using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data_QLThuChi.DAO;
using System.Data;
using Data_QLThuChi.Entities;


namespace API_QuanLyThuChi.Controllers
{
    public class TongKhoanChoVayTheoNguoiVayController : ApiController
    {
        TongKhoanChoVayTheoNguoiVay_DAO dao = new TongKhoanChoVayTheoNguoiVay_DAO();

        public IHttpActionResult GetVT(string thanhvien)
        {
            List<TongKhoanChoVayTheoNguoiVay> list = dao.GetKhoanChoVayTheoNguoiVay(thanhvien);

            return Ok(list);
        }
    }
}
