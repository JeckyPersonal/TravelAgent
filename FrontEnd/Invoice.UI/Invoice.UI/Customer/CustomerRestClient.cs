using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Invoice.UI.Main.PresenterFactory
{
    public class CustomerRestClient
    {
        public static CustomerRestClient Instance => new CustomerRestClient();
        private readonly string _controller = "/api/customer";

        private CustomerRestClient() { }

        internal List<CustomerDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{this._controller}/get-all", RestSharp.Method.Get);
            request.AddHeader("X-Company-Id", Settings.CompanyId);

            RestResponse response = client.ExecuteGet(request);

            //this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<CustomerDto>();

            return JsonConvert.DeserializeObject<List<CustomerDto>>(response.Content);
        }

        internal CustomerDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{this._controller}/get/{id}", RestSharp.Method.Get);
            request.AddHeader("X-Company-Id", Settings.CompanyId);

            RestResponse response = client.ExecuteGet(request);

            //this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new CustomerDto();

            return JsonConvert.DeserializeObject<CustomerDto>(response.Content);
        }

        internal CustomerDto Add(CustomerDto payload)
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

            return JsonConvert.DeserializeObject<CustomerDto>(response.Content);
        }

        internal CustomerDto Update(CustomerDto payload)
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

            return JsonConvert.DeserializeObject<CustomerDto>(response.Content);
        }
    }
}