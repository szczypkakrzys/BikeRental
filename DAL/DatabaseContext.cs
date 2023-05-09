using BikeRental.Models;
using Microsoft.EntityFrameworkCore;
using BikeRental.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BikeRental.DAL
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<RentalPoint> RentalPoint { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "temporaryDb");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VehicleType>()
                .HasMany(e => e.Vehicles)
                .WithOne(e => e.CategoryName)
                .HasForeignKey(e => e.CategoryId)
                .HasPrincipalKey(e => e.Id);

            builder.Entity<RentalPoint>(x =>
            {
                x.HasMany(e => e.Vehicles)
                .WithOne(e => e.RentalPoint)
                .HasForeignKey(e => e.RentalPointId)
                .HasPrincipalKey(e => e.Id);

                x.HasMany(e => e.Reservations)
                .WithMany(e => e.RentalPoints);
            });

            builder.Entity<Reservation>()
                .HasMany(e => e.Vehicles)
                .WithMany(e => e.Reservations);
        }

        public DbSet<BikeRental.ViewModels.ReservationViewModel>? ReservationViewModel { get; set; }

        public DbSet<BikeRental.ViewModels.VehicleItemViewModel>? VehicleItemViewModel { get; set; }

        public DbSet<BikeRental.ViewModels.VehicleDetailViewModel>? VehicleDetailViewModel { get; set; }
    }
}
