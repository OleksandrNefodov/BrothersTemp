using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrothersProjects.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Brothers()
        {
            HttpContext.Session["username"] = "Oleksandr";

            return View();
        }
    }
}