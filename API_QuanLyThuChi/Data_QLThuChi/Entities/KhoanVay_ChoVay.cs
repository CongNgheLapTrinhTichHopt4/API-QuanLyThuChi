using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_QLThuChi.Entities
{
    public class KhoanVay_ChoVay
    {
        public int id { set; get; }
        public DateTime ngayvay { set; get; }
        public int sotien { set; get; }
        public string thanhvien { set; get; }
        public string loai { set; get; }
        public string nguoivay { set; get; }
        public string taikhoanchitieu { set; get; }
        
    }
}
