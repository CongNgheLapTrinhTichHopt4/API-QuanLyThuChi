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
using System.IO;

namespace WF_QuanLyThuChi.GUI
{
    public partial class frmTrangCaNhan : Form
    {
        public frmTrangCaNhan()
        {
            InitializeComponent();
        }

        private void frmTrangCaNhan_Load(object sender, EventArgs e)
        {
            LoadThongTin();
        }

        public void LoadThongTin()
        {
            ThanhVien tv = MySession.thongtinnguoidung;

            pcbAnhDaiDien.Image = Image.FromFile(@"..\..\Img\" + tv.anhdaidien);
            txtTenHienThi.Text = tv.tenhienthi;
            txtDienThoai.Text = tv.dienthoai;
            txtEmail.Text = tv.email;
            dtpNgaySinh.Value = tv.ngaysinh;
            cboGioiTinh.Text = tv.gioitinh;
        }

        string anhcapnhat = "";

        public string baseAddress = "http://localhost:55410/api/";
        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThanhVien tv = new ThanhVien();
            tv.tenhienthi = txtTenHienThi.Text.Trim();
            tv.email = txtEmail.Text.Trim();
            tv.dienthoai = txtDienThoai.Text.Trim();
            tv.ngaysinh = dtpNgaySinh.Value;
            tv.gioitinh = cboGioiTinh.Text;
            tv.tendangnhap = MySession.tendangnhap;

            if(anhcapnhat != "") //nếu người dùng tải ảnh lên
            {
                tv.anhdaidien = anhcapnhat;
            }
            else //nếu người dùng không tải ảnh lên thì vẫn lấy ảnh cũ
            {
                ThanhVien tv1 = MySession.thongtinnguoidung;
                tv.anhdaidien = tv1.anhdaidien;
                tv.matkhau = tv1.matkhau;
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ThanhVien>("Account?capnhat=true", tv);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    MySession.thongtinnguoidung = tv;
                    MessageBox.Show("Đã cập nhật thông tin cá nhân");
                    LoadThongTin();
                }
                else
                {
                    MessageBox.Show("Lỗi! :(");
                }
            }

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LoadThongTin();
        }

        private void pcbAnhDaiDien_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            //Kiểm tra xem người dùng đã chọn file chưa
            if (result == DialogResult.OK)
            {
                string[] tmp = openFileDialog1.FileNames;
                foreach (string i in tmp)
                {
                    FileInfo fi = new FileInfo(i);
                    string[] xxx = i.Split('\\');
                    string des = @"..\..\Img\" + @"\" + xxx[xxx.Length - 1];
                    File.Delete(des);

                    //over.
                    fi.CopyTo(des);
                }
                // Lấy hình ảnh
                Image img = Image.FromFile(openFileDialog1.FileName);
                // Gán ảnh
                pcbAnhDaiDien.Image = img;
                anhcapnhat = Path.GetFileName(openFileDialog1.FileName);
            }
        }
    }
}