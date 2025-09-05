using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class VehicleDetailDto
    {
        public int Id { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }
    }
}
