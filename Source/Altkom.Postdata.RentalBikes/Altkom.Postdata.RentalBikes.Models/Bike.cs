using System;
using System.Collections.Generic;
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
    }
}
