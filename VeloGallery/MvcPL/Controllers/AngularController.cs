﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    public class AngularController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

    }
}
