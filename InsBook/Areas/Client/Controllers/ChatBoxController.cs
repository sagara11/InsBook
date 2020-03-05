using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class ChatBoxController : Controller
    {
        // GET: Client/ChatBox
        public ActionResult Index()
        {
            return View();
        }
    }
}