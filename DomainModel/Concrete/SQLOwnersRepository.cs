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
    public class SQLOwnersRepository:IRepository<Owner>
    {
        private DataContext datacontext;
        public SQLOwnersRepository(DataContext _context)
        {
            datacontext = _context;
        }

        public IEnumerable<Owner> GetAll()
        {

            return datacontext.Owners.OrderBy(m => m.Surname_owner).ToList();

        }



        public Owner GetEntity(int id)
        {

            return datacontext.Owners.FirstOrDefault(c => c.Id_owner == id);

        }
        public void Create(Owner item)
        {
            datacontext.Owners.Add(item);
            datacontext.SaveChanges();
        }
        public void Update(Owner item)
        {
            Owner temp = datacontext.Owners.First(o => o.Id_owner == item.Id_owner);

            temp.Surname_owner = item.Surname_owner;
            temp.Name_owner = item.Name_owner;
            temp.Birsday_owner = item.Birsday_owner;
            temp.CarsOwner = item.CarsOwner;
            temp.Driving_experience = item.Driving_experience;
            datacontext.SaveChanges();
        }

        public void Delete(int id)
        {
            datacontext.Owners.Remove(datacontext.Owners.First(o=>o.Id_owner==id));
            Save();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
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
