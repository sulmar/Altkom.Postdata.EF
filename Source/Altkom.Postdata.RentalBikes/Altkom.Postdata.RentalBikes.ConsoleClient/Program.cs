using Altkom.Postdata.EF.DAL;
using Altkom.Postdata.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Altkom.Postdata.RentalBikes.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            BatchUpdateTest();

            AddProjectTest();

            RemoveEmployeeFromProjectTest();

            LazyLoadingTest();

            EagerlyLoadingTest();

            


          //  GetVehiclesTest();


           // AddRentalTest2();
            // AddCustomerTest();

             // AddBikeTest();
            // AddStationsTest();

            //AddRentalTest();
           

            //DetachTest();

            //AddTest();

            //UpdateTest();


            using (var context = new RentalBikesContext())
            {
                var connection  = context.Database.Connection;

                Console.WriteLine(connection.ConnectionString);
            }

            AddPeopleTest();

            GetScootersTest();

                // CheckExistsDatabaseTest();

            

         

            GetVehiclesTest();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        private static void BatchUpdateTest()
        {
            using (var context = new RentalBikesContext())
            {

                var projects = context.Projects.ToList();

                foreach (var project in projects)
                {
                    project.Description = "Opis...";
                }

                context.SaveChanges();

            }
        }

        private static void RemoveEmployeeFromProjectTest()
        {
            using (var context = new RentalBikesContext())
            {
                var project = context.Projects
                    .Include(p=>p.Employees).First();

                project.Employees.Remove(project.Employees.First());

                context.SaveChanges();

            }
        }

        private static void AddProjectTest()
        {
            var project = new Project
            {
                ProjectName = "Postdata/EF",
                Description = "Szkolenie EF",
                Employees = new List<Employee>
                {
                    new Employee { FirstName = "Marcin", LastName = "Sulecki", Salary = 1000 },
                    new Employee { FirstName = "Bartek", LastName = "Sulecki", Salary = 6000 },
                }
                
            };

            using (var context = new RentalBikesContext())
            {
                context.Projects.Add(project);

                context.SaveChanges();
            }

        }

        private static void LazyLoadingTest()
        {
            using (var context = new RentalBikesContext())
            {
                var rental = context.Rentals.First(r=>r.RentalId == 1);

                Console.WriteLine(rental.Rentee.FirstName);
            }
        }

        private static void EagerlyLoadingTest()
        {
            using (var context = new RentalBikesContext())
            {

                // Eagerly Loading

                var rental = context.Rentals
                    .Include(d => d.FromStation)
                    .Include(d => d.Bike)
                    // .Include("Bike.Owner")
                    // .Include( d=>d.Bike).Select(s=>s.Owner).Include(d=>d.Address))
                    .First();

            }
        }

        private static void AddStationsTest()
        {
            var stations = new List<Station>
            {
                new Station {
                    Symbol = "ST001",
                    Name = "PKP",
                    Address = "Dworcowa",
                    Capacity = 10,
                    Location = new Location { Latitude = 52.01, Longitude = 23.05, Altitude= 0 },
                    CreateDate = DateTime.Now,
                },

                new Station {
                    Symbol = "ST002",
                    Name = "Nabrzeżna",
                    Address = "Morska",
                    Capacity = 65,
                    Location = new Location { Latitude = 52.51, Longitude = 23.05, Altitude= 0 },
                    CreateDate = DateTime.Now,
                },

                new Station {
                    Symbol = "ST003",
                    Name = "Altkom",
                    Address = "Chłodna",
                    Capacity = 17,
                    Location = new Location { Latitude = 52.01, Longitude = 28.05, Altitude= 0 },
                    CreateDate = DateTime.Now,
                }
            };

            using (var context = new RentalBikesContext())
            {
                context.Stations.AddRange(stations);

                context.SaveChanges();
            }
        }

        private static void AddRentalTest2()
        {

            var rental = new Rental
            {                
                Rentee = new Customer
                {
                    CustomerId = 1,
                    FirstName = "Marcin",
                    LastName = "Sulecki"
                },

                Bike = new Bike
                {
                    VehicleId = 1,
                    BikeType = BikeType.Town,
                    Color = "Green" },

                FromStation = new Station
                {
                    StationId = 3,
                    Name = "Altkom",
                    Address= "Chłodna",
                },


               ToStation = new Station
                {
                    StationId = 3,
                    Name = "Altkom",
                    Address = "Chłodna",
                },


                CreateDate = DateTime.Now,
            };

            using (var context = new RentalBikesContext())
            {
                context.Rentals.Add(rental);

                Console.WriteLine(context.Entry(rental).State);

                context.Entry(rental.Rentee).State = System.Data.Entity.EntityState.Unchanged;

                Console.WriteLine(context.Entry(rental.Rentee).State);

                context.Entry(rental.Bike).State = System.Data.Entity.EntityState.Unchanged;

                Console.WriteLine(context.Entry(rental.Bike).State);

                context.Entry(rental.FromStation).State = System.Data.Entity.EntityState.Unchanged;
                Console.WriteLine(context.Entry(rental.FromStation).State);

                context.Entry(rental.ToStation).State = System.Data.Entity.EntityState.Unchanged;
                Console.WriteLine(context.Entry(rental.ToStation).State);


                Console.WriteLine(context.Entry(rental).State);

                context.SaveChanges();
            }
        }

        private static void AddRentalTest()
        {


            using (var context = new RentalBikesContext())
            {
                var customer = context.Customers
                    .FirstOrDefault(c => c.Identifier == "848484730");

                Console.WriteLine(context.Entry(customer).State);

                var bike = context.Vehicles.OfType<Bike>().First();

                var station = context.Stations.Single(s => s.Symbol == "ST001");

                var rental = new Rental
                {
                    Rentee = customer,
                    Bike = bike,
                    FromStation = station,
                };

                context.Rentals.Add(rental);

                Console.WriteLine(context.Entry(rental).State);

                context.SaveChanges();

                //var lastBike = context.Vehicles.OfType<Bike>()
                //    .OrderBy(b=>b.VehicleId)
                //    .Last();

                //rental.Bike = lastBike;

                context.SaveChanges();

                Console.WriteLine(context.Entry(rental).State);

            }
        }

        private static void DetachTest()
        {

            // deserializacja
            var customer = new Customer
            {
                CustomerId = 1,
                FirstName = "Bartek",
                LastName = "Sulecki",
                Identifier = "47437373",
                PhoneNumber = "555-666-777",
                Email = "bartosz.sulecki@altkom.pl",
            };

            using (var context = new RentalBikesContext())
            {

                // zła praktyka!
                //var cust = context.Customers
                //    .SingleOrDefault(d => d.CustomerId == customer.CustomerId);
                //cust.Email = "kasia.sulecka@altkom.pl";

                //var customer = context.Customers
                //    .AsNoTracking()
                //    .First(p => p.Identifier == "848484730");

                Console.WriteLine(context.Entry(customer).State);

                // context.Customers.Add(customer);

                context.Customers.Attach(customer);

                // modyfikacja całego obiektu
            // context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
        
                // modyfikacja wybranych pól
                context.Entry(customer).Property(p => p.PhoneNumber).IsModified = true;
                context.Entry(customer).Property(p => p.Email).IsModified = true;

                Console.WriteLine(context.Entry(customer).State);

                context.SaveChanges();

            }
        }

        private static void AddTest()
        {
            using (var context = new RentalBikesContext())
            {
                var customer = new Customer
                {
                    FirstName = "Bartek",
                    LastName = "Sulecki",   
                    Identifier = "47437373",                 
                    PhoneNumber = "555-666-777" };

                Console.WriteLine(context.Entry(customer).State);

                context.Customers.Add(customer);

                Console.WriteLine(context.Entry(customer).State);

                context.SaveChanges();

                Console.WriteLine(context.Entry(customer).State);

                customer.PhoneNumber = "444-555-666";
                customer.Identifier = "99999999";

                Console.WriteLine(context.Entry(customer).State);

                context.SaveChanges();

                Console.WriteLine(context.Entry(customer).State);

                context.Customers.Remove(customer);

                Console.WriteLine(context.Entry(customer).State);

                context.SaveChanges();

                Console.WriteLine(context.Entry(customer).State);
            }
        }

        private static void UpdateTest()
        {
            using (var context = new RentalBikesContext())
            {
                var customer = context.Customers
                    .First(p => p.Identifier == "848484730");

                customer.PhoneNumber = "777-777-777";
                
                context.SaveChanges();
            }
        }

        private static void AddPeopleTest()
        {
            var people = new List<Person>
            {
                new Man {
                    FirstName = "Marcin",
                    LastName = "Sulecki",
                    BirthDate = DateTime.Today,
                    Hobby = "fizyka"
                    },

                new Woman
                {
                    FirstName  = "Kasia",
                    LastName = "Sulecka",
                    BirthDate = DateTime.Today,
                    LikesColor = "Green"
                }


            };

            using (var context = new RentalBikesContext())
            {
                context.Persons.AddRange(people);

                context.SaveChanges();
            }
        }

        private static void CheckExistsDatabaseTest()
        {
            using (var context = new RentalBikesContext())
            {
                if (!context.Database.CompatibleWithModel(false))
                {
                    Console.WriteLine("Niezgodna struktura z modelem");
                }

                context.Database.Delete();

                if (!context.Database.Exists())
                {
                    Console.WriteLine("Brak bazy danych");

                    context.Database.CreateIfNotExists();

                    
                }

                
            }
        }

        private static void GetVehiclesTest()
        {
            using (var context = new RentalBikesContext())
            {
                var vehicles = context.Vehicles.ToList();

                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine(vehicle.Number);
                }
            }
        }

        private static void GetScootersTest()
        {
            using (var context = new RentalBikesContext())
            {
                var vehicles = context.Vehicles
                    .OfType<Scooter>()
                    .ToList();

                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine(vehicle.Number);
                }
            }
        }

        private static void AddBikeTest()
        {
            var bike = new Bike
            {
                Number = "R001",
                BikeType = BikeType.Town,
                Color = "Green",
                ProductionYear = 2016,
                Size = "16",
                IsActive = true
            };

            var scooter = new Scooter
            {
                Number = "S001",
                ProductionYear = 2010,
                Capacity = 250,
                IsActive = true
            };

            using (var context = new RentalBikesContext())
            {
                context.Vehicles.Add(bike);
                context.Vehicles.Add(scooter);

                context.SaveChanges();
            }
        }

        private static void AddCustomerTest()
        {
            var customer = new Customer
            {
                FirstName = "Marcin",
                LastName = "Sulecki",
                Email = "marcin.sulecki@altkom.pl",
                PhoneNumber = "555-555-555",
                Identifier = "848484730"
                
            };

            using (var context = new RentalBikesContext())
            {
                context.Customers.Add(customer);

                context.SaveChanges();
            }
        }
    }
}
