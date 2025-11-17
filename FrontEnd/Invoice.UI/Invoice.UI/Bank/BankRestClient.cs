using Invoice.DTO;
using Invoice.Test.Model.Company;
using Invoice.UI.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Bank
{
    public class BankRestClient : BaseRestClient
    {
        public static BankRestClient Instance => new BankRestClient();

        private BankRestClient() : base("/api/bank")
        {

        }

        internal List<BankDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = base.GetRestRequestWithTanant("get-all", RestSharp.Method.Get);
            
            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<BankDto>>(response);

        }

        internal BankDto Add(BankDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = base.GetRestRequestWithTanant("add", RestSharp.Method.Post);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<BankDto>(response);

        }

        internal BankDto Update(BankDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{payload.Id}", RestSharp.Method.Put);
            
            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<BankDto>(response);

        }

        internal BankDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get/{id}", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);
            
            return this.ProcessResponse<BankDto>(response);
        }
    }
}
