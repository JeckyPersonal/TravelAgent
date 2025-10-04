using Invoice.DTO;
using Invoice.Model;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Validator
{
    public class DateRangeValidator
    {
        public static ValidationResult ValidateDateRange(FinancialYearDto financiialYear, ValidationContext context)
        {
            if (financiialYear.FromDate > financiialYear.ToDate)
            {
                return new ValidationResult("FromDate must be earlier than or equal to ToDate. Please re-try after changing date.",
                    new[] { nameof(FinancialYearDto.FromDate), nameof(FinancialYearDto.ToDate) });
            }

            return ValidationResult.Success;
        }
    }
}
