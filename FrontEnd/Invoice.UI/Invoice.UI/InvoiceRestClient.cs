using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI
{
    public abstract class InvoiceRestClient
    {
        protected string Controller;

        protected InvoiceRestClient(string controller)
        {
            this.Controller = controller;
        }


        protected RestRequest GetRestRequestWithTanant(string route, RestSharp.Method method)
        {
            //RestClient restClient = new RestClient(Settings.BaseUrl);

            RestRequest request = new RestRequest($"{this.Controller}/{route}", method);
            request.AddHeader("X-Company-Id", Settings.CompanyId);
            request.AddHeader("X-AccountYear-Id", Settings.FinancialYearId);

            return request;
        }

        protected T ProcessResponse<T>(RestSharp.RestResponse response) where T : new()
        {
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    ValidationErrorResponse validationResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(response.Content);
                    throw new ValidationException(validationResponse);
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return new T();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Unhandled exception is throwen. Please contact to administrator.");
            }

            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
