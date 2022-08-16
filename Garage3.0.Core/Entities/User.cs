using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("User Name")]
        public string? UserName { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string Fname { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string Lname { get; set; }
        [Required]
        [DisplayName("Social security number")]
        public string Pnr { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
