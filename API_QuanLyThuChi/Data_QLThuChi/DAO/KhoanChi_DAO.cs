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
        public List<KhoanChi> GetKhoanChi(string matv)
        {
            const string proc = "SP_XemKhoanChiCaNhan";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("matv", matv),
                //new SqlParameter("ngaybatdau", ngaybatdau),
                //new SqlParameter("ngayketthuc", ngayketthuc)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, parameters);

            List<KhoanChi> result = new List<KhoanChi>();

            KhoanChi kc = null;
            while (reader.Read())
            {
                kc = new KhoanChi();
                kc.makc = Convert.ToInt32(reader["MaKC"]);
                //kc.matv = Convert.ToString(reader["MaThanhVien"]);
                kc.ngay = Convert.ToDateTime(reader["Ngay"]);
                kc.loaikc = Convert.ToString(reader["TenLKC"]);
                kc.sotien = Convert.ToDouble(reader["SoTien"]);
               
                kc.ghichu = Convert.ToString(reader["GhiChu"]);
                kc.tutaikhoan = Convert.ToString(reader["TenTaiKhoan"]);
                //kc.tenlkc = Convert.ToString(reader["TenLKC"]);

                result.Add(kc);
            }

            return result;

        }
        public List<LoaiKhoanChi> LoadDataForComboLKC()
        {
            const string proc = "LoadDataForComboLKC";
            List<SqlParameter> para = null;

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            List<LoaiKhoanChi> result = new List<LoaiKhoanChi>();
            LoaiKhoanChi lkc;

            while (reader.Read())
            {
                lkc = new LoaiKhoanChi();
                lkc.malkc = Convert.ToString(reader["MaLKC"]);
                lkc.tenlkc = Convert.ToString(reader["TenLKC"]);

                result.Add(lkc);
            }
            return result;
        }

        public bool PostKhoanChi(KhoanChi kc)
        {
            const string proc = "SP_ThemKhoanChi";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                //new SqlParameter("makc", kc.makc),
                new SqlParameter("matv", kc.matv),
                new SqlParameter("ngay", kc.ngay),
                new SqlParameter("loaikc", kc.loaikc),

                new SqlParameter("sotien", kc.sotien),
                new SqlParameter("ghichu", kc.ghichu),
                new SqlParameter("tutaikhoan", kc.tutaikhoan),
                //new SqlParameter("tenlkc",kc.tenlkc),
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

        public bool PutKhoanChi(KhoanChi kc)
        {
            const string proc = "SP_SuaKhoanChi";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("makc", kc.makc),
                //new SqlParameter("matv", kc.matv),
                new SqlParameter("ngay", kc.ngay),
                new SqlParameter("loaikc", kc.loaikc),

                new SqlParameter("sotien", kc.sotien),
                new SqlParameter("ghichu", kc.ghichu),
                new SqlParameter("tutaikhoan", kc.tutaikhoan),
                //new SqlParameter("tenlkc",kc.tenlkc),
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

        public KhoanChi SearchKhoanChi(string MaKC)
        {
            const string proc = "SP_TimKiemKhoanChi";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("makc", MaKC)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            KhoanChi kchi = new KhoanChi();
            while (reader.Read())
            {
                kchi = new KhoanChi();
              
                kchi.makc = Convert.ToInt32(reader["MaKC"]);
                //kchi.matv = Convert.ToString(reader["MaThanhVien"]);
                kchi.ngay = Convert.ToDateTime(reader["Ngay"]);
                kchi.loaikc = Convert.ToString(reader["LoaiKC"]);
                kchi.sotien = Convert.ToDouble(reader["SoTien"]);
                
                kchi.ghichu = Convert.ToString(reader["GhiChu"]);
                kchi.tutaikhoan = Convert.ToString(reader["TuTaiKhoan"]);
                //kchi.tenlkc = Convert.ToString(reader["tenlkc"]);
            }

            return kchi;
        }

    }
}
