using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.RentalBikes.Models
{
    public class Rental : Base
    {
        public int RentalId { get; set; }

        public Bike Bike { get; set; }

        public Customer Rentee { get; set; }

        public Station FromStation { get; set; }

        public Station ToStation { get; set; }

        public DateTime FromRentalDateTime { get; set; }

        public DateTime? ToRentalDateTime { get; set; }

        public decimal Cost { get; set; }
    }
}
