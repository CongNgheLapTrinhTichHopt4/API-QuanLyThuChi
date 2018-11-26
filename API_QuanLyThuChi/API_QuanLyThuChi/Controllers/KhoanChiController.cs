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
        public IHttpActionResult GetKhoanChi(string matv)
        {
            List<KhoanChi> list = dao.GetKhoanChi(matv);

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
            KhoanChi res = dao.SearchKhoanChi(MaKC);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }
        public IHttpActionResult GetDataForComBoLKC(bool loaddata)
        {
            List<LoaiKhoanChi> list = dao.LoadDataForComboLKC();
            if (loaddata)
            {
                return Ok(list);
            }
            return NotFound();
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

            if (!dao.PutKhoanChi(kc))//sửa
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
