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
    public class TongKhoanVayTheoNguoiVay_DAO
    {
        public List<TongKhoanVayTheoNguoiVay> GetKhoanVayTheoNguoiVay(string matv)
        {
            const string proc = "SP_XemTongTienVayTheoNguoiChoVay";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", matv)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            List<TongKhoanVayTheoNguoiVay> result = new List<TongKhoanVayTheoNguoiVay>();
            TongKhoanVayTheoNguoiVay vt;
            while (reader.Read())
            {
                vt = new TongKhoanVayTheoNguoiVay();

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
