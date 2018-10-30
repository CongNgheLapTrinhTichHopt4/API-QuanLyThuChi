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
    
    public class KhoanThuController : ApiController
    {
        KhoanThu_DAO dao = new KhoanThu_DAO();

        public IHttpActionResult GetKT()
        {
            List<KhoanThu> list = dao.GetKhoanThu("tuanvm");
            if(list.Count == 0)
            {
                return NotFound();
            }

            return Ok(list);
        }

        public IHttpActionResult GetKT(string MaKT)
        {
            List<KhoanThu> list = dao.SearchKhoanThu(MaKT);
            if (list.Count == 0)
            {
                return NotFound();
            }

            return Ok(list);
        }

        public IHttpActionResult PostKT([FromBody] KhoanThu kt)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.PostKhoanThu(kt))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

        public IHttpActionResult PutKT([FromBody] KhoanThu kt)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.PutKhoanThu(kt))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

        public IHttpActionResult DeleteKT(string MaKT)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.DeleteKhoanThu(MaKT))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

    }
}
