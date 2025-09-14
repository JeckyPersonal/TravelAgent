using Invoice.DTO;
using Invoice.Test.Model.Company;
using Invoice.UI.Exceptions;
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
    public class CompanyRestClient
    {
        private static CompanyRestClient _instance => new CompanyRestClient();

        private CompanyRestClient()
        {

        }

        public List<CompanyDto> GetAllCompany()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest("/api/Company/get-all", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<CompanyDto>();

            return JsonConvert.DeserializeObject<List<CompanyDto>>(response.Content);

        }

        public CompanyDto AddCompany(CompanyDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest("/api/Company/add", RestSharp.Method.Post);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            //this.assertResponse();

            if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    ValidationErrorResponse validationResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(response.Content);
                    throw new ValidationException(validationResponse);
                }
            }

            return JsonConvert.DeserializeObject<CompanyDto>(response.Content);
        }

        public CompanyDto GetById(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"/api/Company/get/{id}", RestSharp.Method.Get);

            RestResponse response = client.Execute(request);

            this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    ValidationErrorResponse validationResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(response.Content);
                    throw new ValidationException(validationResponse);
                }
            }

            return JsonConvert.DeserializeObject<CompanyDto>(response.Content);

        }

        private void assertResponse()
        {
            //throw new NotImplementedException();
        }

        internal CompanyDto UpdateCompany(CompanyDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"/api/Company/update/{payload.Id}", RestSharp.Method.Put);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    ValidationErrorResponse validationResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(response.Content);
                    throw new ValidationException(validationResponse);
                }
            }

            return JsonConvert.DeserializeObject<CompanyDto>(response.Content);

        }

        public static CompanyRestClient Instance => _instance; 
    }
}
