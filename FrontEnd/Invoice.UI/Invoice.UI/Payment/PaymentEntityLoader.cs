using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Payment
{
    internal class PaymentEntityLoader : EntityLoader<PaymentDto>
    {
        public List<PaymentDto> GetEntities()
        {
            return new List<PaymentDto  >();
        }
    }
}
