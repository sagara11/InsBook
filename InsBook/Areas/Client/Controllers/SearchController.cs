﻿using InsBook.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsBook.Areas.Client.Controllers
{
    public class SearchController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}