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
        public List<KhoanThu> GetKhoanThu(string matv)
        {
            const string proc = "SP_XemKhoanThuCaNhanDemo";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", matv)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            List<KhoanThu> result = new List<KhoanThu>();
            KhoanThu kthu;
            while (reader.Read())
            {
                kthu = new KhoanThu();
                kthu.matv = Convert.ToString(reader["MaThanhVien"]);
                kthu.makt = Convert.ToString(reader["MaKT"]);
                kthu.loaikt = Convert.ToString(reader["TenLKT"]);
                kthu.ngay = Convert.ToDateTime(reader["Ngay"]);
                kthu.sotien = Convert.ToDouble(reader["SoTien"]);
                kthu.khoanthu = Convert.ToString(reader["KhoanThu"]);
                kthu.ghichu = Convert.ToString(reader["GhiChu"]);

                result.Add(kthu);
            }

            return result;
        }

        public bool PostKhoanThu(KhoanThu kt)
        {
            const string proc = "SP_ThemKhoanThu";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("makt", kt.makt),
                new SqlParameter("matv",kt.matv),
                new SqlParameter("ngay", kt.ngay),
                new SqlParameter("loaikt", kt.loaikt),
                new SqlParameter("khoanthu", kt.khoanthu),
                new SqlParameter("sotien", kt.sotien),
                new SqlParameter("ghichu", kt.ghichu)
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

        public bool PutKhoanThu(KhoanThu kt)
        {
            const string proc = "SP_SuaKhoanThu";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("makt", kt.makt),
                new SqlParameter("matv",kt.matv),
                new SqlParameter("ngay", kt.ngay),
                new SqlParameter("loaikt", kt.loaikt),
                new SqlParameter("khoanthu", kt.khoanthu),
                new SqlParameter("sotien", kt.sotien),
                new SqlParameter("ghichu", kt.ghichu)
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

        public bool DeleteKhoanThu(string MaKT)
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

        public List<KhoanThu> SearchKhoanThu(string MaKT)
        {
            const string proc = "SP_TimKiemKhoanThu";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("makt", MaKT)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            List<KhoanThu> result = new List<KhoanThu>();
            KhoanThu kthu;
            while (reader.Read())
            {
                kthu = new KhoanThu();
                kthu.matv = Convert.ToString(reader["MaThanhVien"]);
                kthu.makt = Convert.ToString(reader["MaKT"]);
                kthu.loaikt = Convert.ToString(reader["TenLKT"]);
                kthu.ngay = Convert.ToDateTime(reader["Ngay"]);
                kthu.sotien = Convert.ToDouble(reader["SoTien"]);
                kthu.khoanthu = Convert.ToString(reader["KhoanThu"]);
                kthu.ghichu = Convert.ToString(reader["GhiChu"]);

                result.Add(kthu);
            }

            return result;
        }

    }
}
