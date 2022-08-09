using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_2._0.Models;

namespace Garage_2._0.Data
{
    public class Garage_2_0Context : DbContext
    {
        public Garage_2_0Context (DbContextOptions<Garage_2_0Context> options)
            : base(options)
        {
        }
        public DbSet<Garage_2._0.Models.Vehicle> Vehicle => Set<Vehicle>();
        //public DbSet<Garage_2._0.Models.Vehicle2> Vehicle2 { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, ParkingLot = 1, RegNr = "ABC123", VehicleType = VehicleType.Car, Make = "Volvo", Model = "V70", Color = "Silver", NrOfWheels = 4, TimeOfArrival = DateTime.Now },
                new Vehicle { Id = 2, ParkingLot = 2, RegNr = "DEF456", VehicleType = VehicleType.Car, Make = "Saab", Model = "95", Color = "Red", NrOfWheels = 4, TimeOfArrival = DateTime.Now },
                new Vehicle { Id = 3, ParkingLot = 3, RegNr = "GHI789", VehicleType = VehicleType.Car, Make = "Ford", Model = "Mustang", Color = "Green", NrOfWheels = 4, TimeOfArrival = DateTime.Now },
                new Vehicle { Id = 4, ParkingLot = 4, RegNr = "JKL891", VehicleType = VehicleType.Motorcycle, Make = "Harley-Davidson", Model = "Pan America", Color = "Black", NrOfWheels = 2, TimeOfArrival = DateTime.Now },
                new Vehicle { Id = 5, ParkingLot = 5, RegNr = "MNO345", VehicleType = VehicleType.Truck, Make = "Scania", Model = "XT", Color = "Orange", NrOfWheels = 6, TimeOfArrival = DateTime.Now },
                new Vehicle { Id = 6, ParkingLot = 6, RegNr = "PQR912", VehicleType = VehicleType.Bus, Make = "Scania", Model = "zzz", Color = "Yellow", NrOfWheels = 6, TimeOfArrival = DateTime.Now }
                );

        }

    }
}
