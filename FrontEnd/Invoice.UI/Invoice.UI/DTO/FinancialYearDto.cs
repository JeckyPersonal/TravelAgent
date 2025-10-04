using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.DTO
{
    internal class FinancialYearDto
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string Year
        {
            get
            {
                return $"{this.FromDate.Year} - {this.ToDate.Year}";
            }
        }
    }
}
