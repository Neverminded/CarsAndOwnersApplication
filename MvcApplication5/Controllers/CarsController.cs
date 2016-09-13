using DomainModels.Core;
using MvcApplication5.Filtres;
using MvcApplication5.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MyNewProjectOwnersAndCars.Controllers
{
   
    public class CarsController : Controller
    {


        [Inject]
        private UoWManager manager;
        public CarsController(UoWManager man)
        {
            manager = man;
        }


        public ActionResult GetCars()
        {
           
            return View(manager.carstable.GetAll());
        }


        [HttpGet]
        public ActionResult CreateCar()
        {

            ViewData["select"] = new List<string>() { "Sedan", "Truck" };
            return View();
        }

        [HttpPost]
        public ActionResult CreateCar(Car car)
        {

            manager.carstable.Create(car);
            return RedirectToAction("GetCars");
        }

        public PartialViewResult DeleteCar(int id)
        {
            manager.carstable.Delete(id);
            return PartialView("_partialcars", manager.carstable.GetAll());
        }

        [HttpGet]
        public ActionResult EditCar(int id)
        {
            Car model = manager.carstable.GetEntity(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCar(Car entity)
        {

            manager.carstable.Update(entity);

            return RedirectToAction("GetCars");
        }


        public ActionResult DetailsCar(int id)
        {
            Car tempentity = manager.carstable.GetEntity(id);
            return View(tempentity);

        }


    }
}
