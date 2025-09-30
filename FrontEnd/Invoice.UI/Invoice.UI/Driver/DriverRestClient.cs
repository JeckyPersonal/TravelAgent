using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Invoice.UI.Main.PresenterFactory;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Invoice.UI.Driver
{
    public class DriverRestClient
    {
        public static DriverRestClient Instance => new DriverRestClient();
        private readonly string _controller = "/api/Driver";

        private DriverRestClient()
        {

        }

        internal DriverDto Add(DriverDto payload)
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

            return JsonConvert.DeserializeObject<DriverDto>(response.Content);
        }

        internal DriverDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{this._controller}/get/{id}", RestSharp.Method.Get);
            request.AddHeader("X-Company-Id", Settings.CompanyId);

            RestResponse response = client.ExecuteGet(request);

            //this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new DriverDto();

            return JsonConvert.DeserializeObject<DriverDto>(response.Content);
        }

        internal List<DriverDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{this._controller}/get-all", RestSharp.Method.Get);
            request.AddHeader("X-Company-Id", Settings.CompanyId);

            RestResponse response = client.ExecuteGet(request);

            //this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<DriverDto>();

            return JsonConvert.DeserializeObject<List<DriverDto>>(response.Content);
        }

        internal DriverDto Update(DriverDto payload)
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

            return JsonConvert.DeserializeObject<DriverDto>(response.Content);
        }
    }
}