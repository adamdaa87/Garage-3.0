using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage_2._0.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "Length must be 6 characters long.", MinimumLength = 6)]
        [Remote("ValidateRegNum", "Vehicle")]
        [DisplayName("Registration number")]
        public string RegNr { get; set; }

        [DisplayName("Time parking started")]
        public DateTime TimeOfArrival { get; set; } = DateTime.Now;

        public int VehicleTypeId { get; set; }
        public int UserId { get; set; }

    }
}
