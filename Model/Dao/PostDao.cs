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
        public int CountImgs(Int64 postId)
        {
            try
            {
                return db.Database.SqlQuery<int>("CountPostChilds @postId", new SqlParameter("@postID", postId)).SingleOrDefault();
            }
            catch
            {
                return -1;
            }
        }
        //Hàm check bài viết có trong db không
        public bool checkPost(Int64 postId)
        {
            try
            {
                var post = db.baiviets.Where(x => x.id == postId).SingleOrDefault();
                if (post == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
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
                    //baiviet_ganthe
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditTags(int userId, List<int> tag_add, Int64 postID)
        {
            try
            {
                baiviet post = db.baiviets.SingleOrDefault(x => x.id == postID);
                var tagged = db.Database.SqlQuery<post_ganthe>("GetPostTags @postID", new SqlParameter("@postID", postID)).ToList();
                var tag_del = new List<int>();
                foreach (var tag in tagged)
                {
                    tag_del.Add(tag.id);
                }
                //1,3,2,4: db tag_del
                //4,5,3,6: ajax tag_add
                //xoa: 1,2
                //them: 5,6
                tag_del = tag_del.ToList();
                //Lọc ra những tag cần xóa và thêm
                foreach (var item in tag_add.ToList())
                {
                    if (tag_del.Exists(e => e == item))
                    {
                        tag_del.Remove(item);
                        tag_add.Remove(item);
                    }
                }
                //xóa liên kết
                foreach (var del in tag_del)
                {
                    var user_tag = db.nguoidungs.Where(x => x.id == del).SingleOrDefault();
                    post.nguoidungs1.Remove(user_tag);
                    db.SaveChanges();
                }
                //thêm liên kết
                foreach (var add in tag_add)
                {
                    var user_tag = db.nguoidungs.Where(x => x.id == add).SingleOrDefault();
                    post.nguoidungs1.Add(user_tag);
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
            postimg.id = db.Database.SqlQuery<Int64>("select baiviet_anh.baiviet_id from baiviet_anh where baiviet_anh.anh_id =" + imgId).SingleOrDefault();
            postimg.anh_url = db.Database.SqlQuery<string>("select anh.anh_url from anh where anh.id =" + imgId).SingleOrDefault();

            return postimg;
        }
        public Int64 GetImgId(Int64 postId)
        {
            try
            {
                return db.Database.SqlQuery<Int64>("select baiviet_anh.anh_id from baiviet_anh where baiviet_anh.baiviet_id =" + postId).SingleOrDefault();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public string GetAvatar(int userId)
        {
            return db.Database.SqlQuery<string>("GetAvatar @userId", new SqlParameter("@userId", userId)).SingleOrDefault();
        }
        // lấy bài viết từ db 

        
        public List<GetPostModel> GetAllPost(int userID, int loaitrang, int dem)
        {
            // 1 là tìm bài viết ở trang cá nhân
            // 2 là tìm bài viết ở trang home
            // 3...
            // 4...

            // lấy bài viết
            var posts = new List<GetPostModel>(); // tạo đối tượng rỗng
            if (loaitrang == 1)
            {
                posts = db.Database.SqlQuery<GetPostModel>("GetAllPost @userID", new SqlParameter("@userID", userID)).ToList();
            }
            else if (loaitrang == 2)
            {
                posts = db.Database.SqlQuery<GetPostModel>("GetAllPostNewsFeed @userID", new SqlParameter("@userID", userID)).Skip(dem).Take(4).ToList();
            }
            
            foreach (var post in posts)
            {
                if (post.diadiem_id != null)
                {
                    post.diadiem = db.Database.SqlQuery<string>("select diadiem.ten from diadiem where diadiem.id =" + post.diadiem_id).SingleOrDefault();
                }

                post.ganthe = db.Database.SqlQuery<post_ganthe>("GetPostTags @postID", new SqlParameter("@postID", post.id)).ToList();
                post.anh = db.Database.SqlQuery<post_anh>("GetPostImages @postID", new SqlParameter("@postID", post.id)).ToList();
                post.luotthich = db.Database.SqlQuery<int>("CountPostLike @postID", new SqlParameter("@postID", post.id)).SingleOrDefault();
                post.dsnguoithich = db.Database.SqlQuery<dsnguoithich>("GetListLikePost @postID", new SqlParameter("@postID", post.id)).ToList();
                post.comment = db.Database.SqlQuery<post_comment>("GetPostComment @postID, @parent_id", new SqlParameter("@postID", post.id), new SqlParameter("@parent_id", -1)).ToList();

                if (post.comment.Count > 0)
                {
                    post.luotbinhluan = post.comment.Count;
                    foreach (post_comment item in post.comment)
                    {
                        item.comment_child = db.Database.SqlQuery<post_comment_child>("GetPostComment @postID, @parent_id", new SqlParameter("@postID", post.id), new SqlParameter("@parent_id", item.comment_id)).ToList();
                        if (item.comment_child.Count > 0)
                        {
                            item.luotbinhluan = item.comment_child.Count;
                        }
                    }
                }
                post.thoigiandang = (post.id >> 23) & 0x1FFFFFFFFFF;
            }

            return posts;
        }
        public bool checKPostCanSplit(Int64 postId)
        {
            try
            {
                var post = db.baiviets.Where(x => x.id == postId && x.parent_id == postId).SingleOrDefault();
                if (post != null)
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
        public GetPostModel GetSinglePost(Int64 postId)
        {
            // lấy ba
            var post = db.Database.SqlQuery<GetPostModel>("GetSinglePost @postID", new SqlParameter("@postID", postId)).SingleOrDefault();
            if (post.diadiem_id != null)
            {
                post.diadiem = db.Database.SqlQuery<string>("select diadiem.ten from diadiem where diadiem.id =" + post.diadiem_id).SingleOrDefault();
            }

            post.ganthe = db.Database.SqlQuery<post_ganthe>("GetPostTags @postID", new SqlParameter("@postID", post.id)).ToList();
            post.anh = db.Database.SqlQuery<post_anh>("GetPostImages @postID", new SqlParameter("@postID", post.id)).ToList();
            post.luotthich = db.Database.SqlQuery<int>("CountPostLike @postID", new SqlParameter("@postID", post.id)).SingleOrDefault();
            post.dsnguoithich = db.Database.SqlQuery<dsnguoithich>("GetListLikePost @postID", new SqlParameter("@postID", post.id)).ToList();

            post.comment = db.Database.SqlQuery<post_comment>("GetPostComment @postID, @parent_id", new SqlParameter("@postID", post.id), new SqlParameter("@parent_id", -1)).ToList();

            if (post.comment.Count > 0)
            {
                post.luotbinhluan = post.comment.Count;
                foreach (post_comment item in post.comment)
                {
                    item.comment_child = db.Database.SqlQuery<post_comment_child>("GetPostComment @postID, @parent_id", new SqlParameter("@postID", post.id), new SqlParameter("@parent_id", item.comment_id)).ToList();
                    if (item.comment_child.Count > 0)
                    {
                        item.luotbinhluan = item.comment_child.Count;
                    }
                }
            }
            post.thoigiandang = (post.id >> 23) & 0x1FFFFFFFFFF;

            return post;
        }
        public List<dsnguoithich> GetListLike(Int64 postId)
        {
            return db.Database.SqlQuery<dsnguoithich>("GetListLikePost @postID", new SqlParameter("@postID", postId)).ToList();
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
            catch (Exception ex)
            {
                return false;
            }
        }
        public post_comment_child CommentPost(Int64 postId, int userID, string content, String shardId, Int64 parent_id)
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
                if (parent_id != -1)
                {
                    comment.parent_id = parent_id;
                }
                db.baiviet_binhluan.Add(comment);
                db.SaveChanges();

                var post_comment = new post_comment_child();
                post_comment.comment_id = ID;
                post_comment.post_id = postId; GetAvatar(userID);
                post_comment.noidung = content;
                //post_comment.thoigiandang
                if (parent_id != -1)
                {
                    post_comment.parent_id = parent_id;
                }
                post_comment.idnguoidang = userID;
                post_comment.tennguoidang = new UserDao().GetbyName(userID);
                post_comment.anhnguoidang = GetAvatar(userID);

                return post_comment;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        // Hàm giải mã id lấy thời gian bắt đầu đăng ảnh
        //public DateTime GetPostBegin(Int64 postID);
        //{

        //}
        public bool DeletePost(Int64 postId, int userid)
        {
            // Tìm thông tin bài viết
            var post = db.baiviets.Find(postId);
            if (post.nguoitao_id == userid)
            {
                //xóa bài viết
                //___xóa bài viết bình luận: OK
                //___xóa bài viết thích: OK
                //___bài viết gắn thẻ: OK
                //___bài viết ảnh: đã xóa baiviet_anh và chưa xóa ảnh ảnh trong bảng ảnh
                //___bài viết con: chưa xóa bài viết con
                //______xóa bài con viết bình luận: OK
                //______xóa bài con viết thích: OK
                //______bài viết con gắn thẻ: OK
                //______bài viết con ảnh: đã xóa baiviet_anh và chưa xóa ảnh ảnh trong bảng ảnh
                var post_childs = db.Database.SqlQuery<Int64>("select baiviet.id from baiviet where baiviet.parent_id =" + postId).ToList();

                if (post_childs.Count > 1)
                {
                    db.baiviets.RemoveRange(db.baiviets.Where(p => p.parent_id == postId));
                    db.SaveChanges();
                    db.baiviets.Remove(post);
                    db.SaveChanges();
                }
                else
                {
                    db.baiviets.Remove(post);
                    db.SaveChanges();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SplitPost(Int64 parent_postId, Int64 child_postId)
        {
            var post = db.baiviets.Find(parent_postId);
            try
            {
                post.parent_id = null;
                db.SaveChanges();
                var temp = db.Database.SqlQuery<Int64>("ChangePost_Image @parent_postId, @child_postId", new SqlParameter("@parent_postId", parent_postId), new SqlParameter("@child_postId", child_postId)).SingleOrDefault();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeletePostChild(Int64 postID, int userId, int count_ajax_post_childs, List<dynamic> img_remains)
        //count_ajax_post_childs >= img_remains.count
        {
            var post = db.baiviets.Find(postID);
            var post_childs = db.Database.SqlQuery<post_anh>("GetPostImages @postID", new SqlParameter("@postID", post.id)).ToList();
            try
            {
                if (post.nguoitao_id == userId)
                {
                    if (post_childs.Count == 1)
                    {
                        if (count_ajax_post_childs == 0 && img_remains.Count == 0)
                        {
                            post.parent_id = null;
                            post.anhs.Remove(post.anhs.SingleOrDefault()); // xóa liên két bài viết_ảnh
                            db.SaveChanges();
                            return true;
                        }
                        if (count_ajax_post_childs == 1 && img_remains.Count == 0)
                        {
                            post.anhs.Remove(post.anhs.SingleOrDefault()); // xóa liên két bài viết_ảnh
                            db.SaveChanges();
                            return true;
                        }
                    }
                    else if (post_childs.Count > 1)
                    {
                        if (count_ajax_post_childs == 1 && img_remains.Count == 1)
                        {
                            Int64 img_id = img_remains[0]["id"];
                            db.baiviets.RemoveRange(db.baiviets.Where(p => p.parent_id == postID && p.id != img_id));
                            db.SaveChanges();
                            return true;
                        }
                        else if (img_remains.Count == 0 && count_ajax_post_childs == 0)
                        {
                            db.baiviets.RemoveRange(db.baiviets.Where(p => p.parent_id == postID));
                            db.SaveChanges();
                            return true;
                        }
                        else if (img_remains.Count == 0 && count_ajax_post_childs == 1)
                        {
                            db.baiviets.RemoveRange(db.baiviets.Where(p => p.parent_id == postID));
                            db.SaveChanges();
                            return true;
                        }
                        else if (img_remains.Count > 1 && count_ajax_post_childs > 1) //con lai: 26, 05
                        {
                            foreach (var item in post_childs.ToList()) //db 26, 03, 04, 05
                            {
                                if (img_remains.Exists(e => e["id"] == item.id))
                                {
                                    post_childs.Remove(item);
                                }
                            }
                            foreach (var del in post_childs)
                            {
                                db.baiviets.Remove(db.baiviets.Where(p => p.id == del.id).SingleOrDefault());
                                db.SaveChanges();
                            }
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public baiviet ActionEditPost(GetPostModel post)
        {
            try
            {
                baiviet editPost = db.baiviets.Where(x => x.id == post.id).SingleOrDefault();
                editPost.noidung = post.noidung;
                editPost.baomat = post.baomat;
                editPost.diadiem_id = post.diadiem_id;
                editPost.capnhat = DateTime.Now;
                db.SaveChanges();

                return editPost;
            }
            catch
            {
                return null;
            }
        }
    }
}
