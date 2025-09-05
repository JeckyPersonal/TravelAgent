using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class CompanyDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        [Required]
        public string GSTNo { get; set; }

        [Required]
        public string PANNo { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
    }
}
