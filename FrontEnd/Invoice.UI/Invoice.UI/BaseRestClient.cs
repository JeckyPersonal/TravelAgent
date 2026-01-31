using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI
{
    public abstract class BaseRestClient
    {
        protected string Controller;

        protected BaseRestClient(string controller)
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

        protected byte[] ProcessBinaryResponse(RestSharp.RestResponse response)
        {
            HandleErrors(response);

            if (response.StatusCode == HttpStatusCode.NoContent)
                return Array.Empty<byte>();

            var contentType = response.ContentType?.ToLower();

            if (contentType == null || !contentType.Contains("application/pdf"))
                throw new Exception($"Unexpected content type: {contentType}");


            return response.RawBytes;
        }

        protected T ProcessResponse<T>(RestSharp.RestResponse response) where T : new()
        {

            HandleErrors(response);

            if (response.StatusCode == HttpStatusCode.NoContent)
                return new T();

            return JsonConvert.DeserializeObject<T>(response.Content);

        }

        protected void HandleErrors(RestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest ||
                response.StatusCode == HttpStatusCode.Forbidden)
            {
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    var validationResponse =
                        JsonConvert.DeserializeObject<ValidationErrorResponse>(response.Content);

                    throw new ValidationException(validationResponse);
                }
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new Exception("Unhandled exception occurred. Please contact administrator.");
            }
        }
    }
}
