using Invoice.UI.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Customer.TenderConfiguration
{
    internal class TenderFuelConfigurationRestClient : BaseRestClient
    {
        public static TenderFuelConfigurationRestClient Instance => new TenderFuelConfigurationRestClient();

        public TenderFuelConfigurationRestClient() : base("/api/fuelrate"){}

        internal List<TenderFuelRateDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("get-all", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<TenderFuelRateDto>>(response);
        }

        internal TenderFuelRateDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get/{id}", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<TenderFuelRateDto>(response);
        }

        internal List<TenderFuelRateDto> GetByTenderID(int tenderID)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"getByTender/{tenderID}", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<TenderFuelRateDto>>(response);
        }

        internal TenderFuelRateDto Add(TenderFuelRateDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("add", RestSharp.Method.Post);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<TenderFuelRateDto>(response);
        }

        internal TenderFuelRateDto Update(TenderFuelRateDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{payload.Id}", RestSharp.Method.Put);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<TenderFuelRateDto>(response);
        }

        internal TenderFuelRateDto Delete(int id)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"delete/{id}", Method.Delete);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<TenderFuelRateDto>(restResponse);
        }
    }
}
