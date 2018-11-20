using Data_QLThuChi.DAO;
using Data_QLThuChi.Entities.thongke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_QuanLyThuChi.Controllers
{
    public class BaoCaoController : ApiController
    {
        BaoCao_DAO dao = new BaoCao_DAO();
        public IHttpActionResult Get_ThuchiTheoThang(int nam, string thanhvien)
        {
            List<ThuChiTheoThang> res = dao.BaoCaoThuChiTheoThang(nam, thanhvien);

            if(res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Get_TinhHinhThuChi(string thanhvien)
        {
            List<TinhHinhThuChi> res = dao.TinhHinhThuChi(thanhvien);

            if(res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
