using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_QLThuChi.Entities
{
    public class KhoanChi
    {
        public int makc { set; get; }
        public string matv { set; get; }
        public DateTime ngay { set; get; }
        public string loaikc { set; get; }
        public double sotien { set; get; }
        
        public string ghichu { set; get; }
        public string tutaikhoan { set; get; }
        //public string tenlkc { get; set; }
      
    }
}
