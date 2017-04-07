namespace Altkom.Postdata.RentalBikes.DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("alt.Horses")]
    public partial class Horses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnimalId { get; set; }

        public string Color { get; set; }

        public int Speed { get; set; }
    }
}
