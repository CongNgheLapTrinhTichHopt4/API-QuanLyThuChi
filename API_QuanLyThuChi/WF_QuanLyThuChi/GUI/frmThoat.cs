using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanLyThuChi.Properties;
using WF_QuanLyThuChi.StaticClass;

namespace WF_QuanLyThuChi
{
    public partial class frmThoat : Form
    {
        public frmThoat()
        {
            InitializeComponent();
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            MyProgram.Exit = 2;

            Settings.Default["tendangnhap"] = "";
            Settings.Default["matkhau"] = "";
            Settings.Default.Save();
            this.Close();
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            MyProgram.Exit = 1;
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            MyProgram.Exit = 0 ;
            this.Close();
        }

        private void btnLogOff_MouseMove(object sender, MouseEventArgs e)
        {
            lblLogoff.Text = "Log Out";
            lblCancle.Text = "";
            lblShutdown.Text = "";
        }

        private void btnShutdown_MouseMove(object sender, MouseEventArgs e)
        {
            lblShutdown.Text = "Shut down";
            lblLogoff.Text = "";
            lblCancle.Text = "";
        }

        private void btnCancle_MouseMove(object sender, MouseEventArgs e)
        {
            lblShutdown.Text = "";
            lblLogoff.Text = "";
            lblCancle.Text = "Cancle";
        }

        private void frmThoat_Load(object sender, EventArgs e)
        {
            lblLogoff.Text = "";
            lblCancle.Text = "";
            lblShutdown.Text = "";
        }
    }
}
