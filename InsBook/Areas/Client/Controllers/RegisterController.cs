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
            // !!! thiếu kiểm tra trong controller !!!

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
        public ActionResult RegisterStep1()
        {
            // Kiểm tra xem có cookie hoặc session không
            if (Session[CommonConstants.USER_SESSION] != null || Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                // Lấy giá trị của cookie hoặc session
                if (Session[CommonConstants.USER_SESSION] != null)
                {
                    var user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
                }
                else
                {
                    // lấy từ cookie
                    var user = new UserLogin();
                    user.UserID = long.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu long
                    user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString(); 
                }

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult RegisterStep2()
        {
            return View();
        }
        public ActionResult RegisterStep3()
        {
            return View();
        }
        [HttpGet]
        public JsonResult CheckEmail(string email)
        {
            // Tìm email trong db
            var user = new UserDao().GetbyEmail(email);

            if (user != null)
            {
                return Json(new
                {
                    status = true
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}