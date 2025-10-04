using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI
{
    internal class Settings
    {
        public static string BaseUrl => "http://localhost:5025";

        public static int CompanyId { get; internal set; }
        public static int FinancialYearId { get; internal set; }
    }
}
