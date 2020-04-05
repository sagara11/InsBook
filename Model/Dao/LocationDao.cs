using Model.EF;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public bool InsertLocation(diadiem entity) //Hàm này thêm địa điểm hành chính của Việt Nam từ file JSON
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
            if (diadiem == null)
            {
                return -1;
            }
            else
            {
                return diadiem.id;
            }
        }
        public int AddLocation(string ten, int loaidiadiem, int baomat, int user_id) //Hàm này liên kết người dùng vs địa điểm
        {
            try
            {
                int diadiem_id = GetByName(ten);
                if(diadiem_id != -1)
                {
                    nguoidung_diadiem test = db.nguoidung_diadiem.SingleOrDefault(x => x.diadiem_id == diadiem_id && x.nguoidung_id == user_id);
                    if (test == null)
                    {
                        nguoidung_diadiem nd_dd = new nguoidung_diadiem();
                        nd_dd.nguoidung_id = user_id;
                        nd_dd.diadiem_id = diadiem_id;
                        nd_dd.loaidiadiem = loaidiadiem;
                        nd_dd.baomat = baomat;

                        db.nguoidung_diadiem.Add(nd_dd);
                        db.SaveChanges();

                        return diadiem_id;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public profile_diadiem GetById(int diadiem_id, int userId)
        {
            var locations = db.Database.SqlQuery<profile_diadiem>("Profile_diadiem @id", new SqlParameter("@id", userId)).ToList();
            return locations.Find(x => x.diadiem_id == diadiem_id);
        }
        public bool DeleteLocation(int diadiem_id, int nguoidung_id, int loaidiadiem) //Hàm xóa liên kết người dùng địa điểm
        {
            try
            {
                var nd_dd = db.nguoidung_diadiem.SingleOrDefault(x => x.diadiem_id == diadiem_id && x.nguoidung_id == nguoidung_id);

                db.nguoidung_diadiem.Remove(nd_dd);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int EditLocation(string ten, int loaidiadiem, int baomat, int user_id, int location_id)
        {
            try
            {
                int diadiem_id = GetByName(ten);       
                if (diadiem_id != -1)
                {
                    if (location_id == diadiem_id)
                    {
                        nguoidung_diadiem nd_dd = db.nguoidung_diadiem.SingleOrDefault(x => x.diadiem_id == diadiem_id && x.nguoidung_id == user_id);
                        nd_dd.baomat = baomat;
                        db.SaveChanges();

                        return diadiem_id;
                    }
                    else
                    {
                        nguoidung_diadiem test = db.nguoidung_diadiem.SingleOrDefault(x => x.diadiem_id == diadiem_id && x.nguoidung_id == user_id);
                        if (test == null)
                        {
                            nguoidung_diadiem nd_dd = db.nguoidung_diadiem.SingleOrDefault(x => x.diadiem_id == location_id && x.nguoidung_id == user_id);
                            db.nguoidung_diadiem.Remove(nd_dd);

                            nguoidung_diadiem nddd = new nguoidung_diadiem();
                            nddd.nguoidung_id = user_id;
                            nddd.diadiem_id = diadiem_id;
                            nddd.loaidiadiem = loaidiadiem;
                            nddd.baomat = baomat;

                            db.nguoidung_diadiem.Add(nddd);

                            db.SaveChanges();

                            return diadiem_id;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
