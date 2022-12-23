using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Data
{
    public class TuHotelEnLineaContext : DbContext
    {
        public TuHotelEnLineaContext(DbContextOptions<TuHotelEnLineaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerXRoom>()
                .HasKey(c => new { c.CustomerId, c.RoomId });

            builder.Entity<CustomerXRoom>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.CustomerXRooms)
                .HasForeignKey(c => c.CustomerId);
            builder.Entity<CustomerXRoom>()
                .HasOne(c => c.Room)
                .WithMany(c => c.CustomerXRooms)
                .HasForeignKey(ba => ba.RoomId);

            builder.Entity<PackageExtra>()
                .HasKey(c => new { c.PackageId, c.ExtraId });

            builder.Entity<PackageExtra>()
                .HasOne(c => c.Package)
                .WithMany(c => c.PackageExtras)
                .HasForeignKey(c => c.PackageId);
            builder.Entity<PackageExtra>()
                .HasOne(c => c.Extra)
                .WithMany(c => c.PackageExtras)
                .HasForeignKey(ba => ba.ExtraId);


        }


        public DbSet<TuHotelEnLinea.Models.PaymentMethod> PaymentMethod { get; set; } = default!;

        public DbSet<TuHotelEnLinea.Models.Customer> Customer { get; set; }

        public DbSet<TuHotelEnLinea.Models.Extra> Extra { get; set; }

        public DbSet<TuHotelEnLinea.Models.CategoryRoom> CategoryRoom { get; set; }

        public DbSet<TuHotelEnLinea.Models.Room> Room { get; set; }

        public DbSet<TuHotelEnLinea.Models.Package> Package { get; set; }

        public DbSet<TuHotelEnLinea.Models.Booking> Booking { get; set; }

        public DbSet<TuHotelEnLinea.Models.Sale> Sale { get; set; }

        public DbSet<TuHotelEnLinea.Models.CustomerXRoom> CustomerXRoom { get; set; }

        public DbSet<TuHotelEnLinea.Models.PackageExtra> PackageExtra { get; set; }
    }
}
