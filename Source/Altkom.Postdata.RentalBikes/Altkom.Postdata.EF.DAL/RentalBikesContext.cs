using Altkom.Postdata.EF.DAL.Configurations;
using Altkom.Postdata.EF.DAL.Conventions;
using Altkom.Postdata.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.EF.DAL
{
    public class RentalBikesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<Rental> Rentals { get; set; }


        public RentalBikesContext()
            : base("RentalConnection")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);

            // zmiana domyslnego schematu
            modelBuilder.HasDefaultSchema("alt");

            modelBuilder.Configurations
                .Add(new CustomerConfiguration())
                .Add(new VehicleConfiguration())
                .Add(new RentalConfiguration())
                .Add(new StationConfiguration());


            modelBuilder.Conventions.Add(new DateTimeConvention());
            modelBuilder.Conventions.Add(new StringConvention());
            modelBuilder.Conventions.Add(new KeyConvention());

          //  modelBuilder.Conventions.Add(new CustomConvention());


        }


    }
}
