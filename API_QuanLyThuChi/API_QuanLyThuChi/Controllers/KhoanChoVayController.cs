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
    public class KhoanChoVayController : ApiController
    {
        KhoanChoVay_DAO dao = new KhoanChoVay_DAO();

        public IHttpActionResult GetVT(string thanhvien)
        {
            List<KhoanChoVay> list = dao.GetKhoanChoVay(thanhvien);

            return Ok(list);
        }
      
        public IHttpActionResult Get_TimKiem(int id)
        {
            KhoanVay_ChoVay res = dao.SearchKhoanChoVay(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        public IHttpActionResult PostKCV([FromBody] KhoanVay_ChoVay kt)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (dao.PostKhoanChoVay(kt) == false)
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

        public IHttpActionResult PutKCV([FromBody] KhoanVay_ChoVay kt)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.PutKhoanChoVay(kt))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }


        public IHttpActionResult DeleteKCV(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.DeleteKhoanChoVay(id))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }
    }
}
