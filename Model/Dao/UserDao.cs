using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using PagedList.Mvc;
namespace Model.Dao
{
    public class UserDao
    {
        InsBookDbContext db = null;

        public UserDao()
        {
            db = new InsBookDbContext();
        }
        public int Insert(nguoidung entity)
        {
            db.nguoidungs.Add(entity);
            db.SaveChanges();
            return entity.id;
        }
        
        public nguoidung GetbyEmail(string email)
        {
            return db.nguoidungs.SingleOrDefault(x => x.email == email);
        }
        public nguoidung GetbyID(int id)
        {
            return db.nguoidungs.Find(id);
        }
        //public User ViewDetail(int id)
        //{
        //    return db.Users.Find(id);
        //}
        public bool Update(nguoidung entity)
        {
            try
            {
                var user = db.nguoidungs.Find(entity.id);
                user.ho = entity.ho;
                user.ten = entity.ten;
                if (!string.IsNullOrEmpty(entity.matkhau))
                {
                    user.matkhau = entity.matkhau;
                }
                user.ngaysinh = entity.ngaysinh;
                user.email = entity.email;
                user.matkhau = entity.matkhau;
                user.gioitinh = entity.gioitinh;
                user.ngaytao = DateTime.Now;
                user.ngaycapnhat = DateTime.Now;
                user.soluongbanbe = 0;
                user.soluongtheodoi = 0;
                user.vaitro = 1;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Avatar(int userId, Int64 imgId)
        {
            try
            {
                var user = db.nguoidungs.Find(userId);
                
                user.anhdd = imgId;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return Avatar(userId, imgId);
            }
        }
        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        var user = db.Users.Find(id);
        //        db.Users.Remove(user);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}
        //public bool ChangeStatus(long id)
        //{
        //    var user = db.Users.Find(id);
        //    user.Status = !user.Status;
        //    db.SaveChanges();
        //    return user.Status;
        //}
        public int Login(string email, string passWord)
        {
            var result = db.nguoidungs.SingleOrDefault(x => x.email == email);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.matkhau == passWord)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }

            }

        }
    }
}
