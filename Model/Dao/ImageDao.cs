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
    class ImageDao
    {
        InsBookDbContext db = null;
        public ImageDao()
        {
            db = new InsBookDbContext();
        }
        public bool InsertImage(anh img)
        {
            try
            {
                db.anhs.Add(img);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
