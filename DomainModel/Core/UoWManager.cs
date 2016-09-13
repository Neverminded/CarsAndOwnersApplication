using DomainModel.Abstract;
using DomainModel.Concrete;
using DomainModel.Entities;
using MvcApplication5.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Core
{
    public class UoWManager
    {

        [Inject]
        public IRepository<Car> carstable{get;set;}
        [Inject]
        public IRepository<Owner> ownerstable { get; set; }
        [Inject]
        public IRepository<Record> recordstable { get; set; }

    }
}
