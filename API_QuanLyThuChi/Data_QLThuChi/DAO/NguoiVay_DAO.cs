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
    public class NguoiVay_DAO
    {
        public List<NguoiVay> GetAll()
        {
            const string proc = "SP_XemNguoiVay";

            List<SqlParameter> para = null;

            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            List<NguoiVay> result = new List<NguoiVay>();
            NguoiVay nv;
            while (reader.Read())
            {
                nv = new NguoiVay();
                nv.id = Convert.ToString(reader["id"]);
                nv.ten = Convert.ToString(reader["Ten"]);
                nv.sdt = Convert.ToInt32(reader["SDT"]);
                result.Add(nv);
            }

            return result;
        }

        public bool PostNguoiVay(NguoiVay nv)
        {
            const string proc = "SP_ThemNguoiVay";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                
                new SqlParameter("ten", nv.ten),
                new SqlParameter("sdt", nv.sdt)
               
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

        public bool PutNguoiVay(NguoiVay nv)
        {
            const string proc = "SP_SuaNguoiVay";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("ma",nv.id),
                new SqlParameter("ten", nv.ten),
                new SqlParameter("sdt", nv.sdt),
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

        public bool DeleteNguoiVay(int ma)
        {
            const string proc = "SP_XoaNguoiVay";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("id", ma)
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

        public NguoiVay SearchNguoiVay(int id)
        {
            const string proc = "SP_TimKiemNguoiVay";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("id", id)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            NguoiVay res = new NguoiVay();
            NguoiVay kthu;
            while (reader.Read())
            {
                kthu = new NguoiVay();

                kthu.id = Convert.ToString(reader["id"]);
                kthu.ten = Convert.ToString(reader["Ten"]);
                kthu.sdt = Convert.ToInt32(reader["SDT"]);
                
                res = kthu;
            }
            return res;
        }


    }
}
