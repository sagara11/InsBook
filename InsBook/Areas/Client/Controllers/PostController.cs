using InsBook.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class PostController : ImageController
    {
        // GET: Client/Post
        protected Int64 Post(baiviet post)
        {
            UInt64 shardId = Convert.ToUInt64(post.nguoitao_id % 2000) << 10;

            Int64 postId = new PostDao().InsertPost(post, Convert.ToString(shardId));

            return postId;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult PostUserAvatar()
        {
            if (Session[CommonConstants.USER_SESSION] != null || Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                var user = new UserLogin();
                // Lấy giá trị của cookie hoặc session
                if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
                {
                    // lấy từ cookie
                    user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu int
                    user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
                }
                else
                {
                    user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
                }

                try
                {
                    List<Int64> imgIds = Image(Request.Files, user.UserID, Request.Form);
                    if (imgIds.Count != 0)
                    {
                        baiviet post = new baiviet();

                        post.nguoitao_id = user.UserID;
                        post.baomat = 0;
                        post.loaibaiviet = 0;

                        Int64 postId = Post(post);

                        new UserDao().Avatar(user.UserID, imgIds[0]);

                        ImageDao imageDao = new ImageDao();
                        string imgData = imageDao.GetUrlImage(imgIds[0]); //Lay url

                        return Json(new
                        {
                            status = true,
                            data = imgData
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
                catch (Exception ex)
                {
                    return Json(new
                    {
                        status = false
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult PostUser()
        {
            return Json(new
            {
                status = false
            }, JsonRequestBehavior.AllowGet);
        }


        //public JsonResult PostGroupBanner()
        //{

        //}
        //public JsonResult PostGroup()
        //{

        //}
        //public JsonResult PostPageBanner()
        //{

        //}
        //public JsonResult PostPage()
        //{

        //}
        //public JsonResult PostEventBanner()
        //{

        //}
        //public JsonResult PostEvent()
        //{

        //}
    }
}