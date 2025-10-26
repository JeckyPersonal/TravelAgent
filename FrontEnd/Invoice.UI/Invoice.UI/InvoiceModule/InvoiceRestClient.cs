using Invoice.UI.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.InvoiceModule
{
    internal class InvoiceRestClient : Invoice.UI.InvoiceRestClient
    {
        public static InvoiceRestClient Instance => new InvoiceRestClient();
        private InvoiceRestClient() :base("api/invoice")
        {

        }

        internal InvoiceDto Get(int id)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = base.GetRestRequestWithTanant($"get/{id}", Method.Get);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<InvoiceDto>(restResponse);
        }

        internal InvoiceDto Update(InvoiceDto invoiceDto)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = base.GetRestRequestWithTanant($"update/{invoiceDto.Id}", Method.Put);
            request.AddJsonBody(invoiceDto);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<InvoiceDto>(restResponse);
        }

        internal InvoiceDto Add(InvoiceDto invoiceDto)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = base.GetRestRequestWithTanant($"add", Method.Post);
            request.AddJsonBody(invoiceDto);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<InvoiceDto>(restResponse);
        }

        internal List<InvoiceDto> GetAll()
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest restRequest = base.GetRestRequestWithTanant($"get-all", Method.Get);

            RestResponse response = restClient.Execute(restRequest);

            return this.ProcessResponse<List<InvoiceDto>>(response);
        }

        internal bool Print(int invoiceId)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest restRequest = base.GetRestRequestWithTanant($"print/{invoiceId}", Method.Post);

            RestResponse restResponse = restClient.Execute(restRequest);

            return this.ProcessResponse<bool>(restResponse);
        }
    }
}
