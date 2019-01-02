using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrothersProjects.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Videos()
        {
            return View();
        }
    }
}