using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrothersProjects.Controllers.Util
{
    public class HtmlResult : ActionResult
    {
        private string htmlContent;

        public HtmlResult(string content)
        {
            htmlContent = content;
        }

        public void ThisCoolMethodDoentExitInActionResult()
        {
        }

        public override void ExecuteResult(ControllerContext context)
        {
            string fullHtmlCode = "<!DOCTYPE html><html><head>";
            fullHtmlCode += "<title>Главная страница</title>";
            fullHtmlCode += "<meta charset=utf-8 />";
            fullHtmlCode += "</head> <body>";
            fullHtmlCode += htmlContent;
            fullHtmlCode += "</body></html>";
            context.HttpContext.Response.Write(fullHtmlCode);
        }
    }
}