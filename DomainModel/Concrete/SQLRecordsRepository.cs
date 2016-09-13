using DomainModel.Abstract;
using DomainModel.Entities;
using MvcApplication5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Concrete
{
    public class SQLRecordsRepository:IRepository<Record>
    {
        private DataContext datacontext;
        public SQLRecordsRepository(DataContext _context)
        {
            datacontext = _context;
        }

        public IEnumerable<Record> GetAll()
        {

            return datacontext.Records.OrderBy(m => m.Date_publishing).ToList();

        }



        public Record GetEntity(int id)
        {

            return datacontext.Records.FirstOrDefault(c => c.Id_record == id);

        }
        public void Create(Record item)
        {
            item.Date_publishing = DateTime.Now;
            datacontext.Records.Add(item);
            datacontext.SaveChanges();
        }
        public void Update(Record item)
        {
            Record temp = datacontext.Records.First(r => r.Id_record == item.Id_record);
            temp.Id_record = item.Id_record;
            temp.Date_publishing = item.Date_publishing;
            temp.Text_record = item.Text_record;
            temp.Title_record = item.Title_record;
            datacontext.SaveChanges();
        }

        public void Delete(int id)
        {
            datacontext.Records.Remove(datacontext.Records.First(o => o.Id_record == id));
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
