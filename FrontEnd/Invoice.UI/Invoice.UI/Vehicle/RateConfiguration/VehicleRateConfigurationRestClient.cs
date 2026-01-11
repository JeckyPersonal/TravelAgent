using Invoice.UI.DTO;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Invoice.UI.Vehicle.RateConfiguration
{
    internal class VehicleRateConfigurationRestClient :BaseRestClient
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

        internal VehicleRateDto Delete(int id) 
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"delete/{id}", Method.Delete);

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

        internal CustomerRateDto Get(int itemId, int vehicleId, int customerId)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get/{customerId}/{vehicleId}/{itemId}", Method.Get);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<CustomerRateDto>(restResponse);
        }

        internal virtual List<CustomerRateDto> GetAll(int vehicleId, int customerId)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-all/{vehicleId}/{customerId}", Method.Get);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<List<CustomerRateDto>>(restResponse);
        }

        internal CustomerRateDto Add(CustomerRateDto dto)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"add", Method.Post);
            request.AddJsonBody(dto);

            RestResponse response = restClient.Execute(request);

            return this.ProcessResponse<CustomerRateDto>(response);
        }

        internal RateInfoDto GetRateInformation(int itemId, int vehicleId, int customerId)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get-rate", Method.Get);
            if (customerId > 0)
                request.AddQueryParameter("customerId", customerId);

            if (vehicleId > 0)
                request.AddQueryParameter("vehicleId", vehicleId);

            if (itemId > 0)
                request.AddQueryParameter("itemId", itemId);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<RateInfoDto>(response);
        }

        internal CustomerRateDto Delete(int id)
        {
            RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"delete/{id}", Method.Delete);

            RestResponse restResponse = restClient.Execute(request);

            return this.ProcessResponse<CustomerRateDto>(restResponse);
        }

    }
}