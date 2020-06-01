using InsBook.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class HomeController : BaseController // !!! mai sau sửa lại thành Base !!!
    {
        // GET: Client/Home
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
            var Profile = new UserDao().Profile(user.UserID);
            ViewBag.Profile = Profile;
            ViewBag.banbe = Profile.banbe;
            var tendd = new LocationDao().GetAllName();
            ViewBag.TenDD = tendd;
            ViewBag.UserOnline = CommonConstants.USER_ONLINE;
            if (!CommonConstants.USER_ONLINE.Contains(user.UserID))
            {
                ViewBag.CheckOnline = "$(function () {$.connection.hub.start().done(function () {checkLogin(" + user.UserID + ")});});";
            }
            else
            {
                ViewBag.CheckOnline = " ";
            }
            //var tenchude = new TopicDao().GetAllName();
            //ViewBag.TenDD = tendd;
            // hàm này để load tất cả bài viết trong trang cá nhân
            var baivet = new PostDao().GetAllPost(user.UserID, 2, 0);
            ViewBag.BaiViet = baivet;
            ViewBag.Session_UserId = user.UserID;
            return View();
        }
    }
}