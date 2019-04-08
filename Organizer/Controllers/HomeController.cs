using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["date"] = DateTime.Now;
            ViewData["message"] = "Un message qui vient du controleur index.";

            return View();
        }
    }
}