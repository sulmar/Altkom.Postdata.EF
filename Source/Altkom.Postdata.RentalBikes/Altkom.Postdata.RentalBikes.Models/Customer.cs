using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.RentalBikes.Models
{
    public class Customer : Base
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Identifier { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string FullName => $"{FirstName} {LastName}";

    }
}
