using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TuHotelEnLinea.Models;

public partial class HotelEnLineaContext : DbContext
{
    public HotelEnLineaContext()
    {
    }

    public HotelEnLineaContext(DbContextOptions<HotelEnLineaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<CategoryRoom> CategoryRooms { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerXroom> CustomerXrooms { get; set; }

    public virtual DbSet<Extra> Extras { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<PackageExtra> PackageExtras { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("\nData Source=localhost;Initial Catalog=HotelEnLinea;Integrated Security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");

            entity.HasIndex(e => e.CustomerId, "IX_Booking_CustomerId");

            entity.HasIndex(e => e.PackageId, "IX_Booking_PackageId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings).HasForeignKey(d => d.CustomerId);

            entity.HasOne(d => d.Package).WithMany(p => p.Bookings).HasForeignKey(d => d.PackageId);
        });

        modelBuilder.Entity<CategoryRoom>(entity =>
        {
            entity.ToTable("CategoryRoom");

            entity.Property(e => e.CategoryRoomDescription).HasMaxLength(300);
            entity.Property(e => e.CategoryRoomName).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerIdCard).HasMaxLength(50);
            entity.Property(e => e.CustomerLastName).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.CustomerPhone).HasMaxLength(45);
        });

        modelBuilder.Entity<CustomerXroom>(entity =>
        {
            entity.ToTable("CustomerXRoom");

            entity.HasIndex(e => e.CustomerId, "IX_CustomerXRoom_CustomerId");

            entity.HasIndex(e => e.RoomId, "IX_CustomerXRoom_RoomId");

            entity.Property(e => e.CustomerXroomId).HasColumnName("CustomerXRoomId");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerXrooms).HasForeignKey(d => d.CustomerId);

            entity.HasOne(d => d.Room).WithMany(p => p.CustomerXrooms).HasForeignKey(d => d.RoomId);
        });

        modelBuilder.Entity<Extra>(entity =>
        {
            entity.ToTable("Extra");

            entity.Property(e => e.ExtraDescription).HasMaxLength(400);
            entity.Property(e => e.ExtraName).HasMaxLength(50);
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.ToTable("Package");

            entity.HasIndex(e => e.RoomId, "IX_Package_RoomId");

            entity.Property(e => e.PackageName).HasMaxLength(50);

            entity.HasOne(d => d.Room).WithMany(p => p.Packages).HasForeignKey(d => d.RoomId);
        });

        modelBuilder.Entity<PackageExtra>(entity =>
        {
            entity.ToTable("PackageExtra");

            entity.HasIndex(e => e.ExtraId, "IX_PackageExtra_ExtraId");

            entity.HasIndex(e => e.PackageId, "IX_PackageExtra_PackageId");

            entity.HasOne(d => d.Extra).WithMany(p => p.PackageExtras).HasForeignKey(d => d.ExtraId);

            entity.HasOne(d => d.Package).WithMany(p => p.PackageExtras).HasForeignKey(d => d.PackageId);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.ToTable("PaymentMethod");

            entity.Property(e => e.PaymentMethodName).HasMaxLength(100);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.HasIndex(e => e.CategoryRoomId, "IX_Room_CategoryRoomId");

            entity.HasOne(d => d.CategoryRoom).WithMany(p => p.Rooms).HasForeignKey(d => d.CategoryRoomId);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("Sale");

            entity.HasIndex(e => e.BookingId, "IX_Sale_BookingId");

            entity.HasIndex(e => e.PaymentMethodId, "IX_Sale_PaymentMethodId");

            entity.HasOne(d => d.Booking).WithMany(p => p.Sales).HasForeignKey(d => d.BookingId);

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Sales).HasForeignKey(d => d.PaymentMethodId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
