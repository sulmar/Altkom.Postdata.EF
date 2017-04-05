using Altkom.Postdata.EF.DAL;
using Altkom.Postdata.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.RentalBikes.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // AddCustomerTest();

            // AddBikeTest();


            GetVehiclesTest();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

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
