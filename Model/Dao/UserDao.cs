﻿using System;
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
            return db.Database.SqlQuery<string>("select (nguoidung.ho + ' ' + nguoidung.ten) from nguoidung where nguoidung.id=" + id).SingleOrDefault();
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
            catch (Exception ex)
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
        public string GetHo(int useId)
        {
            return db.Database.SqlQuery<string>("select nguoidung.ho from nguoidung where nguoidung.id=" + useId).SingleOrDefault();
        }
        public GetProfileModel Profile(int userId)
        {
            GetProfileModel profile = new GetProfileModel();
            profile = db.Database.SqlQuery<GetProfileModel>("Profile @id", new SqlParameter("@id", userId)).SingleOrDefault();
            if (profile == null)
            {
                profile = db.Database.SqlQuery<GetProfileModel>("BaseProfile @id", new SqlParameter("@id", userId)).SingleOrDefault();
                profile.id = userId;
            }
            else
            {
                profile.moiquanhe = new profile_moiquanhe(profile.moiquanheString);
                profile.id = userId;
            }

            profile.diadiem = db.Database.SqlQuery<profile_diadiem>("Profile_diadiem @id", new SqlParameter("@id", userId)).ToList();

            profile.congty = db.Database.SqlQuery<profile_congty>("Profile_congty @id", new SqlParameter("@id", userId)).ToList();

            profile.truonghoc = db.Database.SqlQuery<profile_truonghoc>("Profile_truonghoc @id", new SqlParameter("@id", userId)).ToList();

            profile.banbe = db.Database.SqlQuery<profile_banbe>("Profile_banbe @id", new SqlParameter("@id", userId)).ToList();

            profile.myalbum = db.Database.SqlQuery<profile_anh>("Profile_myalbum @id", new SqlParameter("@id", userId)).ToList();

            return profile;
        }

        public bool AddDetailInfo(string stringg, int loaithongtin, int userId)
        {
            try
            {
                var user = db.nguoidungs.SingleOrDefault(x => x.id == userId);
                if (loaithongtin == 0)
                {
                    user.mota = stringg;
                }
                else if (loaithongtin == 1)
                {
                    user.bietdanh = stringg;
                }
                else if (loaithongtin == 2)
                {
                    user.loitrichdan = stringg;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteDetailInfo(int loaithongtin, int userId)
        {
            try
            {
                var user = db.nguoidungs.SingleOrDefault(x => x.id == userId);
                if (loaithongtin == 0)
                {
                    user.mota = null;
                }
                else if (loaithongtin == 1)
                {
                    user.bietdanh = null;
                }
                else if (loaithongtin == 2)
                {
                    user.loitrichdan = null;
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditDetailInfo(string stringg, int loaithongtin, int userId)
        {
            try
            {
                var user = db.nguoidungs.SingleOrDefault(x => x.id == userId);
                if (loaithongtin == 0)
                {
                    user.mota = stringg;
                }
                else if (loaithongtin == 1)
                {
                    user.bietdanh = stringg;
                }
                else if (loaithongtin == 2)
                {
                    user.loitrichdan = stringg;
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string GetbyDetailInfo(int loaithongtin, int userId)
        {
            try
            {
                var user = db.nguoidungs.SingleOrDefault(x => x.id == userId);
                if (loaithongtin == 0)
                {
                    return user.mota;
                }
                else if (loaithongtin == 1)
                {
                    return user.bietdanh;
                }
                else if (loaithongtin == 2)
                {
                    return user.loitrichdan;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public List<GetFriendsModel> GetAllName(int userID)
        {
            List<GetFriendsModel> banbe = new List<GetFriendsModel>();
            try
            {
                banbe = db.Database.SqlQuery<GetFriendsModel>("GetFriendInfo @userId", new SqlParameter("@userId", userID)).ToList();
                return banbe;
            }
            catch
            {
                return banbe;
            }
        }
        public string GetAvatar(int userID)
        {
            try
            {
                var user = db.nguoidungs.Find(userID);
                var anh = db.anhs.Find(user.anhdd);
                return anh.anh_url;
            }
            catch
            {
                return "false";
            }
        }
    }
}
