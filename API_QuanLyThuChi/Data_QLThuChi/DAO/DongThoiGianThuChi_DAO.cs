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
    public class DongThoiGianThuChi_DAO
    {
        public List<DongThoiGianThuChi> DongThoiGianThuChi(string matv)
        {
            const string proc = "SP_DongThoiGianThuChi";
            int ngayhientai = int.Parse(DateTime.Now.Day.ToString());

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", matv),
                new SqlParameter("ngayhientai", ngayhientai)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            DongThoiGianThuChi res;
            List<DongThoiGianThuChi> list = new List<DongThoiGianThuChi>();

            while (reader.Read())
            {
                res = new DongThoiGianThuChi();
                res.Ngay = Convert.ToDateTime(reader["ThoiGian"]);
                res.TongThu = Convert.ToInt32(reader["TongThu"]);
                res.TongChi = Convert.ToInt32(reader["TongChi"]);

                list.Add(res);
            }

            return list;
        }
    }
}
