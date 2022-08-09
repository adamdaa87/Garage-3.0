using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2._0.Models
{
    public class StatisticsViewModel
    {
        public IEnumerable<Vehicle_old> Vehicles { get; set; } = new List<Vehicle_old>();
       
        public string? Vehicle  { get; set; }
        
        public int VehiclesNoOfWheels { get; set; }

        public int Cost { get; set; }

        public IEnumerable<VehicleCountDto> VehicleCount { get; set; }
    }
}
