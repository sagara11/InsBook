using Common;
using InsBook.Areas.Client.Models;
using InsBook.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

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
            var link = "localhost:44307/Client/ForgetPass/ChangePass" + "/" + Link(model.Email);

            // Gửi email
            string contents = System.IO.File.ReadAllText(Server.MapPath("~/Assets/template/content.html"));
            contents = contents.Replace("{{Link}}", link);
            var toEmail = model.Email;
            new MailHelper().SendMail(toEmail, "YÊU CẦU THAY ĐỔI MẬT KHẨU", contents);
            
            // xử lý session sống trong 3p
            var forgetPassSession = new ForgetPass();
            forgetPassSession.Email = model.Email;
            Session.Add(CommonConstants.FORGETPASS_SESSION, forgetPassSession);
            Session.Timeout = 3;

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

            return JsonWebToken.Encode(payload, "dung", JwtHashAlgorithm.RS256);
        }
        [HttpGet]
        public ActionResult ChangePass()
        {
            // đường link quá dài 
            // chưa xử lý session
            // chưa xử lý decode link
            // chưa có view cơ bản
            // chưa có view 404
            // Form thay đổi pass trong email chưa hoạt đôngj
            return View();
        }
    }
}