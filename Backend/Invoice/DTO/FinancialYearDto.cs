using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class FinancialYearDto
    {
        public int Id { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }
    }
}
