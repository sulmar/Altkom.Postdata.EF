using Altkom.Postdata.EF.DAL.Configurations;
using Altkom.Postdata.EF.DAL.Conventions;
using Altkom.Postdata.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.EF.DAL
{    

    public class RentalBikesContext : DbContext
    {
        #region DbSets

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<Project> Projects { get; set; }        

        #endregion


        public RentalBikesContext()
            : base("RentalConnection")
        {

            // Lazy Loading
            // this.Configuration.LazyLoadingEnabled = false;
            // this.Configuration.ProxyCreationEnabled = false;

            // Automatyczne aplikowanie migracji
            //Database.SetInitializer(
            //    new MigrateDatabaseToLatestVersion<RentalBikesContext, Migrations.Configuration>());

            Database.SetInitializer(new MyInitializer());

            /// DbContext : ObjectContext

            // Pobranie ObjectContext z DbContext
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            
            objectContext.ObjectMaterialized += ObjectContext_ObjectMaterialized;

            this.Database.Log = s => Console.WriteLine(s);


            // globalne wylaczenie sledzenia encji
            // this.Configuration.AutoDetectChangesEnabled = false;

        }

        private void ObjectContext_ObjectMaterialized(object sender, System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs e)
        {

        }

        public override int SaveChanges()
        {
            // ustawienie daty utworzenia
            var added = this.ChangeTracker.Entries<Base>()
                .Where(e=>e.State == EntityState.Added)
                .Select(e=>e.Entity);

            var now = DateTime.UtcNow;

            foreach (var entry in added)
            {
                entry.CreateDate = now;
            }
            
            // ustawienie daty modyfikacji

            var modified = this.ChangeTracker.Entries<Base>()
                .Where(e => e.State == EntityState.Modified)
                .Select(e => e.Entity);

            foreach (var entry in modified)
            {
                entry.ModifiedDate = now;
            }

            return base.SaveChanges();
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


            // TPT
            modelBuilder.Entity<Woman>().ToTable("Woman");
            modelBuilder.Entity<Man>().ToTable("Men");
            

            // TPC
            modelBuilder.Entity<Dog>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Dogs");
            });

            modelBuilder.Entity<Horse>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Horses");
            });




        }


    }
}
