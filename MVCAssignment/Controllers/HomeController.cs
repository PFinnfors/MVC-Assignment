//Controllers/HomeController.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAssignment.Models;

namespace MVCAssignment.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }
         
        //GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
    }
}