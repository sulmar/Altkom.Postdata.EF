using Altkom.Postdata.RentalBikes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Postdata.EF.DAL.Configurations
{
    class RentalConfiguration : EntityTypeConfiguration<Rental>
    {
        public RentalConfiguration()
        {
            Property(p => p.FromRentalDateTime)
              .HasColumnType("datetime2");

            Property(p => p.ToRentalDateTime)
              .HasColumnType("datetime2");


            Property(e => e.FromRentalDateTime)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute()));
        }
    }
}
