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
    public class TongKhoanVayTheoNguoiVayController : ApiController
    {
        TongKhoanVayTheoNguoiVay_DAO dao = new TongKhoanVayTheoNguoiVay_DAO();

        public IHttpActionResult GetVT(string thanhvien)
        {
            List<TongKhoanVayTheoNguoiVay> list = dao.GetKhoanVayTheoNguoiVay(thanhvien);

            return Ok(list);
        }
    }
}
