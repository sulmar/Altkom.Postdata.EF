namespace Altkom.Postdata.RentalBikes.DatabaseFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Dogs> Dogs { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Horses> Horses { get; set; }
        public virtual DbSet<Men> Men { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Rentals> Rentals { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<Woman> Woman { get; set; }
        public virtual DbSet<Stations> Stations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.Identifier)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Rentals)
                .WithOptional(e => e.Customers)
                .HasForeignKey(e => e.Rentee_CustomerId);

            modelBuilder.Entity<Dogs>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<Dogs>()
                .Property(e => e.Owner)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Projects)
                .WithMany(e => e.Employees)
                .Map(m => m.ToTable("EmployeeProjects", "alt").MapLeftKey("Employee_EmployeeId").MapRightKey("Project_ProjectId"));

            modelBuilder.Entity<Horses>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<Men>()
                .Property(e => e.Hobby)
                .IsUnicode(false);

            modelBuilder.Entity<People>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<People>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<People>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<People>()
                .HasOptional(e => e.Men)
                .WithRequired(e => e.People);

            modelBuilder.Entity<People>()
                .HasOptional(e => e.Woman)
                .WithRequired(e => e.People);

            modelBuilder.Entity<Projects>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Rentals>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Vehicles>()
                .Property(e => e.Number)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Vehicles>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicles>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicles>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Vehicles>()
                .HasMany(e => e.Rentals)
                .WithOptional(e => e.Vehicles)
                .HasForeignKey(e => e.Bike_VehicleId);

            modelBuilder.Entity<Woman>()
                .Property(e => e.LikesColor)
                .IsUnicode(false);

            modelBuilder.Entity<Stations>()
                .Property(e => e.Symbol)
                .IsUnicode(false);

            modelBuilder.Entity<Stations>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Stations>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Stations>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Stations>()
                .HasMany(e => e.Rentals)
                .WithOptional(e => e.Stations)
                .HasForeignKey(e => e.FromStation_StationId);

            modelBuilder.Entity<Stations>()
                .HasMany(e => e.Rentals1)
                .WithOptional(e => e.Stations1)
                .HasForeignKey(e => e.ToStation_StationId);
        }
    }
}
