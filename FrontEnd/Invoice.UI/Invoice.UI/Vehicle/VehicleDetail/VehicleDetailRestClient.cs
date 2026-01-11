using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Invoice.UI.Vehicle.VehicleDetail
{
    internal class VehicleDetailRestClient : BaseRestClient
    {
        public static VehicleDetailRestClient Instance { get; internal set; } = new VehicleDetailRestClient();
        private readonly string _controller = "/api/VehicleDetail";

        private VehicleDetailRestClient(): base("api/VehicleDetail")
        {
            //Instance = new VehicleDetailRestClient();
        }

        internal VehicleDetailDto Add(int vehicleId, VehicleDetailDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"add/{vehicleId}", Method.Post);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<VehicleDetailDto>(response);
        }

        internal VehicleDetailDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get/{id}", Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<VehicleDetailDto>(response);
        }

        internal List<VehicleDetailDto> GetAll(int vehicleId)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-all/{vehicleId}", Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<VehicleDetailDto>>(response);
        }

        internal VehicleDetailDto Update(VehicleDetailDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{payload.Id}", Method.Put);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<VehicleDetailDto>(response);
        }
        internal VehicleDetailDto Delete(int id)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"delete/{id}", Method.Delete);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<VehicleDetailDto>(restResponse);
        }
    }
}