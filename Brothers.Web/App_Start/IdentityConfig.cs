using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Brothers.Common.Models.Context;
using Brothers.Repository.IdentityInfrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace BrothersProjects.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IdentityContext>(IdentityContext.Create);
            app.CreatePerOwinContext<UserManagement>(UserManagement.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Authentication/Login")
            });
        }
    }
}