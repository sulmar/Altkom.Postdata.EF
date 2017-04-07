namespace Altkom.Postdata.RentalBikes.DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("crm.Stations")]
    public partial class Stations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stations()
        {
            Rentals = new HashSet<Rentals>();
            Rentals1 = new HashSet<Rentals>();
        }

        [Key]
        public int StationId { get; set; }

        public double Location_Latitude { get; set; }

        public double Location_Longitude { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Location_Altitude { get; set; }

        public byte Capacity { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rentals> Rentals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rentals> Rentals1 { get; set; }
    }
}
