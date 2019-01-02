﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BrothersProjects.Controllers.Test
{
    public class TestController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            var ip = requestContext.HttpContext.Request.UserHostAddress;

            var response = requestContext.HttpContext.Response;

            response.Write("<h2>Ваш IP-адрес: " + ip + "</h2>");
        }
    }
}