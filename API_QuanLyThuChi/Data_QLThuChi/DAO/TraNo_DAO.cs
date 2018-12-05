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
    public class TraNo_DAO
    {
        public bool TraNo(TraNo tn)
        {
            const string proc = "SP_TraNo";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("khoanvay",tn.KhoanVay),
                new SqlParameter("ngaytra", tn.NgayTra),
                new SqlParameter("sotien", tn.SoTienTra),
                new SqlParameter("taikhoan", tn.TaiKhoan)
            };
            int res = DataProvider.ExecuteNonQuery(proc, para);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public KhoanChoVay XemKhoanChoVayTheoId(int id)
        {
            const string proc = "SP_XemKhoanVayTheoId";
            List<SqlParameter> para = new List<SqlParameter>()
            {
            new SqlParameter("id",id)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            KhoanChoVay kcv = new KhoanChoVay();
            while (reader.Read())
            {
                kcv.id = Convert.ToInt32(reader["id"]);
                kcv.ngayvay = Convert.ToDateTime(reader["NgayVay"]);
                kcv.sotien = Convert.ToInt32(reader["SoTienVay"]);
                kcv.sotiendatra = Convert.ToInt32(reader["SoTienDaTra"]);
                kcv.sotienchuatra = Convert.ToInt32(reader["SoTienConNo"]);
                kcv.nguoivay = Convert.ToString(reader["NguoiVay"]);
            }
            return kcv;
        }

        public List<TraNo> LichSuTraNo(int id)
        {
            const string proc = "SP_LichSuTraNo";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("id", id)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            List<TraNo> result = new List<TraNo>();
            TraNo tn;
            while (reader.Read())
            {
                tn = new TraNo();
                tn.NgayTra = Convert.ToDateTime(reader["NgayTra"]);
                tn.SoTienTra = Convert.ToInt32(reader["SoTienTra"]);
                result.Add(tn);
            }
            return result;
        }

        
    }
}
