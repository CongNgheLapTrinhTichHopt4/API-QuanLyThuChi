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
    public class MucDichTKHT_DAO
    {
        public List<MucDichTietKiem> GetMucDichTKHT(string matv)
        {
            const string proc = "SP_MucDichTietKiemDaHoanThanh";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("thanhvien", matv)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            List<MucDichTietKiem> result = new List<MucDichTietKiem>();
            MucDichTietKiem md;
            while (reader.Read())
            {
                md = new MucDichTietKiem();
                md.maMD = Convert.ToString(reader["MaMD"]);
                md.tenmucdich = Convert.ToString(reader["TenMucDich"]);
                md.sotiendukien = Convert.ToInt32(reader["SoTienDuKien"]);             
                md.ngaybatdau = Convert.ToDateTime(reader["NgayBatDau"]);
                md.ngayketthuc = Convert.ToDateTime(reader["NgayKetThuc"]);
                result.Add(md);
            }
            return result;
        }

        

    }
}
