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
    public class KhoanChi_DAO
    {
        public List<KhoanChi> GetKhoanChi(string matv, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            const string proc = "SP_XemKhoanChiCaNhan";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("matv", matv),
                new SqlParameter("ngaybatdau", ngaybatdau),
                new SqlParameter("ngayketthuc", ngayketthuc)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, parameters);

            List<KhoanChi> result = new List<KhoanChi>();

            KhoanChi kc = null;
            while (reader.Read())
            {
                kc = new KhoanChi();
                kc.makc = Convert.ToString(reader["MaKC"]);
                kc.ngay = Convert.ToDateTime(reader["Ngay"]);
                kc.sotien = Convert.ToDouble(reader["SoTien"]);
                kc.khoanchi = Convert.ToString(reader["KhoanChi"]);
                kc.ghichu = Convert.ToString(reader["GhiChu"]);

                result.Add(kc);
            }

            return result;

        }
    }
}
