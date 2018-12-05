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
    public class MucDichTKHTController : ApiController
    {
        MucDichTKHT_DAO dao = new MucDichTKHT_DAO();

        public IHttpActionResult GetMucDichTKHT(string thanhvien)
        {
            List<MucDichTietKiem> list = dao.GetMucDichTKHT(thanhvien);

            return Ok(list);
        }

    }
}
