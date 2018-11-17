using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_QLThuChi.Entities
{
    public class ThanhVien
    {
        public string tendangnhap { set; get; }
        public string matkhau { set; get; }
        public string tenhienthi { set; get; }
        public DateTime ngaysinh { set; get; }
        public string gioitinh { set; get; }
        public string dienthoai { set; get; }
        public string email { set; get; }
        public string anhdaidien { set; get; }
    }
}
