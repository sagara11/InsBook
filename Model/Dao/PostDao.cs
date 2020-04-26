using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Common;

namespace Model.Dao
{
    public class PostDao
    {
        InsBookDbContext db = null;
        public PostDao()
        {
            db = new InsBookDbContext();
        }
        public Int64 InsertPost(baiviet post, String shardId)
        {
            try
            {
                UInt64 time = (new Accessories().GetTime()) << 23;

                object[] sqlParam =
                    {
                        new SqlParameter("@time", Convert.ToString(time)),
                        new SqlParameter("@shardId", shardId)
                    };

                Int64 ID = db.Database.SqlQuery<Int64>("SetIdPost @time, @shardId", sqlParam).Single();

                post.id = ID;
                post.capnhat = DateTime.Now;
                db.baiviets.Add(post);
                db.SaveChanges();



                return ID;
            }
            catch (Exception ex)
            {
                return InsertPost(post, shardId);
            }
        }
        // Hàm này để thêm bài viết mà chỉ có 1 ảnh 
        public Int64 InsertSingleImgPost(baiviet post, String shardId)
        {
            try
            {
                UInt64 time = (new Accessories().GetTime()) << 23;

                object[] sqlParam =
                    {
                        new SqlParameter("@time", Convert.ToString(time)),
                        new SqlParameter("@shardId", shardId)
                    };

                Int64 ID = db.Database.SqlQuery<Int64>("SetIdPost @time, @shardId", sqlParam).Single();

                post.id = ID;
                post.capnhat = DateTime.Now;
                post.parent_id = ID;
                db.baiviets.Add(post);
                db.SaveChanges();

                return ID;
            }
            catch (Exception ex)
            {
                return InsertPost(post, shardId);
            }
        }
        public bool InsertTags(int userId, List<int> friend_ids, Int64 postID)
        {
            try
            {
                foreach (var item in friend_ids)
                {
                    baiviet baiviet = db.baiviets.SingleOrDefault(x => x.id == postID);
                    nguoidung nd = db.nguoidungs.SingleOrDefault(x => x.id == item);
                    baiviet.nguoidungs1.Add(nd);

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool InsertImg(Int64 img_id, Int64 post_id)
        {
            try
            {
                baiviet baiviet = db.baiviets.SingleOrDefault(x => x.id == post_id);
                anh anh = db.anhs.SingleOrDefault(x => x.id == img_id);
                baiviet.anhs.Add(anh);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public post_ganthe GetTagInfo(int friendId)
        {
            post_ganthe posttag = new post_ganthe();
            posttag.id = friendId;
            posttag.ten = db.Database.SqlQuery<string>("select (nguoidung.ho + ' ' + nguoidung.ten) from nguoidung where nguoidung.id =" + friendId).SingleOrDefault();

            return posttag;
        }
        public post_anh GetPostImg(Int64 imgId)
        {
            post_anh postimg = new post_anh();
            postimg.id = imgId;
            postimg.anh_url = db.Database.SqlQuery<string>("select anh.anh_url from anh where anh.id =" + imgId).SingleOrDefault();

            return postimg;
        }
        public string GetAvatar(int userId)
        {
            return db.Database.SqlQuery<string>("GetAvatar @userId", new SqlParameter("@userId", userId)).SingleOrDefault();
        }
        // lấy bài viết từ db 
        public List<GetPostModel> GetAllPost(int userID)
        {
            // lấy ba
            var posts = db.Database.SqlQuery<GetPostModel>("GetAllPost @userID", new SqlParameter("@userID", userID)).ToList();
            foreach (var post in posts)
            {
                if (post.diadiem_id != null)
                {
                    post.diadiem = db.Database.SqlQuery<string>("select diadiem.ten from diadiem where diadiem.id =" + post.diadiem_id).SingleOrDefault();
                }

                post.ganthe = db.Database.SqlQuery<post_ganthe>("GetPostTags @postID", new SqlParameter("@postID", post.id)).ToList();
                post.anh = db.Database.SqlQuery<post_anh>("GetPostImages @postID", new SqlParameter("@postID", post.id)).ToList();
                post.luotthich = db.Database.SqlQuery<int>("CountPostLike @postID", new SqlParameter("@postID", post.id)).SingleOrDefault();

                post.comment = db.Database.SqlQuery<post_comment>("GetPostComment @postID, @parent_id", new SqlParameter("@postID", post.id), new SqlParameter("@parent_id", -1)).ToList();
                
                if (post.comment.Count > 0)
                {
                    post.luotbinhluan = post.comment.Count;
                    foreach ( post_comment item in post.comment)
                    {
                        item.comment_child = db.Database.SqlQuery<post_comment_child>("GetPostComment @postID, @parent_id", new SqlParameter("@postID", post.id), new SqlParameter("@parent_id", item.comment_id)).ToList();
                        if(item.comment_child.Count > 0)
                        {
                            item.luotbinhluan = item.comment_child.Count;
                        }
                    }
                }
                post.thoigiandang = DateTime.Now; // Chưa nghĩ ra hàm giải mà ID
            }

            return posts;
        }
        public bool LikePost(Int64 postId, int userId, bool status)
        {
            try
            {
                var baiviet = db.baiviets.SingleOrDefault(x => x.id == postId);
                var nguoidung = db.nguoidungs.SingleOrDefault(x => x.id == userId);
                if (status)
                {
                    baiviet.nguoidungs2.Add(nguoidung);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    baiviet.nguoidungs2.Remove(nguoidung);
                    db.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public post_comment_child CommentPost( Int64 postId, int userID, string content, String shardId, Int64 parent_id)
        {
            try
            {
                UInt64 time = (new Accessories().GetTime()) << 23; object[] sqlParam =
                     {
                        new SqlParameter("@time", Convert.ToString(time)),
                        new SqlParameter("@shardId", shardId)
                    };

                Int64 ID = db.Database.SqlQuery<Int64>("SetComment @time, @shardId", sqlParam).Single();

                var comment = new baiviet_binhluan();
                comment.id = ID;
                comment.nguoidung_id = userID;
                comment.baiviet_id = postId;
                comment.ngaycapnhat = DateTime.Now;
                comment.noidung = content;
                if(parent_id != -1)
                {
                    comment.parent_id = parent_id;
                }
                db.baiviet_binhluan.Add(comment);
                db.SaveChanges();

                var post_comment = new post_comment_child();
                post_comment.comment_id = ID;
                post_comment.post_id = postId;GetAvatar(userID);
                post_comment.noidung = content;
                //post_comment.thoigiandang
                if(parent_id != -1)
                {
                    post_comment.parent_id = parent_id;
                }
                post_comment.idnguoidang = userID;
                post_comment.tennguoidang = new UserDao().GetbyName(userID);
                post_comment.anhnguoidang = GetAvatar(userID);

                return post_comment;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        // Hàm giải mã id lấy thời gian bắt đầu đăng ảnh
        //public DateTime GetPostBegin(Int64 postID);
        //{

        //}
        //public bool DeletePost(int userid, Int64 postId)
        //{
        //    // Tìm thông tin bài viết
        //    var nguoidang_id = db.Database.SqlQuery<int>("select baiviet.nguoitao_id from baiviet where baiviet.id =" + postId).SingleOrDefault();
        //    if(nguoidang_id == userid)
        //    {
        //        GetPostModel del_post = new GetPostModel();

        //        var post = db.baiviets.Find(postId);

        //        if(post.nguoidungs1.Count > 0)
        //        {
        //            // xóa gắn thẻ của bài viết có parent_id = null hoặc bằng baiviet.id
        //        }

        //        del_post.anh = db.Database.SqlQuery<post_anh>("GetPostImages @postID", new SqlParameter("@postID", postId)).ToList();
        //        if(del_post.anh.Count > 0)
        //        {
        //            if(del_post.anh.Count == 1)
        //            {

        //            }
        //            else
        //            {

        //            }
        //        }
        //        return false;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //    // xóa dòng baiviet_anh
        //    // xóa tất cả bảng anh_
        //    // xóa tất cả bảng baiviet_
        //}
    }
}
