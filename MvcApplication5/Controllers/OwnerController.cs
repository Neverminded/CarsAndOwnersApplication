using DomainModels.Core;
using MvcApplication5.Models;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNewProjectOwnersAndCars.Controllers
{
    public class OwnerController : Controller
    {
       [Inject]
        private UoWManager manager;
        public OwnerController(UoWManager man)
        {
            manager = man;
        }

        public ActionResult GetOwners()
        {
            return View(manager.ownerstable.GetAll());
        }

        public ActionResult DetailsOwner(int id)
        {
           

            return View(manager.ownerstable.GetEntity(id));

        }




        /*Ajax action that after the addition of a specific car owner returns a partial view of a model
        with a special type that contains data on it, 
        his cars and cars that he has not acquired
          */
        public PartialViewResult AddCarToOwner(int id_owner,int id_car)
        {
            
            if (Request.IsAjaxRequest())
            {
                Owner temp = manager.ownerstable.GetEntity(id_owner);
                temp.CarsOwner.Add(manager.carstable.GetEntity(id_car));
                manager.ownerstable.Save();
                
            }
            EditOwnerViewModel model = new EditOwnerViewModel();
            model.Owner = manager.ownerstable.GetEntity(id_owner);
            model.Unassigned_cars = GetUnassignedCars(id_owner);

            return PartialView("_tablecarsowner", model);
           
        }

        
         //similar to the previous one, is activated after the removal of the vehicle from a particular owner
         
        public PartialViewResult DeleteCarToOwner(int id_owner, int id_car)
        {

            if (Request.IsAjaxRequest())
            {
                Owner temp = manager.ownerstable.GetEntity(id_owner);
                temp.CarsOwner.Remove(manager.carstable.GetEntity(id_car));
                manager.ownerstable.Save();

            }
            EditOwnerViewModel model = new EditOwnerViewModel();
            model.Owner = manager.ownerstable.GetEntity(id_owner);
            model.Unassigned_cars = GetUnassignedCars(id_owner);

            return PartialView("_tablecarsowner", model);

        }

        [HttpGet]
        public ActionResult EditOwner(int id)
        {
            EditOwnerViewModel model = new EditOwnerViewModel();
            model.Owner = manager.ownerstable.GetEntity(id);
            model.Unassigned_cars = GetUnassignedCars(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditOwner(EditOwnerViewModel entity)
        {

            manager.ownerstable.Update(entity.Owner);
            return RedirectToAction("GetOwners");
        }


        [HttpGet]
        public ActionResult CreateOwner()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateOwner(Owner owner)
        {

            manager.ownerstable.Create(owner);
            return RedirectToAction("GetOwners");
        }

        public PartialViewResult DeleteOwner(int id)
        {
            manager.ownerstable.Delete(id);
           
            return PartialView("_tablebody", manager.ownerstable.GetAll());
        }







        //Help method that returns a list of cars that are not assigned to a specific owner

        private List<Car> GetUnassignedCars(int id_owner)
        {
            List<Car> tempmas = manager.carstable.GetAll().ToList();

            foreach (var item in manager.ownerstable.GetEntity(id_owner).CarsOwner)
            {
                Car removeitem = tempmas.First(c => c.Id_car == item.Id_car);
                if (removeitem != null)
                    tempmas.Remove(removeitem);
            }

            return tempmas;
        }

    }
}
