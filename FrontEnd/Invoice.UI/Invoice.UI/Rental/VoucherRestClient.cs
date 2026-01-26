using Invoice.UI.CustomControl.EventArguments;
using Invoice.UI.DTO;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Invoice.UI.Rental
{
    internal class VoucherRestClient : BaseRestClient
    {
        private VoucherRestClient() : base("api/voucher")
        {
        }

        public static VoucherRestClient Instance => new VoucherRestClient();

        internal VoucherMasterDto Add(VoucherMasterDto voucherMaster)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"add", Method.Post);
            request.AddJsonBody(voucherMaster);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<VoucherMasterDto>(response);
        }

        internal VoucherMasterDto Delete(VoucherMasterDto voucherMaster)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"delete/{voucherMaster.Id}", Method.Delete);

            RestResponse response = client.ExecuteDelete(request);

            return this.ProcessResponse<VoucherMasterDto>(response);
        }

        internal VoucherMasterDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get/{id}", Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<VoucherMasterDto>(response);
        }

        internal List<VoucherMasterDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-all", Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<VoucherMasterDto>>(response);
        }

        internal List<VoucherMasterDto> GetAll(int customerId)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-all-pending-voucher", Method.Get);

            request.AddQueryParameter("customerId", customerId);            

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<VoucherMasterDto>>(response);
        }

        internal List<VoucherMasterDto> GetAll(List<SearchCriteriaEventArgs> searchCriteria)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"filter", Method.Get);

            foreach (SearchCriteriaEventArgs criteria in searchCriteria)
            {
                request = request.AddQueryParameter(criteria.FieldName, criteria.Value);
            }

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<VoucherMasterDto>>(response);
        }

        internal string GetVoucherNo()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"voucherNo", Method.Get);

            return string.Empty;

        }

        internal List<InvoiceDetailDto> ProcessVoucher(VoucherProcessDto processDto)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"process", Method.Post);
            request.AddJsonBody(processDto);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<List<InvoiceDetailDto>>(response);
        }

        internal VoucherMasterDto Update(VoucherMasterDto voucherMaster)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{voucherMaster.Id}", Method.Put);

            request.AddJsonBody(voucherMaster);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<VoucherMasterDto>(response);
        }
    }
}