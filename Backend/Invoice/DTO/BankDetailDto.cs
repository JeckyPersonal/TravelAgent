using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class BankDetailDto
    {
        public int Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string IFSCCode { get; set; }
    }
}
