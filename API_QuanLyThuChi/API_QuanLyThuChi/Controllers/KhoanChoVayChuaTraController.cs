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
    public class KhoanChoVayChuaTraController : ApiController
    {
        KhoanChoVayChuaTra_DAO dao = new KhoanChoVayChuaTra_DAO();

        public IHttpActionResult GetVT(string thanhvien)
        {
            List<KhoanChoVayChuaTra> list = dao.GetKhoanChoVayChuaTra(thanhvien);

            return Ok(list);
        }
    }
}
