using Altkom.Postdata.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.EF.DAL.Configurations
{
    class VehicleConfiguration : EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
             Property(p => p.Number)
             .IsUnicode(false)
             .HasMaxLength(10)
             .IsFixedLength();


            // TPH (Table Per Hierarchy)
            Map<Scooter>(m => m.Requires("VehicleType").HasValue("S"));
            Map<Bike>(m => m.Requires("VehicleType").HasValue("B"));


        }
    }
}
