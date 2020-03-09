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
    public class FriendController : Controller
    {
        // GET: Client/Friend
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddFriend(int id2)
        {
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

                var friend = new banbe();
                friend.nguoidung1 = user.UserID;
                friend.nguoidung2 = id2;
                friend.xacnhan = 0;
                friend.nguoihanhdong = user.UserID;
                friend.ngaybatdau = DateTime.Now;
                friend.uutien = 1;

                bool result = new AddFriendDao().InsertFriend(friend);

                return Json(new
                {
                    status = result
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
        public ActionResult DisapearFriend()
        {
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

                string html = "<div class='list - friends - item' id='list - friends - @user.Id'>" +
                    "< div class='friends-item-avatar'>" +
                    "<img src = '~/Images/22904751_688560231353134_2748711313877205190_o.jpg' />" +
                    "</ div >" +
                    "< p class='friends-item-name'><b>@user.Ho @user.Ten</b> là người bạn có thể biết</p>" +
                    "<div class='friends-item-tools'>" +
                    "<button type = 'button' class='btn btn-primary' id-add='@user.Id'>Thêm bạn bè</button>" +
                    "<button type = 'button' class='btn btn-light' id-disapear='@user.Id'>Xóa, gỡ bỏ</button>" +
                    "</div>" +
                    "</div>";

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}