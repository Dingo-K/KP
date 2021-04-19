namespace Parking.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        public int ReviewId { get; set; }

        [Column("Review")]
        [Required]
        [StringLength(300)]
        public string Review1 { get; set; }

        public DateTime TimeRev { get; set; }

        public int ParkingId { get; set; }

        public int UserId { get; set; }

        public virtual MyParking MyParking { get; set; }

        public virtual Users Users { get; set; }
    }
}
