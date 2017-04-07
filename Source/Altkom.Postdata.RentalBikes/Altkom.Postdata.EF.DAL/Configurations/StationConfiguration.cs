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

            MapToStoredProcedures(s =>
            {
                s.Update(u => u.HasName("modify_station"));
                s.Insert(u => u.HasName("add_station"));
                s.Delete(u => u.HasName("remove_station"));
            });


         

        }
    }
}
