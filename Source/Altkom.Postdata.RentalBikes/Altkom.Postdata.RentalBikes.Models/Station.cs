using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.RentalBikes.Models
{
    public class Station : Base
    {
        public int StationId { get; set; }

        public Location Location { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public byte Capacity { get; set; }

        // public byte[] RowVersion { get; set; }
    }
}
