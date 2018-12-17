using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data_QLThuChi.DAO;
using System.Data;
using Data_QLThuChi.Entities;
using System.Web.Mvc;

namespace API_QuanLyThuChi.Controllers
{
    
    public class KhoanThuController : ApiController
    {
        KhoanThu_DAO dao = new KhoanThu_DAO();

        public IHttpActionResult GetKT(string thanhvien, string thoigian)
        {
            List<KhoanThu> list = dao.GetKhoanThu(thanhvien, thoigian);
            return Ok(list);
        }

        //Tìm kiếm theo mã
        public IHttpActionResult Get_TimKiem(string MaKT)
        {
            KhoanThu res = dao.SearchKhoanThu(MaKT);
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        public IHttpActionResult GetDataForComBoLKT(bool loaddata)
        {
            List<LoaiKhoanThu> list = dao.LoadDataForComboLKT();
            if (loaddata)
            {
                return Ok(list);
            }
            return NotFound();
        }

        public IHttpActionResult PostKT([FromBody] KhoanThu kt)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (dao.PostKhoanThu(kt) == false)
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

        public HttpStatusCodeResult PutKT([FromBody] KhoanThu kt)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(404);

            if (!dao.PutKhoanThu(kt))
            {
                return new HttpStatusCodeResult(404);
            }

            return new HttpStatusCodeResult(200);
        }

        public IHttpActionResult DeleteKT(int MaKT)
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
