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
using WF_QuanLyThuChi.Properties;
using WF_QuanLyThuChi.StaticClass;

namespace WF_QuanLyThuChi
{
    public partial class frmLogin : Form
    {
        public string baseAddress = "http://localhost:55410/api/";
        public frmLogin()
        {
            
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cameraControl1.Visible = false;
            lblAlert.Text = "";
            string uname = Settings.Default["tendangnhap"].ToString();
            string pass = Settings.Default["matkhau"].ToString();

            if (uname != "")
            {
                txtUserName.Text = uname;
                txtPassWord.Text = pass;
                btnLogin_Click(null, null);
            }
        }

        ThanhVien tv = new ThanhVien();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text == "")
            {
                ActiveControl = txtUserName;
                lblAlert.Text = "Bạn phải nhập tên đăng nhập!";
                return;
            }
            if (txtPassWord.Text == "")
            {
                ActiveControl = txtPassWord;
                lblAlert.Text = "Bạn phải nhập mật khẩu!";
                return;
            }

            string Uname = txtUserName.Text.Trim();
            string Pass = txtPassWord.Text.Trim();

            int res = 0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"Account?username={Uname}&password={Pass}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();

                    res = readTask.Result;

                    if (res == 1)
                    {
                        cameraControl1.Enabled = false;
                        if (ckbNhoTK.Checked)
                        {
                            Settings.Default["tendangnhap"] = txtUserName.Text.Trim();
                            Settings.Default["matkhau"] = txtPassWord.Text.Trim();
                            Settings.Default.Save();
                        }
                        //luu lại phiên đăng nhập
                        MySession.tendangnhap = Uname;
                        frmMain m = new frmMain();
                        this.Hide();
                        m.ShowDialog();
                        this.Show();
                        KiemTraThoat();
                        lblAlert.Text = "";
                    }
                    else
                    {
                        lblAlert.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";
                    }
                }
            }

        }

        public void KiemTraThoat()
        {
            if (MyProgram.Exit == 1)
            {
                Application.Exit();
            }
            if (MyProgram.Exit == 2)
            {
                txtPassWord.Text = "";
            }

        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPass.Checked)
                txtPassWord.UseSystemPasswordChar = false;
            else txtPassWord.UseSystemPasswordChar = true;
        }

        private void cbTurnOnCam_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTurnOnCam.Checked)
                cameraControl1.Visible = true;
            else
                cameraControl1.Visible = false;
        }
    }
}
