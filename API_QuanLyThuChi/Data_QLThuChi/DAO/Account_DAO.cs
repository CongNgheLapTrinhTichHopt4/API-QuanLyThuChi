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

        public string TenHienThi(string Username)
        {
            const string proc = "SP_TenHienThi";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("Username", Username)
            };

            string res = (string)DataProvider.ExecuteScalar(proc, para);

            return res;
        }
    }
}
