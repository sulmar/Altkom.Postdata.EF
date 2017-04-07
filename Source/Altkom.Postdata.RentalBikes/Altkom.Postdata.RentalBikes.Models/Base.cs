using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.RentalBikes.Models
{
    public abstract class Base
    {
        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
