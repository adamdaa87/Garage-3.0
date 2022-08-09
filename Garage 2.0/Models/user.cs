using System.ComponentModel.DataAnnotations;

namespace Garage_2._0.Models
{
    public class user
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        public string Pnr { get; set; }

    }
}
