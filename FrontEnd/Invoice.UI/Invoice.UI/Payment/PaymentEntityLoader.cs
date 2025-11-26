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
        private readonly PaymentRestClient _paymentRestClient;

        public PaymentEntityLoader(PaymentRestClient paymentRestClient)
        {
            _paymentRestClient = paymentRestClient;
        }

        public List<PaymentDto> GetEntities()
        {
            return this._paymentRestClient.GetAll();
        }
    }
}
