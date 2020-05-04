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
        protected Int64 Post(baiviet post, int soluonganh) //nếu bài viết chỉ có 1 ảnh thì soluonganh = 1 và những trường hợp còn lại soluonganh = 0
        {
            UInt64 shardId = Convert.ToUInt64(post.nguoitao_id % 2000) << 10;
            Int64 postId = 0;
            if (soluonganh == 1)
            {
                postId = new PostDao().InsertSingleImgPost(post, Convert.ToString(shardId));
            }
            else
            {
                postId = new PostDao().InsertPost(post, Convert.ToString(shardId));
            }

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

                        List<Int64> imgIds = Image(Request.Files, user.UserID, Request.Form);

                        Int64 postId = Post(post, 1);


                        new UserDao().Avatar(user.UserID, imgIds[0]);
                        // lưu vào bài viết ảnh
                        new PostDao().InsertImg(imgIds[0], postId);

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
                    List<Int64> imgIds = new List<Int64>();
                    // thêm bài viết cha
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
                    Int64 postID = 0;
                    if (Request.Files.Count == 1)
                    {
                        postID = Post(post, 1);
                    }
                    else
                    {
                        postID = Post(post, 0);
                    }

                    if (Request.Files.Count > 1)
                    {
                        //thêm ảnh con
                        imgIds = Images(Request.Files, user.UserID);
                        //thêm bài viết con
                        foreach (var img in imgIds)
                        {
                            baiviet postImg = new baiviet();

                            postImg.nguoitao_id = user.UserID;
                            postImg.baomat = Convert.ToInt32(baiviet["security"]); // 
                            postImg.loaibaiviet = 0;
                            postImg.parent_id = postID;

                            var post_id = Post(postImg, 0);
                            post_img_id.Add(post_id);

                            new PostDao().InsertImg(img, post_id);
                        }

                        ImageDao imageDao = new ImageDao();
                        foreach (var img_id in imgIds)
                        {
                            urls.Add(imageDao.GetUrlImage(img_id)); //Lay url
                        }
                    }
                    else if (Request.Files.Count == 1)
                    {
                        imgIds = Images(Request.Files, user.UserID);
                        new PostDao().InsertImg(imgIds[0], postID);
                        ImageDao imageDao = new ImageDao();
                        urls.Add(imageDao.GetUrlImage(imgIds[0])); //Lay url
                    }
                    if (baiviet["friends"].Length != 0)
                    {
                        foreach (var item in baiviet["friends"])
                        {
                            friend_ids.Add(item);
                        }
                    }

                    // id post 1 sẽ có text

                    // tại sao lấy id bài sang cho ảnh

                    // id post 7,8,9,10

                    // id ảnh: 2,3,4,5


                    bool ganthe = true;
                    if (friend_ids.Count > 0)
                    {
                        ganthe = new PostDao().InsertTags(user.UserID, friend_ids, postID);
                    }
                    if (ganthe == true)
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
                        foreach (var imgItem in imgIds)
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
        //Lấy ảnh khi thêm comment
        public JsonResult GetUserAvatar()
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
                    string anh_url = new PostDao().GetAvatar(user.UserID);
                    if (anh_url != "")
                    {
                        return Json(new
                        {
                            status = true,
                            data = anh_url
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
        public bool DeletePost(Int64 postId, Int32 userId)
        {
            try
            {
                var check = new PostDao().DeletePost(postId, userId);
                if (check)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool LikePost(Int64 postId, bool status, int session_userId)
        {
            try
            {
                var like = new PostDao().LikePost(postId, session_userId, status);
                return like;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public post_comment_child CommentPost(Int64 postId, string content, Int64 parent_id, int session_userId)
        {
            try
            {
                UInt64 shardId = Convert.ToUInt64(session_userId % 2000) << 10;
                var comment = new PostDao().CommentPost(postId, session_userId, content, Convert.ToString(shardId), parent_id);
                return comment;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public JsonResult GetPostInfo()
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
                    var post_id = Request.Form["img_post_id"];
                    var post_info = new PostDao().GetSinglePost(Convert.ToInt64(post_id));
                    if (post_info != null)
                    {
                        return Json(new
                        {
                            status = true,
                            data = post_info
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

        public List<dsnguoithich> GetListLikePost(Int64 postId)
        {
            List<dsnguoithich> listlike = new List<dsnguoithich>();
            try
            {
                listlike = new PostDao().GetListLike(postId);
                return listlike;
            }
            catch (Exception ex)
            {
                return listlike;
            }
        }
    }
}