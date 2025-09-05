using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class BankDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
