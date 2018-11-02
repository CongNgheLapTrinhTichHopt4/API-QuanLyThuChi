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
    public class KhoanChi_DAO
    {
        public List<KhoanChi> GetKhoanChi(string matv, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            const string proc = "SP_XemKhoanChiCaNhan";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("matv", matv),
                new SqlParameter("ngaybatdau", ngaybatdau),
                new SqlParameter("ngayketthuc", ngayketthuc)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, parameters);

            List<KhoanChi> result = new List<KhoanChi>();

            KhoanChi kc = null;
            while (reader.Read())
            {
                kc = new KhoanChi();
                kc.makc = Convert.ToString(reader["MaKC"]);
                kc.ngay = Convert.ToDateTime(reader["Ngay"]);
                kc.sotien = Convert.ToDouble(reader["SoTien"]);
                kc.khoanchi = Convert.ToString(reader["KhoanChi"]);
                kc.ghichu = Convert.ToString(reader["GhiChu"]);

                result.Add(kc);
            }

            return result;

        }

        public bool PostKhoanChi(KhoanChi kc)
        {
            const string proc = "SP_ThemKhoanChi";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("makt", kc.makc),
                new SqlParameter("matv", kc.matv),
                new SqlParameter("ngay", kc.ngay),
                new SqlParameter("loaikt", kc.loaikc),
                new SqlParameter("khoanchi", kc.khoanchi),
                new SqlParameter("sotien", kc.sotien),
                new SqlParameter("ghichu", kc.ghichu)
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

        public bool PutKhoanThu(KhoanChi kc)
        {
            const string proc = "SP_SuaKhoanChi";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("makt", kc.makc),
                new SqlParameter("matv", kc.matv),
                new SqlParameter("ngay", kc.ngay),
                new SqlParameter("loaikt", kc.loaikc),
                new SqlParameter("khoanchi", kc.khoanchi),
                new SqlParameter("sotien", kc.sotien),
                new SqlParameter("ghichu", kc.ghichu)
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

        public bool DeleteKhoanChi(string MaKC)
        {
            const string proc = "SP_XoaKhoanChi";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("makc", MaKC)
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

        public List<KhoanChi> SearchKhoanChi(string MaKC)
        {
            const string proc = "SP_TimKiemKhoanChi";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("makc", MaKC)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            List<KhoanChi> result = new List<KhoanChi>();
            KhoanChi kchi;
            while (reader.Read())
            {
                kchi = new KhoanChi();
                kchi.matv = Convert.ToString(reader["MaThanhVien"]);
                kchi.makc = Convert.ToString(reader["MaKT"]);
                kchi.loaikc = Convert.ToString(reader["TenLKT"]);
                kchi.ngay = Convert.ToDateTime(reader["Ngay"]);
                kchi.sotien = Convert.ToDouble(reader["SoTien"]);
                kchi.khoanchi = Convert.ToString(reader["KhoanThu"]);
                kchi.ghichu = Convert.ToString(reader["GhiChu"]);

                result.Add(kchi);
            }

            return result;
        }

    }
}
