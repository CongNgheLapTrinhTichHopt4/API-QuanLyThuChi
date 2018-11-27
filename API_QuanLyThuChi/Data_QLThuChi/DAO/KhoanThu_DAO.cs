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
    public class KhoanThu_DAO
    {
        public List<KhoanThu> GetKhoanThu(string matv, string thoigian)
        {
            const string proc = "SP_XemKhoanThuCaNhan";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("thanhvien", matv),
                new SqlParameter("thoigian", thoigian)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            List<KhoanThu> result = new List<KhoanThu>();
            KhoanThu kthu;
            while (reader.Read())
            {
                kthu = new KhoanThu();
                kthu.makt = Convert.ToInt32(reader["MaKT"]); 
                kthu.loaikt = Convert.ToString(reader["TenLKT"]);
                kthu.ngay = Convert.ToDateTime(reader["Ngay"]);
                kthu.sotien = Convert.ToInt32(reader["SoTien"]);
                kthu.ghichu = Convert.ToString(reader["GhiChu"]);
                kthu.dentaikhoan = Convert.ToString(reader["TenTaiKhoan"]);
                result.Add(kthu);
            }

            return result;
        }

        public List<KhoanThu> GetKhoanThuTrongNgay(string matv, string ngay)
        {
            const string proc = "SP_CacKhoanThuTrongNgay";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", matv),
                new SqlParameter("ngay", ngay)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            List<KhoanThu> result = new List<KhoanThu>();
            KhoanThu kthu;
            while (reader.Read())
            {
                kthu = new KhoanThu();
                kthu.makt = Convert.ToInt32(reader["MaKT"]);
                kthu.loaikt = Convert.ToString(reader["TenLKT"]);
                kthu.ngay = Convert.ToDateTime(reader["Ngay"]);
                kthu.sotien = Convert.ToInt32(reader["SoTien"]);
                kthu.ghichu = Convert.ToString(reader["GhiChu"]);
                kthu.dentaikhoan = Convert.ToString(reader["TenTaiKhoan"]);
                result.Add(kthu);
            }

            return result;
        }

        public List<LoaiKhoanThu> LoadDataForComboLKT()
        {
            const string proc = "LoadDataForComboLKT";
            List<SqlParameter> para = null;

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            List<LoaiKhoanThu> result = new List<LoaiKhoanThu>();
            LoaiKhoanThu lkt;

            while (reader.Read())
            {
                lkt = new LoaiKhoanThu();
                lkt.malkt = Convert.ToString(reader["MaLKT"]);
                lkt.tenlkt = Convert.ToString(reader["TenLKT"]);

                result.Add(lkt);
            }
            return result;
        }

        public bool PostKhoanThu(KhoanThu kt)
        {
            const string proc = "SP_ThemKhoanThu";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("MaThanhVien",kt.matv),
                new SqlParameter("Ngay", kt.ngay),
                new SqlParameter("LoaiKT", kt.loaikt),
                new SqlParameter("SoTien", kt.sotien),
                new SqlParameter("GhiChu", kt.ghichu),
                new SqlParameter("DenTaiKhoan", kt.dentaikhoan)
            };

            int res = DataProvider.ExecuteNonQuery(proc, para);

            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PutKhoanThu(KhoanThu kt)
        {
            const string proc = "SP_SuaKhoanThu";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("MaKT",kt.makt),
                new SqlParameter("Ngay", kt.ngay),
                new SqlParameter("LoaiKT", kt.loaikt),
                new SqlParameter("SoTien", kt.sotien),
                new SqlParameter("GhiChu", kt.ghichu),
                new SqlParameter("DenTaiKhoan", kt.dentaikhoan)
            };

            int res = DataProvider.ExecuteNonQuery(proc, para);

            if(res != 0)
            {
                return true;
            }
            else
            {
                return false;
            }  
        }

        public bool DeleteKhoanThu(int MaKT)
        {
            const string proc = "SP_XoaKhoanThu";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("makt", MaKT)
            };
            int res = DataProvider.ExecuteNonQuery(proc, para);
            if (res != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public KhoanThu SearchKhoanThu(string MaKT)
        {
            const string proc = "SP_TimKiemKhoanThu";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("makt", MaKT)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            KhoanThu res = new KhoanThu();
            KhoanThu kthu;
            while (reader.Read())
            {
                kthu = new KhoanThu();
                kthu.matv = Convert.ToString(reader["MaThanhVien"]);
                kthu.makt = Convert.ToInt32(reader["MaKT"]);
                kthu.loaikt = Convert.ToString(reader["LoaiKT"]);
                kthu.ngay = Convert.ToDateTime(reader["Ngay"]);
                kthu.sotien = Convert.ToInt32(reader["SoTien"]);
                kthu.ghichu = Convert.ToString(reader["GhiChu"]);
                kthu.dentaikhoan = Convert.ToString(reader["DenTaiKhoan"]);
                res = kthu;
            }
            return res;
        }

    }
}
