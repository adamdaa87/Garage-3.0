using System.ComponentModel.DataAnnotations;

namespace Garage_2._0.Models
{
    public class VehicleType
    {
        public int Id { get; set; }

        [Required]
        public string TypeName { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
