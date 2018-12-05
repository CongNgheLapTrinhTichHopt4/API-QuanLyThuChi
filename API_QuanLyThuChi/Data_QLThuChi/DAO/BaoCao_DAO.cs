using Data_QLThuChi.Entities.thongke;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_QLThuChi.DAO
{
    public class BaoCao_DAO
    {
        /// <summary>
        /// Load dữ liệu ra biểu đồ cột
        /// </summary>
        /// <returns></returns>
        public List<ThuChiTheoThang> BaoCaoThuChiTheoThang(int nam, string thanhvien) 
        {
            const string proc = "SP_ThongKeThuChi";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("nam", nam),
                new SqlParameter("thanhvien", thanhvien)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            ThuChiTheoThang res;
            List<ThuChiTheoThang> list =new List<ThuChiTheoThang>();
            while (reader.Read())
            {
                res = new ThuChiTheoThang();
                res.thang = Convert.ToInt32(reader["thang"]);
                res.tongthu = Convert.ToInt32(reader["tongthu"]);
                res.tongchi = Convert.ToInt32(reader["tongchi"]);

                list.Add(res);
            }
            return list;
        }

        public List<TinhHinhThuChi> TinhHinhThuChi(string thanhvien)
        {
            const string proc = "SP_ThongKeNgayTuanThangNam";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("thanhvien", thanhvien)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            TinhHinhThuChi res;
            List<TinhHinhThuChi> list = new List<TinhHinhThuChi>();
            while (reader.Read())
            {
                res = new TinhHinhThuChi();
                res.KhoangThoiGian = Convert.ToString(reader["KhoangThoiGian"]);
                res.ThoiGian = Convert.ToString(reader["ThoiGian"]);
                res.TongThu = Convert.ToInt32(reader["TongThu"]);
                res.TongChi = Convert.ToInt32(reader["TongChi"]);

                list.Add(res);
            }
            return list;
        }

        public List<PhanTichThuChi> PhanTichKhoanChiThang(string thanhvien, string thoigian)
        {
            const string proc = "SP_PhanTichKhoanChiThang";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", thanhvien),
                new SqlParameter("thoigian", thoigian)

            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            PhanTichThuChi res;
            List<PhanTichThuChi> list = new List<PhanTichThuChi>();
            while (reader.Read())
            {
                res = new PhanTichThuChi();
                res.Loai = Convert.ToString(reader["LoaiKhoanChi"]);
                res.SoTien = Convert.ToInt32(reader["SoTien"]);

                list.Add(res);
            }
            return list;
        }

        public List<PhanTichThuChi> PhanTichKhoanThuThang(string thanhvien, string thoigian)
        {
            const string proc = "SP_PhanTichKhoanThuThang";   
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", thanhvien),
                new SqlParameter("thoigian", thoigian)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            PhanTichThuChi res;
            List<PhanTichThuChi> list = new List<PhanTichThuChi>();
            while (reader.Read())
            {
                res = new PhanTichThuChi();
                res.Loai = Convert.ToString(reader["LoaiKhoanThu"]);
                res.SoTien = Convert.ToInt32(reader["SoTien"]);
                list.Add(res);
            }
            return list;
        }

        public List<TaiChinhHienTai> TaiChinhHienTai(string thanhvien)
        {
            const string proc = "SP_TaiChinhHienTai";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", thanhvien)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            TaiChinhHienTai res;
            List<TaiChinhHienTai> list = new List<TaiChinhHienTai>();
            while (reader.Read())
            {
                res = new TaiChinhHienTai();
                res.TienTrongVi = Convert.ToInt32(reader["TienTrongVi"]);
                res.ATM = Convert.ToInt32(reader["ATM"]);
                res.TongChoVay = Convert.ToInt32(reader["TongChoVay"]);
                res.TongVay = Convert.ToInt32(reader["TongVay"]);
                res.TongKet = Convert.ToInt32(reader["TongKet"]);
                list.Add(res);
            }
            return list;
        }

        
    }
}
