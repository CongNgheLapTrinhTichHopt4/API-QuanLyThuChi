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
    public class MucDichTietKiem_DAO
    {
        public List<MucDichTietKiem> GetMucDichTietKiem(string matv)
        {
            const string proc = "SP_XemMucDichTietKiem";
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
                md.sotiendukien = Convert.ToDouble(reader["SoTienDuKien"]);
                md.sotiendatietkiem = Convert.ToDouble(reader["SoTienDaTietKiem"]);
                md.ngaybatdau = Convert.ToDateTime(reader["NgayBatDau"]);
                md.ngayketthuc = Convert.ToDateTime(reader["NgayKetThuc"]);
                md.trangthai = Convert.ToString(reader["TrangThai"]);
                result.Add(md);
            }
            return result;
        }



        public bool PostMucDichTK(MucDichTietKiem md)
        {
            const string proc = "SP_ThemMucDichTK";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("MaThanhVien",md.matv),
                new SqlParameter("TenMucDich",md.tenmucdich),
                new SqlParameter("SoTienDuKien",md.sotiendukien),
                new SqlParameter("NgayBatDau",md.ngaybatdau),
                new SqlParameter("NgayKetThuc",md.ngayketthuc)
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

        public bool PutMucDichTietKiem(MucDichTietKiem md)
        {
            const string proc = "SP_SuaMucDichTK";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("MaMD",md.maMD),
                new SqlParameter("TenMucDich",md.tenmucdich),
                new SqlParameter("SoTienDuKien",md.sotiendukien),
                new SqlParameter("NgayBatDau",md.ngaybatdau),
                new SqlParameter("NgayKetThuc",md.ngayketthuc)
            };
            int res = DataProvider.ExecuteNonQuery(proc, para);
            if (res != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteMucDichTK(string MaMD)
        {
            const string proc = "SP_XoaMucDichTK";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("maMD",MaMD)
            };
            int res = DataProvider.ExecuteNonQuery(proc, para);
            if (res != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public MucDichTietKiem SearchMucDichTK(string MaMD)
        {
            const string proc = "SP_TimKiemMucDichTK";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("maMD",MaMD)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            MucDichTietKiem res = new MucDichTietKiem();
            MucDichTietKiem md;
            while (reader.Read())
            {
                md = new MucDichTietKiem();
                md.maMD = Convert.ToString(reader["MaMD"]);
                md.tenmucdich = Convert.ToString(reader["TenMucDich"]);
                md.sotiendukien = Convert.ToInt32(reader["SoTienDuKien"]);
                md.ngaybatdau = Convert.ToDateTime(reader["NgayBatDau"]);
                md.ngayketthuc = Convert.ToDateTime(reader["NgayKetThuc"]);
                res = md;
            }
            return res;
        }
    }
}
