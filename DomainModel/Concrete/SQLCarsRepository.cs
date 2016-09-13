using DomainModel.Abstract;
using MvcApplication5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Concrete
{
    public class SQLCarsRepository : IRepository<Car>
    {
        private DataContext datacontext;
        public SQLCarsRepository(DataContext _context)
        {
            datacontext = _context;
        
        }


       
        public IEnumerable<Car> GetAll()
        {

            return datacontext.Cars.OrderBy(m => m.Mark_car).ToList();
            
        }



        public Car GetEntity(int id)
        {

            return datacontext.Cars.FirstOrDefault(c => c.Id_car == id);

        }
        public void Create(Car item)
        {
            datacontext.Cars.Add(item);
            datacontext.SaveChanges();
        }
        public void Update(Car item)
        {
            Car temp = datacontext.Cars.First(c => c.Id_car == item.Id_car);
            
            temp.Mark_car = item.Mark_car;
            temp.Model_car = item.Model_car;
            temp.OwnersCar = item.OwnersCar;
            temp.Price_car = item.Price_car;
            temp.Type_car = item.Type_car;
            temp.Year_of_issue_car = item.Year_of_issue_car;

        //sdatacontext.Cars.Entry(temp).State=EntityState.Modified;
        datacontext.SaveChanges();
        }

        public void Delete(int id)
        {
           Car entity=datacontext.Cars.First(c => c.Id_car == id);
           datacontext.Cars.Remove(entity);
           Save();
        }

      private bool disposed = false;
 
    public virtual void Dispose(bool disposing)
    {
        if(!this.disposed)
        {
            if(disposing)
            {
                datacontext.Dispose();
            }
        }
        this.disposed = true;
    }
 
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    public void Save()
    {
        datacontext.SaveChanges();
    }




    }
}
