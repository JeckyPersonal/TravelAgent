using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class BankDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The 'BankName' field is required. Please provide a name and try again.")]
        public string BankName { get; set; }
    }
}
