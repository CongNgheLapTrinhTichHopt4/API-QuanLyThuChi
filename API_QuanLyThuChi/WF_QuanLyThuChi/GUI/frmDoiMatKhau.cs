using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanLyThuChi.StaticClass;

namespace WF_QuanLyThuChi.GUI
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        public string baseAddress = "http://localhost:55410/api/";
        private void btnDoi_Click(object sender, EventArgs e)
        {
            try
            {
                string mkcu = MySession.thongtinnguoidung.matkhau;
                if (txtMKcu.Text.Trim() != mkcu)
                {
                    MessageBox.Show("Mật khẩu không chính xác");
                    ActiveControl = txtMKcu;
                    return;
                }

                if (txtMKmoi.Text.Trim() != txtMKnhaplai.Text.Trim())
                {
                    MessageBox.Show("Mật khẩu nhập lại không khớp");
                    ActiveControl = txtMKnhaplai;
                    return;
                }

                if (txtMKmoi.Text.Trim() == "")
                {
                    MessageBox.Show("Không được để trống mật khẩu mới");
                    ActiveControl = txtMKmoi;
                    return;
                }

                if (ResetPassword(MySession.thongtinnguoidung.tendangnhap, txtMKmoi.Text.Trim()))
                {
                    MessageBox.Show("Đã đổi mật khẩu! Vui lòng đăng nhập lại\n Nếu không đăng nhập lại bạn sẽ không thể tiếp tục sử dụng các chức năng!");
                    MySession.tendangnhap = null;
                    MySession.thongtinnguoidung = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi Server :(");
                }
            }
            catch(Exception exx)
            {
                MessageBox.Show(exx.Message);
            }

        }

        public bool ResetPassword(string tendangnhap, string matkhaumoi)
        {
            ThanhVien tv = new ThanhVien();
            tv.tendangnhap = tendangnhap;
            tv.matkhau = matkhaumoi;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ThanhVien>("Account?doimatkhau=true", tv);
                postTask.Wait();

                var result = postTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
