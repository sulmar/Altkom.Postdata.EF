using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.RentalBikes.Models
{
    public class Bike : Base
    {
        public int BikeId { get; set; }

        public string Number { get; set; }

        public BikeType BikeType { get; set; }

        public string Size { get; set; }

        public int ProductioYear { get; set; }

        public bool IsActive { get; set; }



    }
}
