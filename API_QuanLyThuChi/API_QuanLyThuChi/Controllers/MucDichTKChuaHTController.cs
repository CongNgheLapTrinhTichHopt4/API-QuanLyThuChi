using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data_QLThuChi.DAO;
using System.Data;
using Data_QLThuChi.Entities;
using System.Collections.Generic;

namespace API_QuanLyThuChi.Controllers
{
    public class MucDichTKChuaHTController : ApiController
    {
        MucDichTKChuaHT_DAO dao = new MucDichTKChuaHT_DAO();
        public IHttpActionResult GetMucDichChuaHoanThanh(string thanhvien)
        {
           
            List<MucDichTK_ChuaHT> list = dao.GetMDChuaHoanThanh(thanhvien);
            if (list.Count == 0)
            {
                return NotFound();
            }

            return Ok(list);
        }

        //Tìm kiếm theo mã
     
       
    }
}
