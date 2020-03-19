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
    public class PersonalController : Controller // !!! mai sau sửa lại thành Base !!!
    {
        // GET: Client/Personal
        public ActionResult Index()
        {
            var user = new UserLogin();
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

            ViewBag.Profile = new UserDao().Profile(user.UserID);

            return View();
        }
        public ActionResult ChangeGeneralInfor()
        {
            var user = new UserLogin();
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

            ViewBag.Profile = new UserDao().Profile(user.UserID);
            ViewBag.Ten = new UserDao().GetbyName(user.UserID);
            return View();
        }
        public ActionResult ChangePassInfo()
        {
            var user = new UserLogin();
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

            ViewBag.Profile = new UserDao().Profile(user.UserID);
            return View();
        }
        public ActionResult Job_Edu()
        {
            var user = new UserLogin();
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

            ViewBag.Profile = new UserDao().Profile(user.UserID);
            return View();
        }
        public ActionResult LivingPlace()
        {
            var user = new UserLogin();
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

            ViewBag.Profile = new UserDao().Profile(user.UserID);
            return View();
        }
        public ActionResult Rela_Fami()
        {
            var user = new UserLogin();
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

            ViewBag.Profile = new UserDao().Profile(user.UserID);
            return View();
        }
        public ActionResult DetailInfo()
        {
            var user = new UserLogin();
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

            ViewBag.Profile = new UserDao().Profile(user.UserID);
            return View();
        }
        public ActionResult FriendsInfo()
        {
            return View();
        }
        public ActionResult ImagesInfo()
        {
            return View();
        }
        public ActionResult SavedInfo()
        {
            return View();
        }
        public ActionResult AlbumInfo()
        {
            return View();
        }
        public ActionResult VideoInfo()
        {
            return View();
        }
    }
}