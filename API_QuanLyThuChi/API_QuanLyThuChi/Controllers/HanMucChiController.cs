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
    public class HanMucChiController : ApiController
    {
        HanMucChi_DAO dao = new HanMucChi_DAO();
        public IHttpActionResult GetHanMuc(string matv, string thoigian)
        {
            List<HanMucChi_View> res = dao.Get_HanMucChi(matv, thoigian);
            return Ok(res);
        }

        public IHttpActionResult GetHanMucTheoId(int id)
        {
            HanMucChi res = dao.Get_HanMucChiTheoId(id);
            return Ok(res);
        }

        public IHttpActionResult PostHanMuc([FromBody] HanMucChi hmc)
        {
            if (dao.Post_HanMucChi(hmc))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }          
        }

        public IHttpActionResult PutHanMucChi([FromBody] HanMucChi hmc)
        {
            if (dao.Put_HanMucChi(hmc))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }  
}
