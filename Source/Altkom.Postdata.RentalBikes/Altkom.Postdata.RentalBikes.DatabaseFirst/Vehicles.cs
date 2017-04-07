namespace Altkom.Postdata.RentalBikes.DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("alt.Vehicles")]
    public partial class Vehicles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicles()
        {
            Rentals = new HashSet<Rentals>();
        }

        [Key]
        public int VehicleId { get; set; }

        [StringLength(10)]
        public string Number { get; set; }

        public int ProductionYear { get; set; }

        public bool IsActive { get; set; }

        public int? BikeType { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public double? Capacity { get; set; }

        public double? MaxSpeed { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [StringLength(128)]
        public string VehicleType { get; set; }

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
    }
}
