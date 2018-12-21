using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Web_QuanLyThuChi.BaseAddress;
using Web_QuanLyThuChi.Sessions;

namespace Web_QuanLyThuChi.Controllers
{
    public class AccountController : Controller
    {
        public string baseAddress = AddressAPI.baseAddress;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Uname, string Pass)
        {
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
                        //luu lại phiên đăng nhập
                        Session[Ses_Admin.Admin] = Uname;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!");
                    }
                }
                return View();
            }
        }

        //Quyên mật khẩu
        [HttpGet]
        public ActionResult QuenMatKhau()
        {
            return View();
        }


        [HttpPost]
        public ActionResult QuenMatKhau(string tendangnhap)
        {
            ThanhVien tv = new ThanhVien();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"Account?Username={tendangnhap}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ThanhVien>();
                    readTask.Wait();

                    tv = readTask.Result;

                    string email = tv.email;
                    string newpass = "qltc"+Random();

                    //cập nhật mật khẩu mới cho tài khoản
                    ResetPassword(tendangnhap, newpass);

                    //Gửi mail mật khẩu mới cho người dùng
                    GuiMail(email, "Mật khẩu mới tài khoản Quản Lý Thu Chi", $"Hi! {tv.tenhienthi}. Mật khẩu mới của bạn là: {newpass}");

                    //Lưu thông tin người đổi mật khẩu vào session
                    Session["Admin"] = tv;

                    return RedirectToAction("XacNhanDaGuiMatKhauMoi");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập không khớp với tài khoản nào!");
                }
                return View();
            }       
        }

        public void ResetPassword(string tendangnhap, string matkhaumoi)
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
            }
        }

        [HttpGet]
        public ActionResult XacNhanDaGuiMatKhauMoi()
        {
            ThanhVien tv = (ThanhVien)Session["Admin"];
            return View(tv);
        }

        ///Tạo tài khoản
        ///Kiểm tra thông tin tài khoản trươc khi thêm
        public int KiemTraThongTin(string tendangnhap, string dienthoai, string email)
        {
            int res = -1;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync($"Account?tendangnhap={tendangnhap}&dienthoai={dienthoai}&email={email}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();

                    res = readTask.Result;
                    return res;
                }
                return res;
            }
        }

        [HttpGet]
        public ActionResult TaoTaiKhoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoTaiKhoan(string tendangnhap, string tenhienthi, string matkhau, DateTime ngaysinh, string gioitinh, string dienthoai, string email)
        {
            int maloi = KiemTraThongTin(tendangnhap, dienthoai, email);
            if(maloi == 1)
            {
                ModelState.AddModelError("", "Tên đăng nhập đã tồn tại!");
            }
            else if(maloi == 2)
            {
                ModelState.AddModelError("", "Số điện thoại đã được liên kết với tài khoản khác!");
            }
            else if (maloi == 3)
            {
                ModelState.AddModelError("", "Email đã được liên kết với tài khoản khác!");
            }
            else if(maloi == 0)
            {
                ThanhVien tv = new ThanhVien();
                tv.tendangnhap = tendangnhap;
                tv.matkhau = matkhau;
                tv.ngaysinh = ngaysinh;
                tv.gioitinh = gioitinh;
                tv.dienthoai = dienthoai;
                tv.email = email;
                tv.tenhienthi = tenhienthi;
                if(gioitinh == "Nam")
                {
                    tv.anhdaidien = "nam.png";
                }
                else
                {
                    tv.anhdaidien = "nu.jpg";
                }

                int maxacthuc = Random();
                Session["MaXacThuc"] = maxacthuc;

                Session["UserTemp"] = tv;

                GuiMail(email, "Xác thực tài khoản Quản Lý Thu Chi", "Mã xác thực tài khoản Quản lý thu chi của bạn là: " + maxacthuc);

                return RedirectToAction("XacThucEmail");
            }
            else
            {
                return Redirect("~/Error/Error");
            }
            return View();
        }

        [HttpGet]
        public ActionResult XacThucEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult XacThucEmail(int verify)
        {
            int maxacthuc = (int)Session["MaXacThuc"];
            if (verify == maxacthuc) //Nếu xác thực được thì tạo tài khoản
            {
                ThanhVien tv = (ThanhVien)Session["UserTemp"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ThanhVien>("Account", tv);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        return Redirect("~/Error/Error");
                    }
                }
            }
            else //không khớp
            {
                ModelState.AddModelError("", "Mã xác thực không khớp. Vui lòng kiểm tra lại mã trong mail");
            }
            return View();
        }


        [HttpGet]
        public ActionResult TrangCaNhan()
        {
            ThanhVien tv = (ThanhVien)Session["ThongTinNguoiDung"];
            return View(tv);
        }
        
        //Cập nhật thông tin cá nhân
        [HttpPost]
        public ActionResult TrangCaNhan(HttpPostedFileBase anhdaidien, string tenhienthi, string email, string dienthoai, DateTime ngaysinh, string gioitinh)
        {
            ThanhVien tv = new ThanhVien();
            if (anhdaidien != null && anhdaidien.ContentLength > 0) //nếu người dùng cập nhật ảnh
            {
                var path = Path.Combine(Server.MapPath("~/Content/img/User/"), Path.GetFileName(anhdaidien.FileName));
                anhdaidien.SaveAs(path);

                tv.anhdaidien = anhdaidien.FileName;
            }
            else // nếu người dùng không thay đổi ảnh thì vẫn để lại ảnh cũ
            {
                ThanhVien tv1 = (ThanhVien)Session["ThongTinNguoiDung"];
                tv.anhdaidien = tv1.anhdaidien;
                tv.matkhau = tv1.matkhau;
            }

            tv.tendangnhap = (string)Session["Admin"];
            tv.ngaysinh = ngaysinh;
            tv.gioitinh = gioitinh;
            tv.dienthoai = dienthoai;
            tv.email = email;
            tv.tenhienthi = tenhienthi;
            
            //Cập nhật lại session
            Session["ThongTinNguoiDung"] = tv;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ThanhVien>("Account?capnhat=true", tv);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("TrangCaNhan");
                }
                else
                {
                    return Redirect("~/Error/Error");
                }
            }
  
        }

        [HttpPost]
        public ActionResult DoiMatKhau(string matkhaucu, string matkhaumoi, string nhaplaimatkhau)
        {
            string thanhvien = (string)Session["Admin"];
            if(matkhaumoi == nhaplaimatkhau)
            {
                ResetPassword(thanhvien, matkhaumoi);
                return Redirect("~/Account/Login");
            }
            else
            {
                ModelState.AddModelError("", "Mã nhập lại không khớp");
            }
            return View();
        }






        public int Random()
        {
            Random ran = new Random();
            int res = ran.Next(100000, 999999);
            return res;
        }

        public void GuiMail(string nguoinhan, string tieude, string noidung)
        {
            SmtpClient smtp = new SmtpClient();
            try
            {
                //ĐỊA CHỈ SMTP Server
                smtp.Host = "smtp.gmail.com";
                //Cổng SMTP
                smtp.Port = 587;
                //SMTP yêu cầu mã hóa dữ liệu theo SSL
                smtp.EnableSsl = true;
                //UserName và Password của mail
                smtp.Credentials = new NetworkCredential("tuanvm197@gmail.com", "vmt13041997");

                //Tham số lần lượt là địa chỉ người gửi, người nhận, tiêu đề và nội dung thư
                smtp.Send("Quản Lý Thu Chi<tuanvm197@gmail.com>", nguoinhan, tieude, noidung);

            }
            catch (Exception ex)
            {
                
            }
        }

    }
}