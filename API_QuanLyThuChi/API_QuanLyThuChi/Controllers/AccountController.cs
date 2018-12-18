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
    public class AccountController : ApiController
    {
        Account_DAO dao = new Account_DAO();
        public IHttpActionResult Get_Login(string username, string password)
        {
            int res = dao.Login(username, password);
            return Ok(res);
        }

        public IHttpActionResult Get_TenHienThi(string Username)
        {
            try
            {
                ThanhVien res = dao.Get_ThanhVien(Username);
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return NotFound();
            }

        }

        public IHttpActionResult Get_KTTT(string tendangnhap, string dienthoai, string email)
        {
            try
            {
                int res = dao.KiemTraThongTinDanKy(tendangnhap, dienthoai, email);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post_TaoTaiKhoan(ThanhVien tv)
        {
            dao.TaoTaiKhoan(tv);
            return Ok();
        }

        public IHttpActionResult Post_DoiMatKhau(ThanhVien tv, bool doimatkhau)
        {
            if (dao.DoiMatKhau(tv.tendangnhap, tv.matkhau))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post_CapNhatThongTinNguoiDung(ThanhVien tv, bool capnhat)
        {
            dao.CapNhatThongTinNguoiDung(tv);
            return Ok();
        }

    }
}
