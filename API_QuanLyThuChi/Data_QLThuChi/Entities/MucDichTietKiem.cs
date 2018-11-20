using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_QLThuChi.Entities
{
    public class MucDichTietKiem
    {
        public string matv { set; get; }
        public string maMD { set; get; }
        public string tenmucdich { set; get; }
        public double sotiendukien { set; get; }
        public double sotiendatietkiem { set; get; }
        public DateTime ngaybatdau { set; get; }
        public DateTime ngayketthuc { set; get; }
        public string trangthai { set; get; }
    }
}
