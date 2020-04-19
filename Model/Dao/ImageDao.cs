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
    public class ImageDao
    {
        InsBookDbContext db = null;
        public ImageDao()
        {
            db = new InsBookDbContext();
        }
        public Int64 InsertImage(string url, String shardId, Int64 img_id)
        {
            try
            {
                //UInt64 time = (new Accessories().GetTime()) << 23;

                //object[] sqlParam =
                //    {
                //        new SqlParameter("@time", Convert.ToString(time)),
                //        new SqlParameter("@shardId", shardId)
                //    };

                //Int64 ID = db.Database.SqlQuery<Int64>("SetIdImage @time, @shardId", sqlParam).Single();
               
                var img = new anh();
                img.id = img_id;
                img.ngaycapnhat = DateTime.Now;
                img.anh_url = url;
                db.anhs.Add(img);
                db.SaveChanges();

                return img_id;
            }
            catch (Exception ex)
            {
                return InsertImage(url, shardId, img_id);
            }
        }
        public string GetUrlImage(Int64 imgId)
        {
            anh img =  db.anhs.SingleOrDefault(x => x.id == imgId);
            return img.anh_url;
        }
    }
}
