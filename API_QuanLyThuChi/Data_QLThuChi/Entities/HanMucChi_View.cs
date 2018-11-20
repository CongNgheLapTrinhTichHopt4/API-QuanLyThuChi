using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_QLThuChi.Entities
{
    public class HanMucChi_View
    {
        public int id { set; get; }
        public string tenlkc { set; get; }
        public int hanmuc { set; get; }
        public int sotien { set; get; }
        public int sotienconlai { set; get;}
        public double phantram { set; get; }
    }
}
