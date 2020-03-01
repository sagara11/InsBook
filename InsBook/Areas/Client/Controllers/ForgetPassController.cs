using Common;
using InsBook.Areas.Client.Models;
using InsBook.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace InsBook.Areas.Client.Controllers
{
    public class ForgetPassController : Controller
    {
        // GET: Client/ForgetPass
        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(LoginModel model)
        {
            // xử lý phần đuôi link
            var link = "https://localhost:44307/Client/ForgetPass/ChangePass" + "/" + Link(model.Email);

            // Gửi email
            string contents = System.IO.File.ReadAllText(Server.MapPath("~/Assets/template/content.html"));
            contents = contents.Replace("{{Link}}", link);
            var toEmail = model.Email;
            new MailHelper().SendMail(toEmail, "YÊU CẦU THAY ĐỔI MẬT KHẨU", contents);

            return View();
        }
        private string Link(string email)
        {
            var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var issueTime = DateTime.Now;

            var iat = (int)issueTime.Subtract(utc0).TotalSeconds;
            var exp = (int)issueTime.AddMinutes(3).Subtract(utc0).TotalSeconds; // đoạn mã hóa code chỉ giới hạn trong 3p

            var payload = new
            {
                iss = email,
                exp = exp,
                iat = iat
            };
            // hàm sinh random để có khóa bí mật
            string privateKey = new Accessories().RandomString();
            // xử lý session sống trong 3p
            var forgetPassSession = new ForgetPass();
            forgetPassSession.Email = email;
            forgetPassSession.PrivateKey = privateKey;
            forgetPassSession.TimeOut = exp;

            Session.Add(CommonConstants.FORGETPASS_SESSION, forgetPassSession);
            Session.Timeout = 3;

            return JsonWebToken.Encode(payload, privateKey, JwtHashAlgorithm.RS256);
        }

        public bool checkEmail(string email)
        {
            // xử lý ngay trong view. nếu email ko có thì bấm submit cx ko chạy (ajax)
            // Tìm email trong db
            var user = new UserDao().GetbyEmail(email);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        public ActionResult ChangePass(string id)
        {
            // lấy đối tượng session
            var session = (ForgetPass)Session[CommonConstants.FORGETPASS_SESSION];

            var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var issueTime = DateTime.Now;

            var exp = (int)issueTime.Subtract(utc0).TotalSeconds;

            if (Session[CommonConstants.FORGETPASS_SESSION] != null && (session.TimeOut - exp) >= 0 )
            {
                // decode
                var user = JsonWebToken.Decode(id, session.PrivateKey);
                // chuyển từ json thành mảng
                var address = new JavaScriptSerializer().Deserialize<dynamic>(user);

                if (address["iss"] == session.Email)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            // chưa có view cơ bản
            // chưa có view 404
            // Form thay đổi pass trong email chưa hoạt đông
            // ghi nhớ đăng nhập chưa có ( để tạo cookie ) 
            // thông báo register thiếu, sai ...
            // đổi mật khẩu 
            // 

        }
    }
}