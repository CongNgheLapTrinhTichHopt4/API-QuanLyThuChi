using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_QLThuChi.DAO
{
    public class Account_DAO
    {
        public int Login(string username, string password)
        {
            const string proc = "SP_Login";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("Username", username),
                new SqlParameter("Password", password)
            };
            int res = (int)DataProvider.ExecuteScalar(proc, para);
            return res;
        }

        public ThanhVien Get_ThanhVien(string tendangnhap)
        {
            const string proc = "SP_LayThongTinNguoiDung";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("TenDangNhap", tendangnhap)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            ThanhVien thanhvien = new ThanhVien();
            reader.Read();
            thanhvien.matkhau = Convert.ToString(reader["MatKhau"]);
            thanhvien.tendangnhap = Convert.ToString(reader["TenDangNhap"]);
            thanhvien.gioitinh = Convert.ToString(reader["GioiTinh"]);
            thanhvien.ngaysinh = Convert.ToDateTime(reader["NgaySinh"]);
            thanhvien.email = Convert.ToString(reader["Email"]);
            thanhvien.dienthoai = Convert.ToString(reader["DienThoai"]);
            thanhvien.tenhienthi = Convert.ToString(reader["TenHienThi"]);
            thanhvien.anhdaidien = Convert.ToString(reader["AnhDaiDien"]);
            return thanhvien;
        }

        public int KiemTraThongTinDanKy(string tendangnhap, string dienthoai, string email)
        {
            const string proc = "SP_KiemTraThongTinDangKy";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("tendangnhap", tendangnhap),
                new SqlParameter("dienthoai", dienthoai),
                new SqlParameter("email", email)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            reader.Read();
            int maloi = Convert.ToInt32(reader["MaLoi"]);
            return maloi;
        }

        public void TaoTaiKhoan(ThanhVien tv)
        {
            const string proc = "SP_DangKyTaiKhoan";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("tendangnhap", tv.tendangnhap),
                new SqlParameter("matkhau", tv.matkhau),
                new SqlParameter("ngaysinh", tv.ngaysinh),
                new SqlParameter("gioitinh", tv.gioitinh),
                new SqlParameter("dienthoai", tv.dienthoai),
                new SqlParameter("email", tv.email),
                new SqlParameter("anhdaidien", tv.anhdaidien),
                new SqlParameter("tenhienthi", tv.tenhienthi)
            };
            DataProvider.ExecuteScalar(proc, para);
        }

    }
}
