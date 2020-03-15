using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Model.Dao
{
    public class ImageDao
    {
        InsBookDbContext db = null;
        public ImageDao()
        {
            db = new InsBookDbContext();
        }
        public bool InsertImage(string url, UInt64 time, UInt64 shardId)
        {
            try
            {
                object[] sqlParam =
                    {
                        new SqlParameter("@time", time),
                        new SqlParameter("@shardId", shardId)
                    };

                UInt64 ID = db.Database.SqlQuery<UInt64>("SetIdImage @time, @shardId", sqlParam).Single();

                //var img = new anh();
                //img.id = ID;
                //img.ngaycapnhat = DateTime.Now;

                //db.anhs.Add(img);
                //db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return InsertImage(url, time, shardId);
            }
        }

    }
}
