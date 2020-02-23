using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class HomeController: BaseController
    {
        // GET: Client/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}