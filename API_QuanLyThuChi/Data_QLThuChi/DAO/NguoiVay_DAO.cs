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
    }
}
