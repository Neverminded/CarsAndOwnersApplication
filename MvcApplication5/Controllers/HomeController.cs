using DomainModel.Abstract;
using DomainModels.Core;
using MvcApplication5.Filtres;
using MvcApplication5.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication5.Controllers
{
   
    public class HomeController : Controller
    {

        [Inject]
        private UoWManager manager;
        public HomeController(UoWManager man)
        {
            manager = man;
        }
        public ActionResult Index()
        {
          
            return View();
        }


    }
}
