using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.EF.DAL.Conventions
{
    class CustomConvention : IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType item, DbModel model)
        {
            throw new NotImplementedException();
        }
    }
}
