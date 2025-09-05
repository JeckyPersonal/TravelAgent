using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class DriverDto
    {
        public int Id { get; set; }

        [Required]
        public string DriverName { get; set; }

        [Required]
        public string DriverMobile { get; set; }
        public string LicenseNo { get; set; }
    }
}
