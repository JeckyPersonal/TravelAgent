using Invoice.UI.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Invoice.UI.Vehicle.RateConfiguration
{
    internal class VehicleRateConfigurationRestClient :InvoiceRestClient
    {
        public static VehicleRateConfigurationRestClient Instance = new VehicleRateConfigurationRestClient();
        public VehicleRateConfigurationRestClient() : base("api/vehiclerate")
        {
        }

        internal VehicleRateDto Add(VehicleRateDto dto)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"add", Method.Post);
            request.AddJsonBody(dto);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<VehicleRateDto>(response);
        }

        internal List<VehicleRateDto> GetAll(int vehicleId)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-all/{vehicleId}", Method.Get);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<List<VehicleRateDto>>(restResponse);
        }

        internal VehicleRateDto Update(int id, VehicleRateDto dto)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{id}", Method.Put);
            request.AddJsonBody(dto);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<VehicleRateDto>(response);
        }
    }
}