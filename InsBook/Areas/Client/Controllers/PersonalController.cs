using InsBook.Common;
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

            nguoidung profile = new nguoidung();
            banbe friends = new banbe(); // lấy 6 bạn bè
            baiviet posts = new baiviet(); // 3 bài viết
            anh imgs = new anh(); // lấy 9 ảnh nội bật 

            //ViewBag.ListAddFriend = new AddFriendDao().ListAddFriend(users);
            //
            return View();
        }
        public ActionResult ChangeGeneralInfor()
        {
            return View();
        }
        public ActionResult ChangePassInfo()
        {
            return View();
        }
        public ActionResult Job_Edu()
        {
            return View();
        }
        public ActionResult LivingPlace()
        {
            return View();
        }
        public ActionResult Rela_Fami()
        {
            return View();
        }
        public ActionResult DetailInfo()
        {
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