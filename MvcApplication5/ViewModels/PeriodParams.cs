using DomainModel.Entities;
using MvcApplication5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication5.ViewModels
{
    public class PeriodParams
    {
        public string StatePeriod { get; set; }
        public DateTime FromPeriod { get; set; }
        public DateTime BeforePeriod { get; set; }
        private DataContext context = new DataContext();
        public IEnumerable<RequestUser> getResponcesFromTimePeriod(string stateperiod=null) {
            this.StatePeriod = stateperiod;
            switch (this.StatePeriod) {
                case "1 hour": {
                        DateTime temp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour - 1, DateTime.Now.Minute, DateTime.Now.Second);

                        return context.RequestsUsers.Where(r => r.DateRequest >= temp);

                    }

                case "1 day":
                    {
                        DateTime temp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day-1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                        return context.RequestsUsers.Where(r => r.DateRequest >= temp);

                    }

                case "1 mounth":
                    {
                        DateTime temp = new DateTime(DateTime.Now.Year, DateTime.Now.Month-1, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                        return context.RequestsUsers.Where(r => r.DateRequest >= temp);

                    }

                case "1 year":
                    {
                        DateTime temp = new DateTime(DateTime.Now.Year-1, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                        return context.RequestsUsers.Where(r => r.DateRequest >= temp);

                    }

                case " period":
                    {
                       
                        return context.RequestsUsers.Where(r => r.DateRequest >= this.FromPeriod&& r.DateRequest <= this.BeforePeriod);

                    }
                default:
                    {
                        DateTime temp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour-1, DateTime.Now.Minute, DateTime.Now.Second);
                        return context.RequestsUsers.Where(r => r.DateRequest >= temp);
                    }
                  

            }

        }
    }
}