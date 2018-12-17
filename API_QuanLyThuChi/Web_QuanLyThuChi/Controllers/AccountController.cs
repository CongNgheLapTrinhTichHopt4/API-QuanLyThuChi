using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
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
        public ActionResult TaoTaiKhoan(string tendangnhap, string matkhau, DateTime ngaysinh, string gioitinh, string dienthoai, string email)
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
                tv.tenhienthi = "Người Dùng";
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