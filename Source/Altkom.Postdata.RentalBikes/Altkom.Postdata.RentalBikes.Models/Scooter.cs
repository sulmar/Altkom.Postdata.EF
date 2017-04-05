using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.RentalBikes.Models
{
    public class Scooter : Vehicle
    {
        public double Capacity { get; set; }

        public double MaxSpeed { get; set; }
    }
}
