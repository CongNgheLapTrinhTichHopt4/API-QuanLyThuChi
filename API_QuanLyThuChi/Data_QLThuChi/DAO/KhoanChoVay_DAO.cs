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
   public  class KhoanChoVay_DAO
    {
        public List<KhoanChoVay> GetKhoanChoVay(string matv)
        {
            const string proc = "SP_XemKhoanChoVay";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", matv)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            List<KhoanChoVay> result = new List<KhoanChoVay>();
            KhoanChoVay vt;
            while (reader.Read())
            {
                vt = new KhoanChoVay();

                vt.id = Convert.ToInt32(reader["id"]);
                vt.ngayvay = Convert.ToDateTime(reader["NgayVay"]);
                vt.nguoivay = Convert.ToString(reader["NguoiVay"]);
                vt.sotien = Convert.ToInt32(reader["SoTien"]);
                vt.sotiendatra = Convert.ToInt32(reader["SoTienDaTra"]);
                vt.sotienchuatra = Convert.ToInt32(reader["SoTienChuaTra"]);
                vt.trangthai = Convert.ToString(reader["TrangThai"]);
               

                result.Add(vt);
            }

            return result;
        }
       

        public bool PostKhoanChoVay(KhoanVay_ChoVay kt)
        {
            const string proc = "SP_ThemKhoanVay_ChoVay";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("ngayvay",kt.ngayvay),
                new SqlParameter("sotien", kt.sotien),
                new SqlParameter("thanhvien", kt.thanhvien),
                new SqlParameter("loai", kt.loai),
                new SqlParameter("nguoivay", kt.nguoivay),
                new SqlParameter("taikhoanchitieu", kt.taikhoanchitieu),

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

        public bool PutKhoanChoVay(KhoanVay_ChoVay kt)
        {
            const string proc = "SP_SuaKhoanVay_ChoVay";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("id",kt.id),
                 new SqlParameter("ngayvay",kt.ngayvay),
                new SqlParameter("sotien", kt.sotien),
                new SqlParameter("thanhvien", kt.thanhvien),
                new SqlParameter("loai", kt.loai),
                new SqlParameter("nguoivay", kt.nguoivay),
                new SqlParameter("taikhoanchitieu", kt.taikhoanchitieu),
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
        public bool DeleteKhoanChoVay(int id)
        {
            const string proc = "SP_XoaKhoanVay_ChoVay";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("id", id)
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
        public KhoanVay_ChoVay SearchKhoanChoVay(int id)
        {
            const string proc = "SP_TimKiemKhoanChoVay";
            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("id", id)
            };
            IDataReader reader = DataProvider.ExecuteReader(proc, para);
            KhoanVay_ChoVay res = new KhoanVay_ChoVay();
            KhoanVay_ChoVay kthu;
            while (reader.Read())
            {
                kthu = new KhoanVay_ChoVay();

                kthu.id = Convert.ToInt32(reader["id"]);
                kthu.ngayvay = Convert.ToDateTime(reader["NgayVay"]);
                kthu.sotien = Convert.ToInt32(reader["SoTien"]);
                kthu.thanhvien = Convert.ToString(reader["ThanhVien"]);
                kthu.loai = Convert.ToString(reader["Loai"]);
                kthu.nguoivay = Convert.ToString(reader["NguoiVay"]);
                kthu.taikhoanchitieu = Convert.ToString(reader["TaiKhoanChiTieu"]);
                res = kthu;
            }
            return res;
        }
    }
}
