﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Dashboard()
        {
            if (Session["uid"] == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            return View("Dashboard");
        }
    }
}