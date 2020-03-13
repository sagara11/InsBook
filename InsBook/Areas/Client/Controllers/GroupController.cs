using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class GroupController : Controller // !!! mai sau sửa lại thành Base !!!
    {
        // GET: Client/Group
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult group_thaoluan()
        {
            return View();
        }
        public ActionResult group_anh()
        {
            return View();
        }
        public ActionResult group_thanhvien()
        {
            return View();
        }
    }
}