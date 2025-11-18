using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Invoice.UI.FinancialYear
{
    internal class FinancialYearRestClient : BaseRestClient
    {
        public static FinancialYearRestClient Instance => new FinancialYearRestClient();
        private readonly string _controller = "/api/financialYear";

        private FinancialYearRestClient() : base("/api/financialYear")
        {

        }

        internal FinancialYearDto Get(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"get/{id}", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<FinancialYearDto>(response);
        }

        internal FinancialYearDto Add(FinancialYearDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("add", RestSharp.Method.Post);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<FinancialYearDto>(response);
        }

        internal FinancialYearDto Update(FinancialYearDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{payload.Id}", RestSharp.Method.Put);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<FinancialYearDto>(response);
        }

        internal List<FinancialYearDto> GetAll()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("get-all", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<FinancialYearDto>>(response);
        }

        internal List<FinancialYearDto> GetAll(int companyId)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("get-all", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<FinancialYearDto>>(response);

        }
    }
}