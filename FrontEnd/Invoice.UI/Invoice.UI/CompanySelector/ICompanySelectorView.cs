using Invoice.DTO;
using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.CompanySelector
{
    internal interface ICompanySelectorView :IBaseView
    {
        void BindDataSource(List<CompanyDto> companies);
        void BindFinancialYear(List<FinancialYearDto> financialYears);
        CompanyDto GetSelectedItem();

        FinancialYearDto GetFinancialYear();
    }
}
