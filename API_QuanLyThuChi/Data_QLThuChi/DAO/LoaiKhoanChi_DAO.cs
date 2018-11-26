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
    public class LoaiKhoanChi_DAO
    {
        public List<LoaiKhoanChi> GetLoaiKhoanChi()
        {
            const string proc = "SP_XemLoaiKhoanChi";

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
    }
}
