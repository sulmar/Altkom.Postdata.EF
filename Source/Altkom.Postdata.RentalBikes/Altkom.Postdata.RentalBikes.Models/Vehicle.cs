using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.RentalBikes.Models
{
    public abstract class Vehicle : Base
    {
        public int VehicleId { get; set; }

        public string Number { get; set; }

        public int ProductionYear { get; set; }

        public bool IsActive { get; set; }

        public decimal Amount { get; set; }
    }
}
