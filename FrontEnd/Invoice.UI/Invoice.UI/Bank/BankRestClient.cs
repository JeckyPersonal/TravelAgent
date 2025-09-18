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
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Bank
{
    public class BankRestClient
    {
        public static BankRestClient Instance => new BankRestClient();
        private readonly string _controller = "/api/bank";

        private BankRestClient()
        {

        }

        internal List<BankDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{this._controller}/get-all", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            //this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<BankDto>();

            return JsonConvert.DeserializeObject<List<BankDto>>(response.Content);
        }

        internal BankDto Add(BankDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{_controller}/add", RestSharp.Method.Post);
            request.AddHeader("X-Company-Id", Settings.CompanyId);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            //this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    ValidationErrorResponse validationResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(response.Content);
                    throw new ValidationException(validationResponse);
                }
            }

            return JsonConvert.DeserializeObject<BankDto>(response.Content);
        }

        internal BankDto Update(BankDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{_controller}/update/{payload.Id}", RestSharp.Method.Put);
            request.AddHeader("X-Company-Id", Settings.CompanyId);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            //this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    ValidationErrorResponse validationResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(response.Content);
                    throw new ValidationException(validationResponse);
                }
            }

            return JsonConvert.DeserializeObject<BankDto>(response.Content);
        }

        internal BankDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{this._controller}/get/{id}", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            //this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new BankDto();

            return JsonConvert.DeserializeObject<BankDto>(response.Content);
        }
    }
}
