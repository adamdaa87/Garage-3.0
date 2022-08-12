using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_2._0.Models;
using Garage3._0.Core.Entities;

namespace Garage_2._0.Data
{
    public class Garage_2_0Context : DbContext
    {
        public Garage_2_0Context (DbContextOptions<Garage_2_0Context> options)
            : base(options)
        {
        }
        public DbSet<Garage_2._0.Models.Vehicle_old> Vehicle_old => Set<Vehicle_old>();
        //public DbSet<Garage_2._0.Models.Vehicle2> Vehicle2 { get; set; } = null!;

        public DbSet<Vehicle> Vehicle => Set<Vehicle>();
        public DbSet<User>? User { get; set; }
        public DbSet<VehicleType>? VehicleType { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Vehicle_old>().HasData(
        //        new Vehicle_old { Id = 1, ParkingLot = 1, RegNr = "ABC123", VehicleType = VehicleType_old.Car, Make = "Volvo", Model = "V70", Color = "Silver", NrOfWheels = 4, TimeOfArrival = DateTime.Now },
        //        new Vehicle_old { Id = 2, ParkingLot = 2, RegNr = "DEF456", VehicleType = VehicleType_old.Car, Make = "Saab", Model = "95", Color = "Red", NrOfWheels = 4, TimeOfArrival = DateTime.Now },
        //        new Vehicle_old { Id = 3, ParkingLot = 3, RegNr = "GHI789", VehicleType = VehicleType_old.Car, Make = "Ford", Model = "Mustang", Color = "Green", NrOfWheels = 4, TimeOfArrival = DateTime.Now },
        //        new Vehicle_old { Id = 4, ParkingLot = 4, RegNr = "JKL891", VehicleType = VehicleType_old.Motorcycle, Make = "Harley-Davidson", Model = "Pan America", Color = "Black", NrOfWheels = 2, TimeOfArrival = DateTime.Now },
        //        new Vehicle_old { Id = 5, ParkingLot = 5, RegNr = "MNO345", VehicleType = VehicleType_old.Truck, Make = "Scania", Model = "XT", Color = "Orange", NrOfWheels = 6, TimeOfArrival = DateTime.Now },
        //        new Vehicle_old { Id = 6, ParkingLot = 6, RegNr = "PQR912", VehicleType = VehicleType_old.Bus, Make = "Scania", Model = "zzz", Color = "Yellow", NrOfWheels = 6, TimeOfArrival = DateTime.Now }
        //        );

        //}

    }
}
