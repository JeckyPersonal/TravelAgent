using Invoice.DTO;
using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Invoice.UI.Main.PresenterFactory
{
    public class CustomerRestClient : BaseRestClient
    {
        public static CustomerRestClient Instance => new CustomerRestClient();
        

        private CustomerRestClient() :base("/api/customer") { }

        internal List<CustomerDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("get-all", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<CustomerDto>>(response);
        }

        internal CustomerDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request =this.GetRestRequestWithTanant($"get/{id}", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<CustomerDto>(response);
        }

        internal CustomerDto Add(CustomerDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("add", RestSharp.Method.Post);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<CustomerDto>(response);
        }

        internal CustomerDto Update(CustomerDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{payload.Id}", RestSharp.Method.Put);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<CustomerDto>(response);
        }

        internal List<CustomerDto> GetAllCustomerWithPendingVoucher()
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = base.GetRestRequestWithTanant("pending-voucher", Method.Get);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<List<CustomerDto>>(response);
        }

        internal CustomerDto Delete(CustomerDto customerDto)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"delete/{customerDto.Id}", Method.Delete);

            RestResponse response = client.ExecuteDelete(request);

            return this.ProcessResponse<CustomerDto>(response);
        }
    }
}