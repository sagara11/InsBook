using InsBook.Areas.Client.Models;
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
        public ActionResult Index(RegisterModel user)
        {
            if (user.Ho != null && user.Ten != null && user.Email != null && user.Ngaysinh != null && user.Gioitinh != null && user.Matkhau != null && user.XacnhanMatkhau != null)
            {
                var checkEmail = new UserDao().GetbyEmail(user.Email);
                if (checkEmail == null)
                {
                    // mã hóa mật khẩu
                    string pass = Encryptor.MD5Hash(user.Matkhau);
                    user.Matkhau = pass;

                    // tạo kiểu liệu người dùng theo EF
                    nguoidung userDB = new nguoidung();
                    
                    // thêm phần đăng ký vào
                    userDB.ho = user.Ho;
                    userDB.ten = user.Ten;
                    userDB.ngaysinh = user.Ngaysinh;
                    userDB.email = user.Email;
                    userDB.matkhau = user.Matkhau;
                    userDB.gioitinh = user.Gioitinh;
                    userDB.ngaytao = DateTime.Now;
                    userDB.ngaycapnhat = DateTime.Now;
                    userDB.soluongbanbe = 0;
                    userDB.soluongtheodoi = 0;
                    userDB.vaitro = 1;

                    // Thêm vào db
                    var id = new UserDao().Insert(userDB); // trả về kết quả là id
                    if (id > 0)
                    {
                        var userSC = new UserLogin();
                        userSC.Email = user.Email;
                        userSC.UserID = id;
                        
                        //thêm session
                        Session.Add(CommonConstants.USER_SESSION, userSC);
                        Session.Timeout = 300;
                        
                        return RedirectToAction("RegisterStep1","Register");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Register");
                    } 
                }
                else
                {
                    return RedirectToAction("Index", "Register");
                }
            }
            return RedirectToAction("Register", "Index");
        }
        public ActionResult RegisterStep1()
        {
            // Kiểm tra xem có cookie hoặc session không
            if (Session[CommonConstants.USER_SESSION] != null || Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                var user = new UserLogin();
                // Lấy giá trị của cookie hoặc session
                if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
                {
                    // lấy từ cookie
                    user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu long
                    user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
                }
                else
                {
                    user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
                }
                var users = new UserDao().GetbyID(user.UserID);
                ViewBag.ListAddFriend = new AddFriendDao().ListAddFriend(users);

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        //[HttpPost]
        //public ActionResult RegisterStep1()
        //{
            
        //}
        public ActionResult RegisterStep2()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult RegisterStep2()
        //{

        //}
        public ActionResult RegisterStep3()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult RegisterStep3()
        //{
            
        //}
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