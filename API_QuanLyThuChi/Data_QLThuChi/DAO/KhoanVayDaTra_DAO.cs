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
    public class KhoanVayDaTra_DAO
    {
        public List<KhoanVayDaTra> GetKhoanVayDaTra(string matv)
        {
            const string proc = "SP_XemKhoanVayDaTra";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", matv)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            List<KhoanVayDaTra> result = new List<KhoanVayDaTra>();
            KhoanVayDaTra vt;
            while (reader.Read())
            {
                vt = new KhoanVayDaTra();
                vt.id = Convert.ToInt32(reader["id"]);
                vt.ngayvay = Convert.ToDateTime(reader["NgayVay"]);
                vt.nguoivay = Convert.ToString(reader["NguoiVay"]);
                vt.sotien = Convert.ToInt32(reader["SoTien"]);
                vt.sotiendatra = Convert.ToInt32(reader["SoTienDaTra"]);              
                result.Add(vt);
            }
            return result;
        }
    }
}
