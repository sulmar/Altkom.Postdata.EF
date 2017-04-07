namespace Altkom.Postdata.RentalBikes.DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("alt.Woman")]
    public partial class Woman
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }

        public string LikesColor { get; set; }

        public virtual People People { get; set; }
    }
}
