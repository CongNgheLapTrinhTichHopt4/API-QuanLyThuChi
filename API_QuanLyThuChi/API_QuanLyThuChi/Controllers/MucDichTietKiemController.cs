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
    public class MucDichTietKiemController : ApiController
    {
        MucDichTietKiem_DAO dao = new MucDichTietKiem_DAO();

        public IHttpActionResult GetMucDichTK(string thanhvien)
        {
            List<MucDichTietKiem> list = dao.GetMucDichTietKiem(thanhvien);
            if (list.Count == 0)
            {
                return NotFound();
            }

            return Ok(list);
        }


        
        //Tìm kiếm theo mã
        public IHttpActionResult Get_TimKiem(string MaMD)
        {
            MucDichTietKiem res = dao.SearchMucDichTK(MaMD);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        public IHttpActionResult PostMD([FromBody]MucDichTietKiem md)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (dao.PostMucDichTK(md) == false)
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

        public IHttpActionResult PutMD([FromBody] MucDichTietKiem md)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.PutMucDichTietKiem(md))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

        public IHttpActionResult Delete(string MaMD)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.DeleteMucDichTK(MaMD))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }
    }
}
