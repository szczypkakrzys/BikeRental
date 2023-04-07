﻿using BikeRental.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<RentalPoint> RentalPoint { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        protected override void OnConfiguring
      (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "temporaryDb");
        }
    }
}