using Invoice.DTO;
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
        CompanyDto GetSelectedItem();
    }
}
