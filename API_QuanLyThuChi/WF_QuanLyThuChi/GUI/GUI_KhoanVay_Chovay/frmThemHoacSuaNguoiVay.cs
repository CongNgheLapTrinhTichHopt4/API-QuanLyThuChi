using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WF_QuanLyThuChi.StaticClass;
using Data_QLThuChi.Entities;
using System.Net.Http;

namespace WF_QuanLyThuChi.GUI.GUI_KhoanVay_Chovay
{
    public partial class frmThemHoacSuaNguoiVay : DevExpress.XtraEditors.XtraForm
    {
       

        public frmThemHoacSuaNguoiVay()
        {
            InitializeComponent();
        }

        int themhoacsua = NguoiVay_Session.themhoacsua;
        private void frmThemHoacSuaNguoiVay_Load(object sender, EventArgs e)
        {
           
            if (NguoiVay_Session.themhoacsua == 1)//vua click them
            {
                btnThem.Text = "Thêm";

            }
            else//vua click sua
            {
                btnThem.Text = "Sửa";
                NguoiVay nv = LayNguoiVayTheoMa();
                txtTen.Text = nv.ten;
                txtSDT.Text = Convert.ToString(nv.sdt);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private NguoiVay LayNguoiVayTheoMa()
        {
            int manv = NguoiVay_Session.ma;

            NguoiVay kt = new NguoiVay();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"NguoiVay/{manv}");

                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<NguoiVay>();
                    readTask.Wait();

                    kt = readTask.Result;
                    return kt;
                }
                else
                {
                    return null;
                }
            }
            
        }

        public string baseAddress = "http://localhost:55410/api/";
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (themhoacsua==1)
            {
                NguoiVay nv = new NguoiVay();

                nv.ten = txtTen.Text;
                nv.sdt = Convert.ToInt32(txtSDT.Text.Trim());


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<NguoiVay>("NguoiVay", nv);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã thêm người vay");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi server!");
                    }
                }
            }
            else
            {
                NguoiVay nv = new NguoiVay();
                nv.id = Convert.ToString( NguoiVay_Session.ma);
                nv.ten = txtTen.Text;
                nv.sdt = Convert.ToInt32(txtSDT.Text.Trim());



                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<NguoiVay>("NguoiVay", nv);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã sửa");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi server!");
                    }
                }
            }



           
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}