﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage_2._0.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Parking Lot")]
        public int ParkingLot { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "Length must be 6 characters long.", MinimumLength = 6)]
        [Remote("ValidateRegNum", "Vehicle")]
        [DisplayName("Registration number")]
        public string RegNr { get; set; }
        
        [Required]
        [DisplayName("Type of vehicle")]
        public VehicleType VehicleType { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        [DisplayName("Make")]
        public string Make { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        [DisplayName("Model")]
        public string Model { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        [DisplayName("Color")]
        public string Color { get; set; }

        [Required]
        [Range(2, 6)]
        [DisplayName("Wheels on vehicle")]
        public int NrOfWheels { get; set; }

        [DisplayName("Time parking started")]
        public DateTime TimeOfArrival { get; set; } = DateTime.Now;

    }
}
