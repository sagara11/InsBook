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
        //public 
    }
}
