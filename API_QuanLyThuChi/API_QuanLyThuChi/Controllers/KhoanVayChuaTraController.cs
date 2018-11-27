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
    public class KhoanVayChuaTraController : ApiController
    {
        KhoanVayChuaTra_DAO dao = new KhoanVayChuaTra_DAO();

        public IHttpActionResult GetVT(string thanhvien)
        {
            List<KhoanVayChuaTra> list = dao.GetKhoanVayChuaTra(thanhvien);

            return Ok(list);
        }
    }
}
