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
            return View();
        }
        public ActionResult ChangeGeneralInfor()
        {
            return View();
        }
        public ActionResult ChangePassInfo()
        {
            return View();
        }
        public ActionResult Job_Edu()
        {
            return View();
        }
        public ActionResult LivingPlace()
        {
            return View();
        }
        public ActionResult Rela_Fami()
        {
            return View();
        }
        public ActionResult DetailInfo()
        {
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