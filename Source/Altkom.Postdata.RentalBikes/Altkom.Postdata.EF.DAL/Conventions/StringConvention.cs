using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.EF.DAL.Conventions
{
    class StringConvention : Convention
    {
        public StringConvention()
        {
            Properties<string>()
                .Configure(p => p.IsUnicode(false));
        }
    }
}
