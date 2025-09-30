using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Invoice.UI.Vehicle
{
    internal class VehicleRestClient
    {
        public static VehicleRestClient Instance => new VehicleRestClient();
        private readonly string _controller = "/api/vehicle";

        private VehicleRestClient()
        {

        }

        internal VehicleDto Add(VehicleDto payload)
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

            return JsonConvert.DeserializeObject<VehicleDto>(response.Content);
        }

        internal VehicleDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{this._controller}/get/{id}", RestSharp.Method.Get);
            request.AddHeader("X-Company-Id", Settings.CompanyId);

            RestResponse response = client.ExecuteGet(request);

            //this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new VehicleDto();

            return JsonConvert.DeserializeObject<VehicleDto>(response.Content);
        }

        internal List<VehicleDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{this._controller}/get-all", RestSharp.Method.Get);
            request.AddHeader("X-Company-Id", Settings.CompanyId);

            RestResponse response = client.ExecuteGet(request);

            //this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<VehicleDto>();

            return JsonConvert.DeserializeObject<List<VehicleDto>>(response.Content);
        }

        internal VehicleDto Update(VehicleDto payload)
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

            return JsonConvert.DeserializeObject<VehicleDto>(response.Content);
        }
    }
}