using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LocationDao
    {
        InsBookDbContext db = null;
        public LocationDao()
        {
            db = new InsBookDbContext();
        }
        public bool InsertLocation(diadiem entity)
        {
            db.diadiems.Add(entity);
            db.SaveChanges();
            return true;
        }
        public List<string> GetAllName()
        {
            return db.Database.SqlQuery<string>("select diadiem.ten from diadiem").ToList();
        }
        public int GetByName(string name)
        {
            var diadiem = db.diadiems.SingleOrDefault(x => x.ten == name);
            return diadiem.id;
        }
    }
}
