using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinic.Models;
using System.Web.Security;

namespace Clinic.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Check Username and Password 
        /// </summary>
        private bool IsValid(string username, string password)
        {

            bool IsValid = false;

            using (var db = new Models.ClinicEntities())
            {
                var user = db.User.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        IsValid = true;
                    }
                }
                return IsValid;
            }
        }
        
        /// <summary>
        /// Redirect User to Dashboard if its Authenticated
        /// </summary>
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            if (user != null)
            {
                var db = new Models.ClinicEntities();
                var us = db.User.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                if (IsValid(user.Username, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    Session["uid"] = us.Id;
                    ViewBag.Name = user.Name;
                    return RedirectToAction("Dashboard", "Home",user);
                }
                else
                {
                    ModelState.AddModelError("", "Login Unssucces");
                }
                return View(user);
            }
            return View("~/Views/Account/Login.cshtml");
        }

        /// <summary>
        /// Logout
        /// </summary>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["uid"] = null;
            ViewBag.Name = null;
            return RedirectToAction("Login", "Account");
        }

    }
}