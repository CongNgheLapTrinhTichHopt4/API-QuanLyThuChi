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
    public class TraNoController : ApiController
    {
        TraNo_DAO dao = new TraNo_DAO();
        public IHttpActionResult Post_TraNo(TraNo tn)
        {
            if(dao.TraNo(tn) == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        public IHttpActionResult Get_KhoanChoVay(int id)
        {
            KhoanChoVay res = dao.XemKhoanChoVayTheoId(id);
            return Ok(res);
        }

        public IHttpActionResult Get_LichSuTra(int IdKhoanVay)
        {
            List<TraNo> res = dao.LichSuTraNo(IdKhoanVay);
            return Ok(res);
        }
    }
}
