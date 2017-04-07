namespace Altkom.Postdata.RentalBikes.DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("alt.Rentals")]
    public partial class Rentals
    {
        [Key]
        public int RentalId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FromRentalDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ToRentalDateTime { get; set; }

        public decimal? Cost { get; set; }

        public int? Bike_VehicleId { get; set; }

        public int? FromStation_StationId { get; set; }

        public int? Rentee_CustomerId { get; set; }

        public int? ToStation_StationId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Stations Stations { get; set; }

        public virtual Stations Stations1 { get; set; }

        public virtual Vehicles Vehicles { get; set; }
    }
}
