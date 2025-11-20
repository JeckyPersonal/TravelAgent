using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Invoice.UI.Main.PresenterFactory;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.CodeDom;
using System.Collections.Generic;

namespace Invoice.UI.Driver
{
    public class DriverRestClient : BaseRestClient
    {
        public static DriverRestClient Instance => new DriverRestClient();
        private readonly string _controller = "/api/Driver";

        private DriverRestClient() : base("/api/Driver")
        {

        }

        internal DriverDto Add(DriverDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("add", RestSharp.Method.Post);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<DriverDto>(response);
        }

        internal DriverDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get/{id}", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<DriverDto>(response);
        }

        internal List<DriverDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("get-all", RestSharp.Method.Get);
            
            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<DriverDto>>(response);
        }

        internal DriverDto Update(DriverDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{payload.Id}", RestSharp.Method.Put);
            
            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<DriverDto>(response);
        }
    }
}