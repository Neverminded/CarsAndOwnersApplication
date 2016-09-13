using DomainModel.Entities;
using MvcApplication5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication5.Filtres
{
    public class GlobalRequestsAttribute: System.Web.Mvc.ActionFilterAttribute
    {
        private Stopwatch watch;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            watch = new Stopwatch();
            watch.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            watch.Stop();
            DataContext context = new DataContext();
            RequestUser entityresponcetime = new RequestUser();
            entityresponcetime.DateRequest = DateTime.Now;
            entityresponcetime.IpUser = filterContext.HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? filterContext.HttpContext.Request.UserHostAddress;
            entityresponcetime.PathToPage= filterContext.RouteData.Values["controller"] + "/" + filterContext.RouteData.Values["action"];
            entityresponcetime.ResponceTime = watch.ElapsedMilliseconds;
            entityresponcetime.TitlePage = filterContext.HttpContext.Request.HttpMethod;
            entityresponcetime.StatusCode = filterContext.HttpContext.Response.StatusCode.ToString();
            entityresponcetime.Browser = filterContext.HttpContext.Request.Browser.Browser;
            context.RequestsUsers.Add(entityresponcetime);
            context.SaveChanges();
            base.OnResultExecuted(filterContext);
        }

    }
    
}