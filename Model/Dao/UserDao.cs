using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.Models;
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
        public nguoidung GetbyPhone(string phone)
        {
            return db.nguoidungs.SingleOrDefault(x => x.sdt == phone);
        }
        public nguoidung GetbyID(int id)
        {
            return db.nguoidungs.Find(id);
        }
        public string GetbyName(int id)
        {
            return db.Database.SqlQuery<string>("select nguoidung.ten from nguoidung where nguoidung.id=" + id).Single();
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

        public bool ChangeGeneralInforDao(nguoidung entity)
        {
            try
            {
                var user = db.nguoidungs.Find(entity.id);
                user.ten = entity.ten;
                user.ho = entity.ho;
                user.sdt = entity.sdt;
                user.ngaysinh = entity.ngaysinh;
                user.gioitinh = entity.gioitinh;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
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
            try
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
            catch (Exception ex)
            {
                return 0;
            }
        }
        public GetProfileModel Profile(int userId)
        {
            GetProfileModel profile = new GetProfileModel();
            profile = db.Database.SqlQuery<GetProfileModel>("Profile @id", new SqlParameter("@id", userId)).Single();

            profile.moiquanhe = new profile_moiquanhe(profile.moiquanheString);

            profile.diadiem = db.Database.SqlQuery<profile_diadiem>("Profile_diadiem @id", new SqlParameter("@id", userId)).ToList();

            profile.congty = db.Database.SqlQuery<profile_congty>("Profile_congty @id", new SqlParameter("@id", userId)).ToList();

            profile.truonghoc = db.Database.SqlQuery<profile_truonghoc>("Profile_truonghoc @id", new SqlParameter("@id", userId)).ToList();

            return profile;
        }
    }
}
