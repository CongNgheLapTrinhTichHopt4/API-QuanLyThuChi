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
    public class KhoanVayDaTraController : ApiController
    {
        KhoanVayDaTra_DAO dao = new KhoanVayDaTra_DAO();

        public IHttpActionResult GetVT(string thanhvien)
        {
            List<KhoanVayDaTra> list = dao.GetKhoanVayDaTra(thanhvien);
            if (list.Count == 0)
            {
                return NotFound();
            }

            return Ok(list);
        }
    }
}
