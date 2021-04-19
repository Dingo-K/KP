namespace Parking.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Place")]
    public partial class Place
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Place()
        {
            Booking = new HashSet<Booking>();
        }

        public int PlaceId { get; set; }

        [Required]
        [StringLength(10)]
        public string Number { get; set; }

        [Required]
        [StringLength(5)]
        public string Sector { get; set; }

        public bool Status { get; set; }

        public int ParkingId { get; set; }

        public int cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Booking { get; set; }

        public virtual MyParking MyParking { get; set; }
    }
}
