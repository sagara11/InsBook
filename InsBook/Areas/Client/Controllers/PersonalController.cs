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
            var tendd = new LocationDao().GetAllName();
            ViewBag.TenDD = tendd;
            var tenct = new CompanyDao().GetAllName();
            ViewBag.TenCT = tenct;
            var tenth = new SchoolDao().GetAllName();
            ViewBag.TenTH = tenth;

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