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
        public bool InsertImg(int userId, List<Int64> img_ids, Int64 postID)
        {
            try
            {
                foreach (var img in img_ids)
                {
                    baiviet baiviet = db.baiviets.SingleOrDefault(x => x.id == postID);
                    anh anh = db.anhs.SingleOrDefault(x => x.id == img);
                    baiviet.anhs.Add(anh);

                    db.SaveChanges();
                }
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
    }
}
