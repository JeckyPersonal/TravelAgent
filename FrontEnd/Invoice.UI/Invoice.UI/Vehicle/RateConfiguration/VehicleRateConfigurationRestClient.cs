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

        protected VehicleRateConfigurationRestClient(string route) : base(route)
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

        internal virtual List<VehicleRateDto> GetAll(int vehicleId)
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

        internal VehicleRateDto Get(int itemId, int vehicleId)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-itemInfo/{vehicleId}/{itemId}", Method.Get);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<VehicleRateDto>(restResponse);
        }

    }

    internal class CustomerRateConfigurationRestClient : VehicleRateConfigurationRestClient
    {
        public static CustomerRateConfigurationRestClient CustomerInstance = new CustomerRateConfigurationRestClient();

        public CustomerRateConfigurationRestClient() : base("api/customerrate")
        {
            
        }

        internal virtual List<CustomerRateDto> GetAll(int vehicleId, int customerId)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-all/{vehicleId}/{customerId}", Method.Get);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<List<CustomerRateDto>>(restResponse);
        }
    }
}