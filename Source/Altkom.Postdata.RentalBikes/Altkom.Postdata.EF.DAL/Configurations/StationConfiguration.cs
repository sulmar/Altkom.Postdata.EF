using Altkom.Postdata.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.EF.DAL.Configurations
{
    class StationConfiguration : EntityTypeConfiguration<Station>
    {
        public StationConfiguration()
        {

            ToTable("crm.Stations");
            
        }
    }
}
