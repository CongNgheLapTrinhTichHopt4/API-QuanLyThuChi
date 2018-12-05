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
    public class MucDichTKChuaHT_DAO
    {
        public List<MucDichTK_ChuaHT> GetMDChuaHoanThanh(string matv)
        {
            const string proc = "SP_MucDichTietKiemChuaHoanThanh";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("thanhvien", matv)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            List<MucDichTK_ChuaHT> result = new List<MucDichTK_ChuaHT>();
            MucDichTK_ChuaHT md;
            while (reader.Read())
            {
                md = new MucDichTK_ChuaHT();
                md.maMD = Convert.ToString(reader["id"]);
                md.tenmucdich = Convert.ToString(reader["TenMucDich"]);
                md.sotiendukien = Convert.ToDouble(reader["SoTienDuKien"]);
                md.sotiendatietkiem = Convert.ToDouble(reader["SoTienDaTietKiem"]);
                md.sotienconlai = Convert.ToDouble(reader["SoTienConLai"]);
                md.ngaybatdau = Convert.ToDateTime(reader["NgayBatDau"]);
                md.ngayketthuc = Convert.ToDateTime(reader["NgayKetThuc"]);
                result.Add(md);
            }
            return result;
        }


    }
}
