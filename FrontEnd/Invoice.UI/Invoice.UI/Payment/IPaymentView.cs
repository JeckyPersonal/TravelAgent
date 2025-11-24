using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Payment
{
    internal interface IPaymentView : IBaseView
    {
        CustomerDto GetSelectedCustomer();
        void SetCustomerSource(List<CustomerDto> customers);
    }
}
