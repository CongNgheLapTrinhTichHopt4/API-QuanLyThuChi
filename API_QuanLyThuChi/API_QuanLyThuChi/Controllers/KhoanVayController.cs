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
    public class KhoanVayController : ApiController
    {
        KhoanVay_DAO dao = new KhoanVay_DAO();

        public IHttpActionResult GetVT(string thanhvien)
        {
            List<KhoanVay> list = dao.GetKhoanVay(thanhvien);
            if (list.Count == 0)
            {
                return NotFound();
            }

            return Ok(list);
        }
        public IHttpActionResult Get_TimKiem(int id)
        {
            KhoanVay_ChoVay res = dao.SearchKhoanVay(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        public IHttpActionResult PostKV([FromBody] KhoanVay_ChoVay kt)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (dao.PostKhoanVay(kt) == false)
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

        public IHttpActionResult PutKV([FromBody] KhoanVay_ChoVay kt)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.PutKhoanVay(kt))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }


        public IHttpActionResult DeleteKV(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.DeleteKhoanVay(id))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }
    }
}
