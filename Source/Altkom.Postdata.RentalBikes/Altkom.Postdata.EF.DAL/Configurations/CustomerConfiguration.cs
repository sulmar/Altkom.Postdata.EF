using Altkom.Postdata.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.EF.DAL.Configurations
{
    class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {

        public CustomerConfiguration()
        {
            // określa klucz główny PK
            HasKey(p => p.CustomerId);

            Property(p => p.FirstName)
                .HasMaxLength(50);

            Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Identifier)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

        }
    }
}
