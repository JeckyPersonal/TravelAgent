using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Payment
{
    internal class PaymentRestClient : BaseRestClient
    {
        public static PaymentRestClient Instance = new PaymentRestClient();

        private PaymentRestClient() : base(string.Empty)
        {
        }

        internal PaymentDto Add(PaymentDto paymentDto)
        {
            throw new NotImplementedException();
        }

        internal PaymentDto Get(int id)
        {
            throw new NotImplementedException();
        }

        internal PaymentDto Update(PaymentDto paymentDto)
        {
            throw new NotImplementedException();
        }
    }
}
