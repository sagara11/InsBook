using InsBook.Common;
using Model.Dao;
using Model.EF;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
                    if (Request.Files.Count > 0)
                    {
                        baiviet post = new baiviet();

                        post.nguoitao_id = user.UserID;
                        post.baomat = 0;
                        post.loaibaiviet = 0;
                        post.noidung = Request.Form["imgTitle"];
                        Int64 postId = Post(post);
                        List<Int64> imgIds = Image(Request.Files, user.UserID, Request.Form, postId);

                        new UserDao().Avatar(user.UserID, postId);

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
        public JsonResult AddPost()
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
                    var data = Request.Form;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic baiviet = serializer.Deserialize<object>(data["post"]);

                    List<string> urls = new List<string>();
                    List<Int64> post_img_id = new List<Int64>();
                    List<int> friend_ids = new List<int>();
                    if (Request.Files.Count != 0)
                    {
                        foreach (var img in Request.Files)
                        {
                            baiviet postImg = new baiviet();

                            postImg.nguoitao_id = user.UserID;
                            postImg.baomat = 0;
                            postImg.loaibaiviet = 0;


                            post_img_id.Add(Post(postImg));
                        }
                        List<Int64> imgIds = Images(Request.Files, user.UserID, post_img_id);

                        ImageDao imageDao = new ImageDao();
                        foreach (var img_id in imgIds)
                        {
                            urls.Add(imageDao.GetUrlImage(img_id)); //Lay url
                        }
                    }
                    if (baiviet["friends"].Length != 0)
                    {
                        foreach (var item in baiviet["friends"])
                        {
                            friend_ids.Add(item);
                        }
                    }
                    baiviet post = new baiviet();
                    post.nguoitao_id = user.UserID;
                    post.noidung = baiviet["content"];
                    var diadiem_id = new LocationDao().GetByName(baiviet["location"]);
                    if (diadiem_id != -1)
                    {
                        post.diadiem_id = diadiem_id;
                    }
                    post.baomat = Convert.ToInt32(baiviet["security"]);
                    post.loaibaiviet = 0;
                    Int64 postID = Post(post);

                    bool themanh = true;
                    bool ganthe = true;
                    if (post_img_id.Count > 0)
                    {
                        themanh = new PostDao().InsertImg(user.UserID, post_img_id, postID);
                    }
                    if (friend_ids.Count > 0)
                    {
                        ganthe = new PostDao().InsertTags(user.UserID, friend_ids, postID);
                    }
                    if (themanh == true && ganthe == true)
                    {
                        GetPostModel getpost = new GetPostModel();
                        getpost.id = postID;
                        getpost.noidung = baiviet["content"];
                        getpost.diadiem = baiviet["location"];
                        getpost.baomat = Convert.ToInt32(baiviet["security"]);
                        List<post_ganthe> tagg = new List<post_ganthe>();
                        foreach (var item in friend_ids)
                        {
                            tagg.Add(new PostDao().GetTagInfo(item));
                        }
                        getpost.ganthe = tagg;
                        var nguoidang = new PostDao().GetTagInfo(user.UserID);
                        getpost.idnguoidang = nguoidang.id;
                        getpost.tennguoidang = nguoidang.ten;
                        getpost.avatarnguoidang = new PostDao().GetAvatar(user.UserID);
                        List<post_anh> imgg = new List<post_anh>();
                        foreach (var imgItem in post_img_id)
                        {
                            imgg.Add(new PostDao().GetPostImg(imgItem));
                        }
                        getpost.anh = imgg;
                        getpost.thoigiandang = DateTime.Now;

                        return Json(new
                        {
                            status = true,
                            data = getpost
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
    }
}