using DomainModel.Entities;
using DomainModels.Core;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication5.Controllers
{
    public class RecordController : Controller
    {
        [Inject]
        private UoWManager manager;
        public RecordController(UoWManager man)
        {
            manager = man;
        }

        public ActionResult GetRecords()
        {
            return View(manager.recordstable.GetAll());
        }

        [HttpGet]
        public ActionResult CreateRecord()
        {

           
            return View();
        }
        [HttpPost]
        public ActionResult CreateRecord(Record rec)
        {

            manager.recordstable.Create(rec);
            return RedirectToAction("GetRecords");
        }

        public ActionResult DetailsRecord(int id)
        {
            Record tempentity = manager.recordstable.GetEntity(id);
            return View(tempentity);

        }

    }
}
