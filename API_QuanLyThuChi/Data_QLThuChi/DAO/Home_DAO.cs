using Data_QLThuChi.Entities.thongke;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_QLThuChi.DAO
{
    public class Home_DAO
    {
        //DÙng cho việc load tổng thu, tổng chi tháng này ở màn hình trang chủ
        public TongThuChi TongThuChiThangNay(string thanhvien)
        {
            const string proc = "SP_TongThuChiThangNay";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", thanhvien)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            TongThuChi res = new TongThuChi();
            while (reader.Read())
            {
                res = new TongThuChi();
                res.TongThu = Convert.ToInt32(reader["TongThu"]);
                res.TongChi = Convert.ToInt32(reader["TongChi"]);
            }
            return res;
        }
    }
}
