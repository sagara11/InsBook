using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class ChatBoxController : Controller // !!! mai sau sửa lại thành Base !!!
    {
        // GET: Client/ChatBox
        public ActionResult Index()
        {
            return View();
        }
    }
}