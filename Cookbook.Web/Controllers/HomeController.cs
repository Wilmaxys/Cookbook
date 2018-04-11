using Cookbook.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookbook.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.MonMessage = "Bienvenue sur notre site.";

            var applicationUser = new ApplicationUser() { userName = "Benjamin" };

            return View(applicationUser);
        }
    }
}