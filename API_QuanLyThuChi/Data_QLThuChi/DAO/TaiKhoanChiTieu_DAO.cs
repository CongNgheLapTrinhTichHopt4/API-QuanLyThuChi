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
    public class TaiKhoanChiTieu_DAO
    {
        public List<TaiKhoanChiTieu> GetAll()
        {
            const string proc = "SP_XemTaiKhoanChiTieu";

            List<SqlParameter> para = null;

            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            List<TaiKhoanChiTieu> result = new List<TaiKhoanChiTieu>();
            TaiKhoanChiTieu tkct;
            while (reader.Read())
            {
                tkct = new TaiKhoanChiTieu();
                tkct.id = Convert.ToInt32(reader["id"]);
                tkct.tentaikhoan = Convert.ToString(reader["TenTaiKhoan"]);
                result.Add(tkct);
            }

            return result;
        }
    }
}
