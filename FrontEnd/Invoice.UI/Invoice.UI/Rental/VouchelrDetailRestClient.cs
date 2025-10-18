using Invoice.UI.DTO;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Invoice.UI.Rental
{
    internal class VouchelrDetailRestClient : InvoiceRestClient
    {
        public VouchelrDetailRestClient() : base("api/voucherdetail")
        {
        }

        public static VouchelrDetailRestClient Instance => new VouchelrDetailRestClient();

        internal VoucherDetailDto Add(int voucherId, VoucherDetailDto detail)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"add/{voucherId}", Method.Post);
            request.AddJsonBody(detail);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<VoucherDetailDto>(response);
        }

        internal VoucherDetailDto Delete(int id)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"delete/{id}", Method.Delete);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<VoucherDetailDto>(response);
        }

        internal List<VoucherDetailDto> GetAll(int voucherId)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-all/{voucherId}", Method.Get);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<List<VoucherDetailDto>>(response);
        }

        internal VoucherDetailDto Update(VoucherDetailDto detail)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{detail.Id}", Method.Put);
            request.AddJsonBody(detail);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<VoucherDetailDto>(response);
        }
    }
}