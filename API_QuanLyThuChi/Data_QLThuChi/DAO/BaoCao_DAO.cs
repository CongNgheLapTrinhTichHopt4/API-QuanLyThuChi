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
    public class BaoCao_DAO
    {
        /// <summary>
        /// Load dữ liệu ra biểu đồ cột
        /// </summary>
        /// <returns></returns>
        public List<ThuChiTheoThang> BaoCaoThuChiTheoThang(int nam, string thanhvien) 
        {
            const string proc = "SP_ThongKeThuChi";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("nam", nam),
                new SqlParameter("thanhvien", thanhvien)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            ThuChiTheoThang res;
            List<ThuChiTheoThang> list =new List<ThuChiTheoThang>();

            while (reader.Read())
            {
                res = new ThuChiTheoThang();
                res.thang = Convert.ToInt32(reader["thang"]);
                res.tongthu = Convert.ToInt32(reader["tongthu"]);
                res.tongchi = Convert.ToInt32(reader["tongchi"]);

                list.Add(res);
            }

            return list;
        }

        public List<TinhHinhThuChi> TinhHinhThuChi(string thanhvien)
        {
            const string proc = "SP_ThongKeNgayTuanThangNam";

            List<SqlParameter> para = new List<SqlParameter>()
            {
                new SqlParameter("thanhvien", thanhvien)
            };

            IDataReader reader = DataProvider.ExecuteReader(proc, para);

            TinhHinhThuChi res;
            List<TinhHinhThuChi> list = new List<TinhHinhThuChi>();

            while (reader.Read())
            {
                res = new TinhHinhThuChi();
                res.KhoangThoiGian = Convert.ToString(reader["KhoangThoiGian"]);
                res.ThoiGian = Convert.ToString(reader["ThoiGian"]);
                res.TongThu = Convert.ToInt32(reader["TongThu"]);
                res.TongChi = Convert.ToInt32(reader["TongChi"]);

                list.Add(res);
            }

            return list;
        }

    }
}
