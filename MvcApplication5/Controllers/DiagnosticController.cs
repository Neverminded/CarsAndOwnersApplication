using DomainModel.Entities;
using MvcApplication5.Models;
using MvcApplication5.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MvcApplication5.Controllers
{
    public class DiagnosticController : Controller
    {
        //
        // GET: /Diagnostic/

        public ActionResult Index(PeriodParams FromBeforePeriod)
        {
            PeriodParams per = new PeriodParams();
            List<RequestUser> lst = new List<RequestUser>();
            lst= per.getResponcesFromTimePeriod(null).ToList();
            ViewBag.collectionvalues = lst;
            
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewData["responcecollection"] = serializer.Serialize(lst);
            RequestUsrViewModel usrmodel = new RequestUsrViewModel();
            usrmodel.MinResponce=lst.OrderBy(r => r.ResponceTime).First();
            usrmodel.MaxResponce = lst.OrderByDescending(r => r.ResponceTime).First();
            usrmodel.TopSlowestPages = lst.OrderByDescending(r => r.ResponceTime).Take(10);
            return View(usrmodel);
        }

        public ActionResult Test()
        {
            
            return View();
        }





        public PartialViewResult GetData(string period)
        {
            RequestUsrViewModel usrmodel = new RequestUsrViewModel();

            if (Request.IsAjaxRequest())
            {
                PeriodParams parameter = new PeriodParams();
                var data = parameter.getResponcesFromTimePeriod(period);
                ViewBag.collectionvalues = data;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                ViewData["responcecollection"] = serializer.Serialize(data);              
                usrmodel.MinResponce = data.OrderBy(r => r.ResponceTime).First();
                usrmodel.MaxResponce = data.OrderByDescending(r => r.ResponceTime).First();
                usrmodel.TopSlowestPages = parameter.getResponcesFromTimePeriod(period).OrderByDescending(r=>r.ResponceTime).Take(10);
               
            }
           
          
            return PartialView("RenderChartAndTablePartial",usrmodel);

        }

       
    }
}
