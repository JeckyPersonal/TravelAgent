using Invoice.UI.DTO;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Invoice.UI.InvoiceModule
{
    internal class InvoiceDetailRestClient : Invoice.UI.BaseRestClient
    {
        public static InvoiceDetailRestClient Instance => new InvoiceDetailRestClient();

        private InvoiceDetailRestClient() : base ("api/invoicedetail") { }

        internal InvoiceDetailDto Add(int invoiceId, InvoiceDetailDto invoiceDetailDto)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = base.GetRestRequestWithTanant($"add/{invoiceId}", Method.Post);

            request.AddJsonBody(invoiceDetailDto);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<InvoiceDetailDto>(response);
        }

        internal void Delete(int id)
        {
            throw new NotImplementedException();
        }

        internal InvoiceDetailDto Update(InvoiceDetailDto invoiceDetailDto)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = base.GetRestRequestWithTanant($"update/{invoiceDetailDto.Id}", Method.Put);
            
            request.AddJsonBody(invoiceDetailDto);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<InvoiceDetailDto>(response);
        }

        internal List<InvoiceDetailDto> GetAll(int invoiceId)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = base.GetRestRequestWithTanant($"get-all/{invoiceId}", Method.Get);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<List<InvoiceDetailDto>>(restResponse);
        }

        internal List<InvoiceDetailDto> GetTenderItems(int customerId, int totalKm) 
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = base.GetRestRequestWithTanant($"get-tender-items/{customerId}/{totalKm}", Method.Get);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<List<InvoiceDetailDto>>(restResponse);
        }
    }
}