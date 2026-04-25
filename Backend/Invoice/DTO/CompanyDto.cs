using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class CompanyDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The 'Name' field is required. Please provide a name and try again.")]
        public string Name { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }

        [Required(ErrorMessage = "The 'GSTNo' field is required. Please provide a name and try again.")]
        public string GSTNo { get; set; }
        public string? LUTNo { get; set; }

        [Required(ErrorMessage = "The 'PANNo' field is required. Please provide a name and try again.")]
        public string PANNo { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Zip { get; set; }
    }
}
