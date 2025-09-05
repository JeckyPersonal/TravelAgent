using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class VehicleDto
    {
        public int Id { get; set; }

        [Required]
        public string VehicleType { get; set; }
    }
}
