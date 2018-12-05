using Data_QLThuChi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Web_QuanLyThuChi.Sessions;

namespace Web_QuanLyThuChi.Controllers
{
    public class AccountController : Controller
    {
        public string baseAddress = "http://localhost:55410/api/";
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

                SendMail(email, "Mã xác thực của bạn", "Mã xác thực tài khoản Quản lý thu chi của bạn là: " + maxacthuc);

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


        /// <summary>
        /// Gửi email từ hệ thống thông qua tài khoản gmail
        /// </summary>
        /// <param name="to">Email người nhận</param>
        /// <param name="subject">Tiêu đề mail</param>
        /// <param name="body">Nội dung mail</param>
        public void SendMail(String to, String subject, String body)
        {
            var from = "Quản Lý Thu Chi <tuanvm197@gmail.com>";
            Send(from, to, subject, body);
        }

        /// <summary>
        /// Gửi email đơn giản thông qua tài khoản gmail
        /// </summary>
        /// <param name="from">Email người gửi</param>
        /// <param name="to">Email người nhận</param>
        /// <param name="subject">Tiêu đề mail</param>
        /// <param name="body">Nội dung mail</param>
        public void Send(String from, String to, String subject, String body)
        {
            String cc = "";
            String bcc = "";
            String attachments = "";
            Send(from, to, cc, bcc, subject, body, attachments);
        }

        /// <summary>
        /// Gửi email thông qua tài khoản gmail
        /// </summary>
        /// <param name="from">Email người gửi</param>
        /// <param name="to">Email người nhận</param>
        /// <param name="cc">Danh sách email những người cùng nhận phân cách bởi dấu phẩy</param>
        /// <param name="bcc">Danh sách email những người cùng nhận phân cách bởi dấu phẩy</param>
        /// <param name="subject">Tiêu đề mail</param>
        /// <param name="body">Nội dung mail</param>
        /// <param name="attachments">Danh sách file định kèm phân cách bởi phẩy hoặc chấm phẩy</param>
        public void Send(String from, String to, String cc, String bcc, String subject, String body, String attachments)
        {
            var message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(from);
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.Body = body;
            message.ReplyToList.Add(from);
            if (cc.Length > 0)
            {
                message.CC.Add(cc);
            }
            if (bcc.Length > 0)
            {
                message.Bcc.Add(bcc);
            }
            if (attachments.Length > 0)
            {
                String[] fileNames = attachments.Split(';', ',');
                foreach (var fileName in fileNames)
                {
                    message.Attachments.Add(new Attachment(fileName));
                }
            }

            // Kết nối GMail
            var client = new SmtpClient("smtp.gmail.com", 25)
            {
                Credentials = new NetworkCredential("tuanvm197@gmail.com", "vmt13041997"),
                EnableSsl = true
            };
            // Gởi mail
            client.Send(message);
        }

    }
}