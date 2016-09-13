using DomainModel.SQLSiteMapPath;
using MvcApplication5.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace MvcApplication5.Filtres
{
    public class SiteMapFilterAttribute : System.Web.Mvc.ActionFilterAttribute
    {



        public string conn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string currenturl = filterContext.RouteData.Values["controller"] + "/" + filterContext.RouteData.Values["action"];
            SiteMapBuilder builder = new SiteMapBuilder(currenturl);
            filterContext.Controller.ViewBag.sitemapnodes= builder.GetSiteMapPath().Reverse<MySiteMapNode>();

        }
    }
}