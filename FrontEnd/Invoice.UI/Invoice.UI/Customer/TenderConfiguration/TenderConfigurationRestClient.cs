using Invoice.UI.DTO;
using Invoice.UI.Main.PresenterFactory;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Customer.TenderConfiguration
{
    internal class TenderConfigurationRestClient : BaseRestClient
    {
        public static TenderConfigurationRestClient Instance => new TenderConfigurationRestClient();

        public TenderConfigurationRestClient() : base("/api/tender"){}

        internal List<TenderDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("get-all", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<TenderDto>>(response);
        }

        internal TenderDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get/{id}", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<TenderDto>(response);
        }

        internal TenderDto GetByCustomerID(int customerID)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"getByCustomer/{customerID}", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<TenderDto>(response);
        }

        internal TenderDto Add(TenderDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("add", RestSharp.Method.Post);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<TenderDto>(response);
        }

        internal TenderDto Update(TenderDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{payload.Id}", RestSharp.Method.Put);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<TenderDto>(response);
        }

        //internal TenderFuelRateDto Delete(TenderFuelRateDto customerDto)
        //{
        //    RestClient client = new RestClient(Settings.BaseUrl);

        //    RestRequest request = this.GetRestRequestWithTanant($"delete/{customerDto.Id}", Method.Delete);

        //    RestResponse response = client.ExecuteDelete(request);

        //    return this.ProcessResponse<TenderFuelRateDto>(response);
        //}
    }
}
