using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Parking.DataBase
{
    public partial class KPContext : DbContext
    {
        public KPContext()
            : base("name=KPContext")
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<MyParking> MyParking { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyParking>()
                .HasMany(e => e.Place)
                .WithRequired(e => e.MyParking)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MyParking>()
                .HasMany(e => e.Review)
                .WithRequired(e => e.MyParking)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Place>()
                .HasMany(e => e.Booking)
                .WithRequired(e => e.Place)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Booking)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Review)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);
        }
    }
}
