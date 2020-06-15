using InsBook.Areas.Client.Models;
using InsBook.Common;
using Model.Dao;
using Model.EF;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class PersonalController : Controller // !!! mai sau sửa lại thành Base !!!
    {
        // GET: Client/Personal
        public ActionResult Index(int? friend_id)
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
            if (friend_id == null)
            {
                ViewBag.Profile = new UserDao().Profile(user.UserID);
            }
            else
            {
                ViewBag.Profile = new UserDao().Profile(friend_id.Value);
            }
            ViewBag.banbe = new UserDao().Profile(user.UserID).banbe;
            var tendd = new LocationDao().GetAllName();
            ViewBag.TenDD = tendd;
            var banbe = new UserDao().GetAllName(user.UserID);
            ViewBag.BanBe = banbe;
            //var tenchude = new TopicDao().GetAllName();
            //ViewBag.TenDD = tendd;
            // hàm này để load tất cả bài viết trong trang cá nhân
            if(friend_id == null)
            {
                var baiviet1 = new PostDao().GetAllPost(user.UserID, 1, 0);
                ViewBag.BaiViet = baiviet1;
            }
            else
            {
                var baiviet2 = new PostDao().GetAllPost(friend_id.Value, 1, 0);
                ViewBag.BaiViet = baiviet2;
            }
            ViewBag.Session_UserId = user.UserID;
            ViewBag.Avatar = new UserDao().GetAvatar(user.UserID);
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
            var ho= new UserDao().GetHo(user.UserID);
            ViewBag.Ho = ho;
            var hoten = new UserDao().GetbyName(user.UserID);
            var regex = new Regex(Regex.Escape(ho + " "));
            ViewBag.Ten = regex.Replace(hoten, "", 1);
            ViewBag.Session_UserId = user.UserID;

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
            ViewBag.Session_UserId = user.UserID;
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
            var tendd = new LocationDao().GetAllName();
            ViewBag.TenDD = tendd;
            var tenct = new CompanyDao().GetAllName();
            ViewBag.TenCT = tenct;
            var tenth = new SchoolDao().GetAllName();
            ViewBag.TenTH = tenth;
            ViewBag.Session_UserId = user.UserID;

            return View();
        }
        public JsonResult AddJob()
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
                    if (congty.ketthuc == DateTime.MinValue)
                    {
                        congty.ketthuc = null;
                    }
                    congty.baomat = Convert.ToInt16(data["baomat"]);

                    var congty_id = new CompanyDao().AddCompany(congty);
                    if (congty_id != -1)
                    {
                        return Json(new
                        {
                            status = true,
                            data = congty_id
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
        public JsonResult EditJob()
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
                    var result = new CompanyDao().GetById(Convert.ToInt32(data["congty_id"]), user.UserID);
                    if (result != null)
                    {
                        return Json(new
                        {
                            status = true,
                            data = result
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
        public JsonResult ActionEditJob()
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
                    if (congty.ketthuc == DateTime.MinValue)
                    {
                        congty.ketthuc = null;
                    }
                    congty.baomat = Convert.ToInt16(data["baomat"]);
                    var congty_id = new CompanyDao().EditCompany(congty, Convert.ToInt32(data["congty_id"]));
                    if (congty_id != -1)
                    {
                        return Json(new
                        {
                            status = true,
                            data = congty_id
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
        public JsonResult ActionDeleteJob()
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
                    var congty_id = new CompanyDao().DeleteCompany(Convert.ToInt32(data["congty_id"]), user.UserID);
                    if (congty_id == true)
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
        public JsonResult AddSchool()
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
                    SetSchool school = new SetSchool();
                    school.userID = user.UserID;
                    school.ten = data["ten"];
                    school.chuyennganh = data["chuyennganh"];
                    school.batdau = Convert.ToDateTime(data["batdau"]);
                    school.ketthuc = Convert.ToDateTime(data["ketthuc"]);
                    school.mota = data["mota"];
                    school.loaitruong = Convert.ToInt32(data["loaitruong"]);

                    if (school.ketthuc == DateTime.MinValue)
                    {
                        school.ketthuc = null;
                    }
                    school.baomat = Convert.ToInt32(data["baomat"]);

                    var school_id = new SchoolDao().AddSchool(school);
                    if (school_id != -1)
                    {
                        return Json(new
                        {
                            status = true,
                            data = school_id
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
        public JsonResult GetCNName()
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
                    string temp = data["school_name"];
                    var tenCN = new SchoolDao().GetAllNameCN(temp);

                    if (tenCN != null)
                    {
                        return Json(new
                        {
                            status = true,
                            data = tenCN
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
        public JsonResult EditSchool()
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
                    var result = new SchoolDao().GetById(Convert.ToInt32(data["truonghoc_id"]), user.UserID);
                    if (result != null)
                    {
                        return Json(new
                        {
                            status = true,
                            data = result
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
        public JsonResult ActionEditSchool()
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
                    SetSchool truonghoc = new SetSchool();
                    truonghoc.userID = user.UserID;
                    truonghoc.ten = data["ten"];
                    truonghoc.batdau = Convert.ToDateTime(data["batdau"]);
                    truonghoc.ketthuc = Convert.ToDateTime(data["ketthuc"]);
                    truonghoc.mota = data["mota"];
                    if (truonghoc.ketthuc == DateTime.MinValue)
                    {
                        truonghoc.ketthuc = null;
                    }
                    truonghoc.baomat = Convert.ToInt16(data["baomat"]);
                    if (Convert.ToInt32(data["loaitruong"]) == 3)
                    {
                        truonghoc.loaitruong = 3;
                        truonghoc.chuyennganh = data["chuyennganh"];
                    }
                    else if (Convert.ToInt32(data["loaitruong"]) == 2)
                    {
                        truonghoc.loaitruong = 2;
                    }

                    var truonghoc_id = new SchoolDao().EditSchool(truonghoc, Convert.ToInt32(data["truonghoc_id"]));
                    if (truonghoc_id != -1)
                    {
                        return Json(new
                        {
                            status = true,
                            data = truonghoc_id
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
        public JsonResult ActionDeleteSchool()
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
                    var school_id = new SchoolDao().DeleteSchool(Convert.ToInt32(data["school_id"]), user.UserID, Convert.ToInt32(data["loaitruong"]));

                    if (school_id)
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

            var tendd = new LocationDao().GetAllName();
            ViewBag.TenDD = tendd;
            ViewBag.Session_UserId = user.UserID;

            return View();
        }
        public JsonResult AddLocation()
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

                    var diadiem_id = new LocationDao().AddLocation(data["ten"], Convert.ToInt32(data["loaidiadiem"]), Convert.ToInt32(data["baomat"]), user.UserID);
                    if (diadiem_id != -1)
                    {
                        return Json(new
                        {
                            status = true,
                            data = diadiem_id
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
        public JsonResult EditLocation()
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
                    var result = new LocationDao().GetById(Convert.ToInt32(data["diadiem_id"]), user.UserID);
                    if (result != null)
                    {
                        return Json(new
                        {
                            status = true,
                            data = result
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
        public JsonResult ActionDeleteLocation()
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
                    var diadiem_id = new LocationDao().DeleteLocation(Convert.ToInt32(data["diadiem_id"]), user.UserID, Convert.ToInt32(data["loaidiadidem"]));

                    if (diadiem_id)
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
        public JsonResult ActionEditLocation()
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

                    var diadiem_id = new LocationDao().EditLocation(data["ten"], Convert.ToInt32(data["loaidiadiem"]), Convert.ToInt32(data["baomat"]), user.UserID, Convert.ToInt32(data["diadiem_id"]));
                    if (diadiem_id != -1)
                    {
                        return Json(new
                        {
                            status = true,
                            data = diadiem_id
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
        //-------------------------------MOI QUAN HE---------------------------------
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
            ViewBag.Session_UserId = user.UserID;
            return View();
        }
        //-------------------------------THONG TIN CA NHAN---------------------------------
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
            ViewBag.Session_UserId = user.UserID;
            return View();
        }
        public JsonResult AddDetailInfo()
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
                    var loaithongtin = Convert.ToInt32(data["loaithongtin"]);
                    var stringg = "";
                    if (loaithongtin == 0)
                    {
                        stringg = data["gioithieu"];
                    }
                    else if (loaithongtin == 1)
                    {
                        stringg = data["loaibietdanh"] + "@" + data["ten"];
                    }
                    else if (loaithongtin == 2)
                    {
                        stringg = data["trichdan"] + "@" + data["tacgia"];
                    }

                    var check = new UserDao().AddDetailInfo(stringg, Convert.ToInt32(data["loaithongtin"]), user.UserID);
                    if (check)
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
        public JsonResult EditDetailInfo()
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

                    var check = new UserDao().GetbyDetailInfo(Convert.ToInt32(data["loaithongtin"]), user.UserID);
                    if (check != null)
                    {
                        return Json(new
                        {
                            status = true,
                            data = check
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
        public JsonResult ActionEditDetailInfo()
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
                    var loaithongtin = Convert.ToInt32(data["loaithongtin"]);
                    var stringg = "";
                    if (loaithongtin == 0)
                    {
                        stringg = data["gioithieu"];
                    }
                    else if (loaithongtin == 1)
                    {
                        stringg = data["loaibietdanh"] + "@" + data["ten"];
                    }
                    else if (loaithongtin == 2)
                    {
                        stringg = data["trichdan"] + "@" + data["tacgia"];
                    }

                    var check = new UserDao().EditDetailInfo(stringg, Convert.ToInt32(data["loaithongtin"]), user.UserID);
                    if (check)
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
        public JsonResult ActionDeleteDetailInfo()
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

                    var check = new UserDao().DeleteDetailInfo(Convert.ToInt32(data["loaithongtin"]), user.UserID);
                    if (check)
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
        public ActionResult FriendsInfo()
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
            ViewBag.Session_UserId = user.UserID;
            ViewBag.Profile = new UserDao().Profile(user.UserID);

            //var friends = new UserDao().GetAllName(user.UserID);
            //ViewBag.Friends = friends;

            return View();
        }
        public ActionResult ImagesInfo()
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
            ViewBag.Session_UserId = user.UserID;
            var profile = new UserDao().Profile(user.UserID);

            foreach(var item in profile.myalbum)
            {
                var post = new PostDao().GetSinglePost(item.baiviet_id);
                item.sothich = post.luotthich;
                item.sobinhluan = post.luotbinhluan;
            }
            ViewBag.Profile = profile;
            return View();
        }
        public ActionResult SavedInfo()
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
            ViewBag.Session_UserId = user.UserID;
            ViewBag.Profile = new UserDao().Profile(user.UserID);
            return View();
        }
        public ActionResult AlbumInfo()
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
            ViewBag.Session_UserId = user.UserID;
            ViewBag.Profile = new UserDao().Profile(user.UserID);
            return View();
        }
        public ActionResult VideoInfo()
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
            ViewBag.Session_UserId = user.UserID;
            ViewBag.Profile = new UserDao().Profile(user.UserID);
            return View();
        }
    }
}