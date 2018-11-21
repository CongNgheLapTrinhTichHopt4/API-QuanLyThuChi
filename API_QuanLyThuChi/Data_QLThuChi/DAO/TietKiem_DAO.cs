using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Data_QLThuChi.Entities;

namespace Data_QLThuChi.DAO
{
    public class TietKiem_DAO
    {
        public List<TietKiem> GetTietKiem(string matv)
        {
            const string proc = "SP_XemTietKiem";
            List<SqlParameter> para = new List<SqlParameter>()
            {
               new SqlParameter("matv",matv)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            List<TietKiem> result = new List<TietKiem>();
            TietKiem tk;
            while (reader.Read())
            {
                tk = new TietKiem();
                tk.matk = Convert.ToInt32(reader["MaTK"]);
                tk.ngay = Convert.ToDateTime(reader["Ngay"]);
                tk.sotien = Convert.ToInt32(reader["SoTien"]);
                tk.matv = Convert.ToString(reader["ThanhVien"]);
                tk.mucdich= Convert.ToString(reader["TenMucDich"]);
                result.Add(tk);
            }
            return result;
        }

        public List<MucDichTietKiem> LoadDataForMucDich(string thanhvien)
        {
            const string proc = "LoadDataForMucDich";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", thanhvien)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            List<MucDichTietKiem> result = new List<MucDichTietKiem>();
            MucDichTietKiem md;

            while (reader.Read())
            {
                md = new MucDichTietKiem();
                md.maMD = Convert.ToString(reader["MaMD"]);
                md.tenmucdich = Convert.ToString(reader["TenMucDich"]);
                result.Add(md);
            }
            return result;
        }

        public bool PostTietKiem(TietKiem tk)
        {
            const string proc = "SP_ThemTietKiem";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                
                new SqlParameter("Ngay", tk.ngay),
                new SqlParameter("SoTien",tk.sotien),
                new SqlParameter("ThanhVien",tk.matv),
                new SqlParameter("MucDich", tk.mucdich)
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

        public bool PutTietKiem(TietKiem tk)
        {
            const string proc = "SP_SuaTietKiem";

            List<SqlParameter> para = new List<SqlParameter>()
            {
               new SqlParameter("MaTK", tk.matk),
                new SqlParameter("Ngay", tk.ngay),
                new SqlParameter("SoTien",tk.sotien),
                new SqlParameter("MucDich", tk.mucdich)
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

        public bool DeleteTietKiem(int MaTK )
        {
            const string proc = "SP_XoaTietKiem";
            List<SqlParameter> para = new List<SqlParameter>()
            {
               new SqlParameter("matk",MaTK)
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

        public TietKiem SearchTietKiem(int MaTK )
        {
            const string proc = "SP_TimKiemTietKiem";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matk", MaTK)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            TietKiem res = new TietKiem();
            TietKiem tk;

            while (reader.Read())
            {
                tk = new TietKiem();
                tk.matk = Convert.ToInt32(reader["MaTK"]);
                tk.ngay = Convert.ToDateTime(reader["Ngay"]);
                tk.sotien = Convert.ToInt32(reader["SoTien"]);
                tk.matv = Convert.ToString(reader["ThanhVien"]);
                tk.mucdich = Convert.ToString(reader["MucDich"]);
                res = tk;
            }
            return res;
        }

    }
}

