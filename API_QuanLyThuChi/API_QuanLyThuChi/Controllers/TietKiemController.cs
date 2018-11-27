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
    public class TietKiemController : ApiController
    {
        TietKiem_DAO dao = new TietKiem_DAO();

        public IHttpActionResult GetTietKiem(string thanhvien)
        {
            List<TietKiem> list = dao.GetTietKiem(thanhvien);

            return Ok(list);
        }

        public IHttpActionResult Get_TimKiem(int MaTK)
        {
            TietKiem resp = dao.SearchTietKiem(MaTK);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);

        }

        public IHttpActionResult GetLoadDataForCombo(bool loaddata, string matv)
        {
            List<MucDichTietKiem> list = dao.LoadDataForMucDich(matv);
            if (loaddata)
            {
                return Ok(list);
            }

            return NotFound();
        }


        public IHttpActionResult PostTietKiem([FromBody] TietKiem tk)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (dao.PostTietKiem(tk) == false)
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

        public IHttpActionResult PutTietKiem([FromBody] TietKiem tk)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (dao.PutTietKiem(tk) == false)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                return Ok();
            }
        }

        public IHttpActionResult DeleteTK(int MaTK)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            if (!dao.DeleteTietKiem(MaTK))
            {
                return BadRequest("Not a valid model");
            }

            return Ok();
        }

    }

}
