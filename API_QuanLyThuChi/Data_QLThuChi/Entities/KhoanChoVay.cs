using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_QLThuChi.Entities
{
    public class KhoanChoVay
    {
        //public int id { set; get; }
        //public DateTime ngayvay { set; get; }
        //public int sotien { set; get; }
        //public string ten { set; get; }
        //public string tentaikhoan { set; get; }

        public int id { set; get; }
        public DateTime ngayvay { set; get; }
        public string nguoivay { set; get; }
        public int sotien { set; get; }
        public int sotiendatra { set; get; }
        public int sotienchuatra { set; get; }
        public string trangthai { set; get; }
    }
}
