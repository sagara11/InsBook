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

                    var friendID = data["friendID"];

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
                    if (friendID == null)
                    {
                        post.loaibaiviet = 0;
                    }
                    else if (friendID == user.UserID.ToString())
                    {
                        post.loaibaiviet = 0;
                    }
                    else
                    {
                        post.loaibaiviet = 1;
                    }
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
                            if(friendID == null)
                            {
                                postImg.loaibaiviet = 0;
                            }
                            else if(friendID == user.UserID.ToString())
                            {
                                postImg.loaibaiviet = 0;
                            }
                            else
                            {
                                postImg.loaibaiviet = 1;
                            }
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
                        getpost.thoigiandang = (getpost.id >> 23) & 0x1FFFFFFFFFF;


                        var result = new PostDao().AddPostFriend(getpost.id, friendID);


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

        public JsonResult ActionEditPost()
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
                    //Sửa bài viết
                    //__content thay đổi: sửa noidung trong bảng bài viết
                    //__location thay dổi: sửa diadiem_id trong bảng bài viết
                    //__security thay đổi: sửa baomat trong bảng bài viết
                    //__friends thay đổi:
                    // + xóa liên kết mà hủy bỏ trong bảng baiviet_ganthe
                    // + thêm liên kết mới trong bảng baiviet_ganthe
                    // 1 2 3 --> 2,4,5
                    //__imgs thay đổi:
                    // + thêm ảnh dạng file vào bảng ảnh, bài viết và liên kết trong bảng anh_baiviet
                    // + ảnh đã hủy: tìm id của bài viết con đã hủy -> tự động xóa bảng ảnh, bài viết và liên kết trong bảng anh_baiviet
                    // + giữ nguyên: ?
                    //1,2, 2 ảnh mới || db: 1,2,3,4
                    var data = Request.Form;
                    // lấy được bài viết
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic baiviet = serializer.Deserialize<object>(data["post"]);

                    List<string> urls = new List<string>();//ảnh url sau khi thêm mới

                    List<Int64> post_img_id = new List<Int64>();//id bài viết sau khi thêm mới

                    List<int> friend_ids = new List<int>();//lọc ra từ form data lấy friend_id

                    List<Int64> imgIds = new List<Int64>();// id của ảnh sau khi têm mới

                    // sửa bài viết cha
                    GetPostModel post = new GetPostModel();
                    post.id = baiviet["id"];
                    post.noidung = baiviet["content"];
                    post.baomat = Convert.ToInt32(baiviet["security"]);
                    var diadiem_id = new LocationDao().GetByName(baiviet["location"]);
                    if (diadiem_id != -1)
                    {
                        post.diadiem_id = diadiem_id;
                    }
                    //Hàm sửa thông tin chung của bài viết
                    var editPost = new PostDao().ActionEditPost(post);

                    if (baiviet["friends"].Length != 0)
                    {
                        foreach (var item in baiviet["friends"])
                        {
                            friend_ids.Add(item);
                        }
                    }
                    //Hàm sửa gắn thẻ của bài viét
                    new PostDao().EditTags(user.UserID, friend_ids, post.id);

                    //Hàm sửa ảnh của bài viết
                    //trường hợp khi sửa bài viết ảnh
                    //__ajax không có ảnh OK
                    //    __ban đầu có 1 ảnh: chỉ xóa ở bảng baiviet_anh và xóa ảnh và đặt parent id về null OK
                    //    __ban đầu có nhiều ảnh: xóa bài viết con, baiviet_anh và xóa ảnh OK
                    //    __ban đầu không có ảnh: giữ nguyên OK
                    //__ajax có 1 ảnh 
                    //    __ban đầu có 1 ảnh: không tách bài OK
                    //    ____1 ảnh cũ : giữ nguyên OK
                    //    ____1 ảnh ảnh thêm mới: xóa ảnh cũ và liên kết, thêm ảnh mới và thêm liên kết OK
                    //    __ban đầu có nhiều ảnh OK
                    //    ____khi còn 1 ảnh thì không gộp lại với bài viết cha OK
                    //    ____1 ảnh cũ: xóa ảnh cũ đã hủy OK
                    //    ____1 ảnh mới: xóa hết ảnh cũ và 1 ảnh mới OK
                    //    __ban đầu không có ảnh: OK
                    //    ____thêm ảnh mới như khi thêm ava OK
                    //__ajax có nhiều ảnh
                    //    ____ban đầu có 1 ảnh OK
                    //    ______thêm 1 hoặc nhiều ảnh mới: chia bài viết cha ban đầu thành 1 bài viết cha và 1 bài viết ảnh con và thêm ảnh OK
                    //    ________đưa parent_id của bài viết cha về null OK
                    //    ________tạo 1 bài viết con mới, rỗng OK
                    //    ________liên kết từ bài viết cha -> ảnh sang bài viết con mới -> ảnh OK
                    //    ______thêm các ảnh mới OK
                    //    ____ban đầu có nhiều ảnh OK
                    //    ______thêm các ảnh mới OK
                    //    ______xóa ảnh cũ nếu hủy OK
                    //    ____ban đầu không có ảnh OK
                    //    ____thêm các ảnh mới OK
                    var count_db_post_childs = new PostDao().CountImgs(post.id); //from db
                    var count_ajax_post_childs = Request.Files.Count + data.Count - 2; //from ajax

                    List<dynamic> img_remains = new List<dynamic>(); // Những ảnh cũ còn lại sau khi xóa
                    if ((data.Count - 2) > 0)
                    {
                        for (int i = 0; i < data.Count - 2; i++)
                        {
                            JavaScriptSerializer temp1 = new JavaScriptSerializer();
                            dynamic temp2 = temp1.Deserialize<object>(data["post_images_" + i]);
                            img_remains.Add(temp2);
                        }
                    }
                    //for(int j = 0; j < data.Count-2; j++)
                    //{
                    //    var hehe = data["post_images_" + j];
                    //    var hahah = hehe;
                    //}
                    if (count_ajax_post_childs == 0)
                    {
                        if (count_db_post_childs > 0)
                        {
                            new PostDao().DeletePostChild(post.id, user.UserID, count_ajax_post_childs, img_remains);
                        }
                    }
                    else if (count_ajax_post_childs == 1)
                    {
                        if (count_db_post_childs == 1)
                        {
                            //xóa 1 ảnh cũ 
                            new PostDao().DeletePostChild(post.id, user.UserID, count_ajax_post_childs, img_remains);
                            //thêm 1 ảnh mới
                            imgIds = Images(Request.Files, user.UserID);
                            new PostDao().InsertImg(imgIds[0], post.id);

                            ImageDao imageDao = new ImageDao();
                            urls.Add(imageDao.GetUrlImage(imgIds[0])); //Lay url
                        }
                        else if (count_db_post_childs > 1)
                        {
                            if (img_remains.Count == 1)//còn 1 ảnh cũ
                            {
                                var check = new PostDao().checkPost(img_remains[0]["id"]);
                                if (check)
                                {
                                    new PostDao().DeletePostChild(post.id, user.UserID, count_ajax_post_childs, img_remains);
                                }
                            }
                            else if (Request.Files.Count == 1)// thêm 1 ảnh mới
                            {
                                //xóa hết ảnh cũ 
                                new PostDao().DeletePostChild(post.id, user.UserID, count_ajax_post_childs, img_remains);
                                //thêm 1 ảnh mới
                                imgIds = Images(Request.Files, user.UserID);
                                //thêm bài viết ảnh
                                baiviet postImg = new baiviet();

                                postImg.nguoitao_id = user.UserID;
                                postImg.baomat = Convert.ToInt32(baiviet["security"]); // 
                                postImg.loaibaiviet = 0;
                                postImg.parent_id = post.id;

                                var post_id = Post(postImg, 0);
                                post_img_id.Add(post_id);

                                new PostDao().InsertImg(imgIds[0], post_id);

                                ImageDao imageDao = new ImageDao();
                                urls.Add(imageDao.GetUrlImage(imgIds[0])); //Lay url
                            }
                        }
                        else
                        {
                            //thêm 1 ảnh mới
                            imgIds = Images(Request.Files, user.UserID);
                            //thêm bài viết ảnh
                            baiviet postImg = new baiviet();

                            postImg.nguoitao_id = user.UserID;
                            postImg.baomat = Convert.ToInt32(baiviet["security"]); // 
                            postImg.loaibaiviet = 0;
                            postImg.parent_id = post.id;

                            var post_id = Post(postImg, 0);
                            post_img_id.Add(post_id);

                            new PostDao().InsertImg(imgIds[0], post_id);

                            ImageDao imageDao = new ImageDao();
                            urls.Add(imageDao.GetUrlImage(imgIds[0])); //Lay url
                        }
                    }
                    else if (count_ajax_post_childs > 1)
                    {
                        if (count_db_post_childs == 0)
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
                                postImg.parent_id = post.id;

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
                        else if (count_db_post_childs == 1)
                        {
                            var checkSplit = new PostDao().checKPostCanSplit(post.id);
                            if (checkSplit)
                            {
                                //thêm bài viết ảnh
                                baiviet postImg = new baiviet();

                                postImg.nguoitao_id = user.UserID;
                                postImg.baomat = Convert.ToInt32(baiviet["security"]); // 
                                postImg.loaibaiviet = 0;
                                postImg.parent_id = post.id;

                                var post_id = Post(postImg, 0);
                                post_img_id.Add(post_id);

                                //gọi đến hàm tách bài viết
                                var check = new PostDao().SplitPost(post.id, post_id);
                                if (check)
                                {
                                    imgIds = Images(Request.Files, user.UserID);
                                    //thêm bài viết con
                                    foreach (var img in imgIds)
                                    {
                                        postImg = new baiviet();

                                        postImg.nguoitao_id = user.UserID;
                                        postImg.baomat = Convert.ToInt32(baiviet["security"]); // 
                                        postImg.loaibaiviet = 0;
                                        postImg.parent_id = post.id;

                                        var post_child_id = Post(postImg, 0);
                                        post_img_id.Add(post_child_id);
                                        new PostDao().InsertImg(img, post_child_id);
                                    }

                                    ImageDao imageDao = new ImageDao();
                                    foreach (var img_id in imgIds)
                                    {
                                        urls.Add(imageDao.GetUrlImage(img_id)); //Lay url
                                    }
                                }
                            }
                            else
                            {
                                imgIds = Images(Request.Files, user.UserID);
                                //thêm bài viết con
                                foreach (var img in imgIds)
                                {
                                    baiviet postImg = new baiviet();

                                    postImg.nguoitao_id = user.UserID;
                                    postImg.baomat = Convert.ToInt32(baiviet["security"]); // 
                                    postImg.loaibaiviet = 0;
                                    postImg.parent_id = post.id;

                                    var post_child_id = Post(postImg, 0);
                                    post_img_id.Add(post_child_id);
                                    new PostDao().InsertImg(img, post_child_id);
                                }

                                ImageDao imageDao = new ImageDao();
                                foreach (var img_id in imgIds)
                                {
                                    urls.Add(imageDao.GetUrlImage(img_id)); //Lay url
                                }
                            }
                        }
                        else if(count_db_post_childs > 1)
                        {
                            //xóa nhiều bài cũ
                            new PostDao().DeletePostChild(post.id, user.UserID, count_ajax_post_childs, img_remains);
                            //thêm nhiều ảnh mới
                            imgIds = Images(Request.Files, user.UserID);
                            //thêm bài viết con
                            foreach (var img in imgIds)
                            {
                                baiviet postImg = new baiviet();

                                postImg.nguoitao_id = user.UserID;
                                postImg.baomat = Convert.ToInt32(baiviet["security"]); // 
                                postImg.loaibaiviet = 0;
                                postImg.parent_id = post.id;

                                var post_child_id = Post(postImg, 0);
                                post_img_id.Add(post_child_id);
                                new PostDao().InsertImg(img, post_child_id);
                            }

                            ImageDao imageDao = new ImageDao();
                            foreach (var img_id in imgIds)
                            {
                                urls.Add(imageDao.GetUrlImage(img_id)); //Lay url
                            }
                        }
                    }
                    if (true)
                    {
                        if(img_remains.Count >0)
                        {
                            foreach(var remain in img_remains)
                            {
                                var imgId = new PostDao().GetImgId(remain["id"]);
                                imgIds.Add(imgId);
                            }
                        }
                        GetPostModel getpost = new GetPostModel();
                        getpost.id = post.id;
                        getpost.noidung = baiviet["content"];
                        getpost.diadiem = baiviet["location"];
                        getpost.baomat = Convert.ToInt32(baiviet["security"]);
                        List<post_ganthe> tagg = new List<post_ganthe>();
                        if (baiviet["friends"].Length != 0)
                        {
                            foreach (var item in baiviet["friends"])
                            {
                                tagg.Add(new PostDao().GetTagInfo(item));
                            }
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
                        getpost.thoigiandang = (getpost.id >> 23) & 0x1FFFFFFFFFF;

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
        public JsonResult GetAllPostNewsFeed(int dem)
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
                    var baiviet = new PostDao().GetAllPost(user.UserID, 2, dem);
                    return Json(new
                    {
                        status = true,
                        baiviet,
                        userID = user.UserID,
                    }, JsonRequestBehavior.AllowGet);
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