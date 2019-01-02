using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace BrothersProjects.Filters
{
    public class MyAuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IPrincipal user = filterContext.RequestContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                //filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            IPrincipal user = filterContext.RequestContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                //filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                //{
                //    {"controller","Authentication"},
                //    {"Action", "Login"}
                //});
            }
        }
    }
}