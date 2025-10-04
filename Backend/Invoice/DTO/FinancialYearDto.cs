using Invoice.Validator;
using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{

    [CustomValidation(typeof(DateRangeValidator), nameof(DateRangeValidator.ValidateDateRange))]
    public class FinancialYearDto
    {
        public int Id { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }
    }
}
