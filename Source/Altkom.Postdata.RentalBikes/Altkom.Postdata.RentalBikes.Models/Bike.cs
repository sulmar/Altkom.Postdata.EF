using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.RentalBikes.Models
{
    public class Bike : Vehicle
    {
        public BikeType BikeType { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public ICollection<Rental> Rentals { get; set; }

        public DbGeography Location { get; set; }
    }
}
