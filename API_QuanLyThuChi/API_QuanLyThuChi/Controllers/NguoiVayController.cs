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

        public IHttpActionResult Get_TimKiem(int id)
        {
            NguoiVay res = dao.SearchNguoiVay(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        public IHttpActionResult PostNV([FromBody] NguoiVay nv)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (dao.PostNguoiVay(nv) == false)
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

        public IHttpActionResult PutNV([FromBody] NguoiVay nv)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.PutNguoiVay(nv))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

        public IHttpActionResult DeleteNV(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.DeleteNguoiVay(id))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }
    }
}
