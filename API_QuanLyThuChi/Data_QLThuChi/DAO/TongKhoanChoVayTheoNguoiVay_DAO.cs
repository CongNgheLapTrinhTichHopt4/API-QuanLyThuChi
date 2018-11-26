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
    public class TongKhoanChoVayTheoNguoiVay_DAO
    {
        public List<TongKhoanChoVayTheoNguoiVay> GetKhoanChoVayTheoNguoiVay(string matv)
        {
            const string proc = "SP_XemTongTienChoVayTheoNguoiVay";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", matv)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            List<TongKhoanChoVayTheoNguoiVay> result = new List<TongKhoanChoVayTheoNguoiVay>();
            TongKhoanChoVayTheoNguoiVay vt;
            while (reader.Read())
            {
                vt = new TongKhoanChoVayTheoNguoiVay();

                vt.id = Convert.ToInt32(reader["id"]);
                vt.nguoivay = Convert.ToString(reader["NguoiVay"]);
                vt.sdt = Convert.ToString(reader["SDT"]);
                vt.tongconno = Convert.ToInt32(reader["TongConNo"]);
              


                result.Add(vt);
            }

            return result;
        }

    }
}
