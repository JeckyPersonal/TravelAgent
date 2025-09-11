using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Invoice.UI.Company
{
    internal class CompanyRestClient
    {
        private static CompanyRestClient _instance => new CompanyRestClient();

        private CompanyRestClient()
        {

        }

        public List<CompanyDto> GetAllCompany()
        {
            string url = string.Empty;
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest("/api/Company/get-all", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<CompanyDto>();

            return JsonConvert.DeserializeObject<List<CompanyDto>>(response.Content);

        }

        private void assertResponse()
        {
            //throw new NotImplementedException();
        }

        public static CompanyRestClient Instance => _instance; 
    }
}
