using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.Controllers
{
    public class PaitientController : Controller
    {
        public ActionResult CreateNewPaitient()
        {
            return View("CreateNewPaitient");
        }
        public ActionResult ListOfPaitient()
        {
            return View("ListOfPaitients");
        }
    }
}