using DomainModel.Entities;
using DomainModel.SQLSiteMapPath;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication5.Models
{
    public class DataContext:DbContext
    {

        public DataContext()
            : base("DefaultConnection")
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<MySiteMapNode> MyNodesCollection { get; set; }
        public DbSet<RequestUser> RequestsUsers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasMany(c => c.OwnersCar)
                .WithMany(s => s.CarsOwner)
                .Map(t => t.MapLeftKey("Id_car")
                .MapRightKey("Id_owner")
                .ToTable("OwnerCars"));
        }
    }
}