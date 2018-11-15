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
    public class HanMucChi_DAO
    {
        public List<HanMucChi_View> Get_HanMucChi(string matv, string thoigian)
        {
            const string proc = "SP_XemHanMucChiTheoThang";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("matv", matv),
                new SqlParameter("thoigian", thoigian)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            List<HanMucChi_View> result = new List<HanMucChi_View>();
            HanMucChi_View hmuc;
            while (reader.Read())
            {
                hmuc = new HanMucChi_View();
                hmuc.id = Convert.ToInt32(reader["id"]);
                hmuc.tenlkc = Convert.ToString(reader["TenLKC"]);
                hmuc.sotien = DataProvider.DinhDangTien(Convert.ToString(reader["TongTien"]));
                hmuc.hanmuc = DataProvider.DinhDangTien(Convert.ToString(reader["HanMuc"]));

                int tien = Convert.ToInt32(reader["TongTien"]);
                int hanmuc = Convert.ToInt32(reader["HanMuc"]);
                double phantram = ((double)tien / (double)hanmuc) * 100;

                hmuc.phantram = phantram;

                result.Add(hmuc);
            }

            return result;
        }

        public bool Post_HanMucChi(HanMucChi hmc)
        {
            const string proc = "SP_ThemHanMucChi";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("LoaiKhoanChi", hmc.loaikhoanchi),
                new SqlParameter("HanMuc", hmc.hanmuc),
                new SqlParameter("ThoiGian", hmc.thoigian),
                new SqlParameter("MaTV", hmc.matv)
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

        public bool Put_HanMucChi(HanMucChi hmc)
        {
            const string proc = "SP_SuaHanMucChi";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("id", hmc.id),
                new SqlParameter("LoaiKhoanChi", hmc.loaikhoanchi),
                new SqlParameter("HanMuc", hmc.hanmuc),
                new SqlParameter("ThoiGian", hmc.thoigian),
                new SqlParameter("MaTV", hmc.matv)
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

        public HanMucChi Get_HanMucChiTheoId(int id)
        {
            const string proc = "SP_XemHanMucChiTheoId";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("id", id),
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            HanMucChi res = new HanMucChi();
            HanMucChi hmuc;
            while (reader.Read())
            {
                hmuc = new HanMucChi();
                hmuc.id = Convert.ToInt32(reader["id"]);
                hmuc.loaikhoanchi = Convert.ToInt32(reader["LoaiKhoanChi"]);
                hmuc.thoigian = Convert.ToString(reader["ThoiGian"]);
                hmuc.hanmuc = Convert.ToInt32(reader["HanMuc"]);
                res = hmuc;
            }

            return res;
        }

    }
}
