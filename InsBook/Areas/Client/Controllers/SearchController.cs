using InsBook.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class SearchController: BaseController
    {
        public ActionResult Index(string search_string)
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
            ViewBag.UserOnline = CommonConstants.USER_ONLINE;

            //friendlist va noi dung tim kiem
            ViewBag.FriendList = new FriendDao().GetFriendSearches(search_string, user.UserID);
            ViewBag.search = search_string;

            ViewBag.Session_UserId = user.UserID;
            
            return View();
        }
    }
}