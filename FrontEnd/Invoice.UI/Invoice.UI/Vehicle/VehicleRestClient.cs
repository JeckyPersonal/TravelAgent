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
    internal class VehicleRestClient : BaseRestClient
    {
        public static VehicleRestClient Instance => new VehicleRestClient();
        private readonly string _controller = "/api/vehicle";

        private VehicleRestClient():base("/api/vehicle")
        {

        }

        internal VehicleDto Add(VehicleDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("add", RestSharp.Method.Post);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<VehicleDto>(response);
        }

        internal VehicleDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get/{id}", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<VehicleDto>(response);
        }

        internal List<VehicleDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("get-all", RestSharp.Method.Get);
            
            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<VehicleDto>>(response);
        }

        internal VehicleDto Update(VehicleDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{payload.Id}", RestSharp.Method.Put);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<VehicleDto>(response);
        }

        internal VehicleDto Delete(VehicleDto vehicleDto)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"delete/{vehicleDto.Id}", Method.Delete);

            RestResponse response = client.ExecuteDelete(request);

            return this.ProcessResponse<VehicleDto>(response);
        }
    }
}