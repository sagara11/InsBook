using InsBook.Areas.Client.Models;
using InsBook.Areas.Client.code;
using InsBook.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class LoginController : Controller
    {
        // GET: Client/Login
        [HttpGet]
        public ActionResult Index()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.Email, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    //Tìm email trong db
                    var user = dao.GetbyEmail(model.Email);
                    //Tạo session
                    var userSession = new UserLogin();
                    userSession.Email = user.email;
                    userSession.UserID = user.id;
                    //thêm session
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    

                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Không tồn tại");
                }
                else if (result == 2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View("Index");
        }
    }
}