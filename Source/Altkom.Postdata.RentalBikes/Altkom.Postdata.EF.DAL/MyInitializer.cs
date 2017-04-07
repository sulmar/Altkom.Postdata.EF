using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.EF.DAL
{
    public class MyInitializer : IDatabaseInitializer<RentalBikesContext>
    {
        public void InitializeDatabase(RentalBikesContext context)
        {
            if (!context.Database.Exists() || !context.Database.CompatibleWithModel(true))
            {
                context.Database.Delete();

                context.Database.Create();
            }
        }
    }
}
