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
    public class NguoiVayController : ApiController
    {
        NguoiVay_DAO dao = new NguoiVay_DAO();
        public IHttpActionResult GetAll()
        {
            List<NguoiVay> res = dao.GetAll();
            return Ok(res);
        }
    }
}
