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
    public class KhoanChiController : ApiController
    {
        KhoanChi_DAO dao = new KhoanChi_DAO();
        public IHttpActionResult GetKhoanChi(string matv, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            List<KhoanChi> list = dao.GetKhoanChi(matv, ngaybatdau, ngayketthuc);

            if (list.Count <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(list);
            }
        }

        //Tìm kiếm theo mã
        public IHttpActionResult GetKC(string MaKC)
        {
            List<KhoanChi> list = dao.SearchKhoanChi(MaKC);
            if (list.Count == 0)
            {
                return NotFound();
            }

            return Ok(list);
        }

        public IHttpActionResult PostKC([FromBody] KhoanChi kc)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.PostKhoanChi(kc))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

        public IHttpActionResult PutKC([FromBody] KhoanChi kc)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.PutKhoanThu(kc))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

        public IHttpActionResult DeleteKC(string MaKC)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.DeleteKhoanChi(MaKC))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

    }
}
