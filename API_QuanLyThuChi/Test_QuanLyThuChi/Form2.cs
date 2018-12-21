using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] tmp = openFileDialog1.FileNames;
                foreach (string i in tmp)
                {
                    FileInfo fi = new FileInfo(i);
                    string[] xxx = i.Split('\\');
                    string des = @"..\..\img\" + @"\" + xxx[xxx.Length - 1];
                    File.Delete(des);

                    //over.
                    fi.CopyTo(des);
                }

                MessageBox.Show("ok");
                    
            }
        }
    }
}
