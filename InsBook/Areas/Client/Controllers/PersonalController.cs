using InsBook.Areas.Client.Models;
using InsBook.Common;
using Model.Dao;
using Model.EF;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class PersonalController : Controller // !!! mai sau sửa lại thành Base !!!
    {
        // GET: Client/Personal
        public ActionResult Index()
        {
            var user = new UserLogin();
            if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                // lấy từ cookie
                user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu long
                user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
            }
            else
            {
                user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
            }

            ViewBag.Profile = new UserDao().Profile(user.UserID);

            return View();
        }
        //----------------------CAI DAT CHUNG-------------------------------------------
        public ActionResult ChangeGeneralInfor()
        {
            var user = new UserLogin();
            if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                // lấy từ cookie
                user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu long
                user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
            }
            else
            {
                user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
            }

            ViewBag.Profile = new UserDao().Profile(user.UserID);
            ViewBag.Ten = new UserDao().GetbyName(user.UserID);
            return View();
        }

        public JsonResult ChangeGeneralInforJson()
        {
            if (Session[CommonConstants.USER_SESSION] != null || Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                var user = new UserLogin();
                // Lấy giá trị của cookie hoặc session
                if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
                {
                    // lấy từ cookie
                    user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu int
                    user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
                }
                else
                {
                    user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
                }

                try
                {
                    var data = Request.Form;
                    nguoidung userDB = new nguoidung();
                    userDB.id = user.UserID;
                    userDB.ten = data["ten"];
                    userDB.ho = data["ho"];
                    userDB.sdt = data["sdt"];
                    userDB.ngaysinh = Convert.ToDateTime(data["ngaysinh"]);
                    userDB.gioitinh = data["gioitinh"];


                    if (new UserDao().ChangeGeneralInforDao(userDB))
                    {
                        return Json(new
                        {
                            status = true,
                            data = userDB.ho + " " + userDB.ten
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new
                        {
                            status = false
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        status = false
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult CheckPhone(string phone)
        {
            // Tìm email trong db
            var user = new UserDao().GetbyPhone(phone);

            if (user == null)
            {
                return Json(new
                {
                    status = true
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
        //----------------------DOI MAT KHAU-------------------------------------------
        public ActionResult ChangePassInfo()
        {
            var user = new UserLogin();
            if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                // lấy từ cookie
                user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu long
                user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
            }
            else
            {
                user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
            }

            ViewBag.Profile = new UserDao().Profile(user.UserID);
            return View();
        }
        //----------------------CONG VIEC VA HOC VAN-------------------------------------------
        public ActionResult Job_Edu()
        {
            var user = new UserLogin();
            if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                // lấy từ cookie
                user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu long
                user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
            }
            else
            {
                user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
            }

            ViewBag.Profile = new UserDao().Profile(user.UserID);
            var listdd = new LocationDao().GetAll();
            List<string> tendd = new List<string>();
            foreach (diadiem item in listdd)
            {
                tendd.Add(item.ten);
            }
            ViewBag.TenDD = tendd;
            return View();
        }
        public JsonResult AddJob_Edu()
        {
            if (Session[CommonConstants.USER_SESSION] != null || Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                var user = new UserLogin();
                // Lấy giá trị của cookie hoặc session
                if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
                {
                    // lấy từ cookie
                    user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu int
                    user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
                }
                else
                {
                    user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
                }

                try
                {
                    var data = Request.Form;
                    SetCompany congty = new SetCompany();
                    congty.userID = user.UserID;
                    congty.ten = data["ten"];
                    congty.chucvu = data["chucvu"];
                    congty.diadiem = data["thixa"];
                    congty.batdau = Convert.ToDateTime(data["batdau"]);
                    congty.ketthuc = Convert.ToDateTime(data["ketthuc"]);
                    congty.mota = data["mota"];
                    if(congty.ketthuc == DateTime.MinValue)
                    {
                        congty.ketthuc = null;
                    }
                    congty.baomat = Convert.ToInt16(data["baomat"]);

                    if (new CompanyDao().AddCompany(congty))
                    {
                        return Json(new
                        {
                            status = true
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new
                        {
                            status = false
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        status = false
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
        //----------------------NOI SONG-------------------------------------------
        public ActionResult LivingPlace()
        {
            var user = new UserLogin();
            if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                // lấy từ cookie
                user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu long
                user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
            }
            else
            {
                user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
            }

            ViewBag.Profile = new UserDao().Profile(user.UserID);
            return View();
        }
        public ActionResult Rela_Fami()
        {
            var user = new UserLogin();
            if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                // lấy từ cookie
                user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu long
                user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
            }
            else
            {
                user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
            }

            ViewBag.Profile = new UserDao().Profile(user.UserID);
            return View();
        }
        public ActionResult DetailInfo()
        {
            var user = new UserLogin();
            if (Request.Cookies[CommonConstants.USER_COOKIE] != null)
            {
                // lấy từ cookie
                user.UserID = int.Parse(Request.Cookies[CommonConstants.USER_COOKIE]["1"]); // đang string ép về kiểu long
                user.Email = Request.Cookies[CommonConstants.USER_COOKIE]["2"].ToString();
            }
            else
            {
                user = (UserLogin)Session[CommonConstants.USER_SESSION]; // lấy từ session
            }

            ViewBag.Profile = new UserDao().Profile(user.UserID);
            return View();
        }
        public ActionResult FriendsInfo()
        {
            return View();
        }
        public ActionResult ImagesInfo()
        {
            return View();
        }
        public ActionResult SavedInfo()
        {
            return View();
        }
        public ActionResult AlbumInfo()
        {
            return View();
        }
        public ActionResult VideoInfo()
        {
            return View();
        }
    }
}