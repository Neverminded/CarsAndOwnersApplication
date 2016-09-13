using DomainModel.Abstract;
using DomainModel.Concrete;
using DomainModel.Entities;
using DomainModels.Core;
using MvcApplication5.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DomainModel.Core
{
    public class NinjectDependencyResolver:IDependencyResolver
    {


        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            DataContext dx = new DataContext();
            kernel.Bind<IRepository<Car>>().To<SQLCarsRepository>().WithConstructorArgument("_context",dx);
            kernel.Bind<IRepository<Owner>>().To<SQLOwnersRepository>().WithConstructorArgument("_context", dx);
            kernel.Bind<IRepository<Record>>().To<SQLRecordsRepository>().WithConstructorArgument("_context", dx);
            kernel.Bind<UoWManager>().ToSelf();
    }





    }
}
