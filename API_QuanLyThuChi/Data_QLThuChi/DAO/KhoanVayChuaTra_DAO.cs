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
    public class KhoanVayChuaTra_DAO
    {
        public List<KhoanVayChuaTra> GetKhoanVayChuaTra(string matv)
        {
            const string proc = "SP_XemKhoanVayChuaTra";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", matv)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            List<KhoanVayChuaTra> result = new List<KhoanVayChuaTra>();
            KhoanVayChuaTra vt;
            while (reader.Read())
            {
                vt = new KhoanVayChuaTra();

                vt.id = Convert.ToInt32(reader["id"]);
                vt.ngayvay = Convert.ToDateTime(reader["NgayVay"]);
                vt.nguoivay = Convert.ToString(reader["NguoiVay"]);
                vt.sotien = Convert.ToInt32(reader["SoTien"]);
                vt.sotiendatra = Convert.ToInt32(reader["SoTienDaTra"]);
                vt.sotienchuatra = Convert.ToInt32(reader["SoTienChuaTra"]);



                result.Add(vt);
            }

            return result;
        }
    }
}
