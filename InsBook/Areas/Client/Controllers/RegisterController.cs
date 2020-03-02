using InsBook.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Client/User
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(nguoidung nguoidung)
        {
            // mã hóa mật khẩu
            string pass = Encryptor.MD5Hash(nguoidung.matkhau);
            nguoidung.matkhau = pass;

            // Thêm vào db
            var result = new UserDao().Insert(nguoidung);

            if (result > 0)
            {
                return RedirectToAction("Index", "Home"); // tạm thời
            }
            else
            {
                return RedirectToAction("Index", "Register");
            }
        }
        public ActionResult PostRegister()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CheckEmail(string email)
        {
            // xử lý ngay trong view. nếu email ko có thì bấm submit cx ko chạy (ajax)
            // Tìm email trong db
            var user = new UserDao().GetbyEmail(email);

            if (user != null)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}