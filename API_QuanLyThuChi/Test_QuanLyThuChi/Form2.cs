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

namespace Test_QuanLyThuChi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string baseAddress = "http://localhost:55410/api/";
        private void button1_Click(object sender, EventArgs e)
        {
            HanMucChi hmc = new HanMucChi();
            hmc.matv = tv.Text.Trim();
            hmc.loaikhoanchi = Convert.ToString(txtloai.Text.Trim());
            hmc.hanmuc = Convert.ToInt32(hm.Text.Trim());
            hmc.thoigian = thoigian.Text.Trim();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<HanMucChi>("HanMucChi", hmc);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm được");
                }
                else
                {
                    MessageBox.Show("K Thêm được");
                }
            }
        }
    }
}
