using Invoice.DTO;
using Invoice.Test.Model.Company;
using Invoice.UI.Exceptions;
using Invoice.UI.Payment;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Invoice.UI.Company
{
    public class CompanyRestClient : BaseRestClient
    {
        private static CompanyRestClient _instance => new CompanyRestClient();

        private CompanyRestClient():base("/api/Company")
        {

        }

        public List<CompanyDto> GetAllCompany()
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("get-all", RestSharp.Method.Get);

            RestResponse response = client.ExecuteGet(request);

            return this.ProcessResponse<List<CompanyDto>>(response);
        }

        public CompanyDto AddCompany(CompanyDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant("add", RestSharp.Method.Post);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<CompanyDto>(response);

        }

        public CompanyDto GetById(int id)
        {
            RestClient client = new RestClient(Settings.BaseUrl);
            
            RestRequest request = this.GetRestRequestWithTanant($"get/{id}", RestSharp.Method.Get);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<CompanyDto>(response);

        }

        internal CompanyDto UpdateCompany(CompanyDto payload)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"update/{payload.Id}", RestSharp.Method.Put);

            request.AddJsonBody(payload);

            RestResponse response = client.Execute(request);

            return this.ProcessResponse<CompanyDto>(response);

        }

        internal CompanyDto Delete(CompanyDto companyDto)
        {
            RestClient client = new RestClient(Settings.BaseUrl);

            RestRequest request = this.GetRestRequestWithTanant($"delete/{companyDto.Id}", Method.Delete);

            RestResponse response = client.ExecuteDelete(request);

            return this.ProcessResponse<CompanyDto>(response);
        }

        public static CompanyRestClient Instance => _instance; 
    }
}
