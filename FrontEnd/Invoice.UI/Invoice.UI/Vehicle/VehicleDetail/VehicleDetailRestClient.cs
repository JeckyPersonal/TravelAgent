using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Invoice.UI.Vehicle.VehicleDetail
{
    internal class VehicleDetailRestClient
    {
        public static VehicleDetailRestClient Instance { get; internal set; } = new VehicleDetailRestClient();
        private readonly string _controller = "/api/VehicleDetail";

        private VehicleDetailRestClient()
        {
            //Instance = new VehicleDetailRestClient();
        }

        internal VehicleDetailDto Add(int vehicleId, VehicleDetailDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{_controller}/add/{vehicleId}", RestSharp.Method.Post);
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

            return JsonConvert.DeserializeObject<VehicleDetailDto>(response.Content);
        }

        internal VehicleDetailDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{this._controller}/get/{id}", RestSharp.Method.Get);
            request.AddHeader("X-Company-Id", Settings.CompanyId);

            RestResponse response = client.ExecuteGet(request);

            //this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new VehicleDetailDto();

            return JsonConvert.DeserializeObject<VehicleDetailDto>(response.Content);
        }

        internal List<VehicleDetailDto> GetAll(int vehicleId)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{this._controller}/get-all/{vehicleId}", RestSharp.Method.Get);
            //request.AddHeader("X-Company-Id", Settings.CompanyId);

            RestResponse response = client.ExecuteGet(request);

            //this.assertResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new List<VehicleDetailDto>();

            return JsonConvert.DeserializeObject<List<VehicleDetailDto>>(response.Content);
        }

        internal VehicleDetailDto Update(VehicleDetailDto payload)
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

            return JsonConvert.DeserializeObject<VehicleDetailDto>(response.Content);
        }
    }
}