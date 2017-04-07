namespace Altkom.Postdata.RentalBikes.DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("alt.Dogs")]
    public partial class Dogs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnimalId { get; set; }

        public string Color { get; set; }

        public string Owner { get; set; }
    }
}
