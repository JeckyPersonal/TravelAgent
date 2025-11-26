using Invoice.UI.DTO;
using RestSharp;
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

        private PaymentRestClient() : base("api/payment")
        {
        }

        internal PaymentDto Add(PaymentDto paymentDto)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"add", Method.Post);
            request.AddJsonBody(paymentDto);

            RestResponse response = client.ExecutePost(request);

            return this.ProcessResponse<PaymentDto>(response);
        }

        internal PaymentDto AddInvoice(int invoiceId, int paymentId)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"add-invoice/{paymentId}", Method.Put);
            request.AddQueryParameter("invoiceId", invoiceId.ToString());

            RestResponse response = client.ExecutePut(request);

            return this.ProcessResponse<PaymentDto>(response);
        }

        internal PaymentDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-by-id/{id}", Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<PaymentDto>(response);
        }

        internal List<PaymentDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-all", Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<PaymentDto>>(response);
        }

        internal PaymentDto Update(PaymentDto paymentDto)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{paymentDto.Id}", Method.Put);
            request.AddBody(paymentDto);

            RestResponse response = client.ExecutePut(request);

            return this.ProcessResponse<PaymentDto>(response);
        }
    }
}
