using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Data;
using System.Web.Routing;

namespace Invoice.UI.Bank.BankDetail
{
    public class BankDetailRestClient : BaseRestClient
    {
        public static BankDetailRestClient Instance { get; set; } = new BankDetailRestClient();

        private BankDetailRestClient() :base ("api/bankdetail")
        {

        }

        internal BankDetailDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"/get/{id}" , RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<BankDetailDto>(response);
        }

        internal BankDetailDto Add(BankDetailDto payload)
        {

            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("add", RestSharp.Method.Post);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<BankDetailDto>(response);
        }

        internal BankDetailDto Update(BankDetailDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{payload.Id}", RestSharp.Method.Put);
            
            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<BankDetailDto>(response);
        }

        internal List<BankDetailDto> GetByBank(int bankId)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"getByBank/{bankId}", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<BankDetailDto>>(response);
        }
    }
}
