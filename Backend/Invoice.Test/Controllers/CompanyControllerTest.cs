using Invoice.DTO;
using Invoice.Model;
using Invoice.Test.Model;
using Invoice.Test.Model.Company;
using Invoice.Test.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Invoice.Test.Controllers
{
    public class CompanyControllerTest : IClassFixture<InvoiceWebAppFactory>
    {

        private readonly HttpClient _client;
        private readonly InvoiceWebAppFactory _factory;
        private readonly ResourceUtils _resourceUtils;
        private readonly RestExecutorUtils _restUtils;

        public CompanyControllerTest(InvoiceWebAppFactory factory)
        {
            this._client = factory.CreateClient(); // Simulates real HTTP requests
            this._factory = factory;
            this._resourceUtils = new ResourceUtils();
            this._restUtils = new RestExecutorUtils(this._client);
        }

        #region "GetAll API"

        [Fact]
        public async Task GetAll_Return_NoContent()
        {
            //Arrange
            string url = $"/api/company/get-all";
            List<Company>? companies = null;
            this._factory.CompanyRepository.Setup(x => x.GetAll()).ReturnsAsync(companies);

            //Assert
            HttpResponseDto restResponse = await this._restUtils.ExecuteGet(url);

            //Act
            Assert.Equal(HttpStatusCode.NoContent, restResponse.Status);
        }


        [Fact]
        public async void GetAll_Throws_An_Exception()
        {
            string url = $"/api/company/get-all";
            this._factory.CompanyRepository.Setup(x => x.GetAll()).ThrowsAsync(new Exception());

            HttpResponseDto restResponse = await this._restUtils.ExecuteGet(url);

            Assert.Equal(HttpStatusCode.InternalServerError, restResponse.Status);
        }

        [Fact]
        public async void GetAll_Return_AllObject()
        {
            //Arrange
            string url = $"/api/company/get-all";
            var list = this._resourceUtils.readAndDeserializeFileFile<List<Company>>("Invoice.Test.Properties.Company.companiesModel.json");
            this._factory.CompanyRepository.Setup(x => x.GetAll()).ReturnsAsync(list);

            //Act
            HttpResponseDto restResponse = await this._restUtils.ExecuteGet(url);

            //Assert
            List<CompanyDtoTest> expectedDto = this._resourceUtils.readAndDeserializeFileFile<List<CompanyDtoTest>>("Invoice.Test.Properties.Company.companiesDto.json");
            List<CompanyDtoTest> compDto = JsonConvert.DeserializeObject<List<CompanyDtoTest>>(restResponse.Content);

            Assert.True(expectedDto.SequenceEqual(compDto));
            Assert.Equal(HttpStatusCode.OK, restResponse.Status);

        }

        #endregion

        #region "Add API"

        [Theory]
        [InlineData("", "", "", "{\"Name\": [ \"The 'Name' field is required. Please provide a name and try again.\" ],\"GSTNo\": [ \"The 'GSTNo' field is required. Please provide a name and try again.\" ], \"PANNo\": [ \"The 'PANNo' field is required. Please provide a name and try again.\" ] }")]
        [InlineData("Tech Solutions Inc.", "", "", "{\"GSTNo\": [ \"The 'GSTNo' field is required. Please provide a name and try again.\" ], \"PANNo\": [ \"The 'PANNo' field is required. Please provide a name and try again.\" ] }")]
        [InlineData("", "27AABCU9603R1ZV", "", "{\"Name\": [ \"The 'Name' field is required. Please provide a name and try again.\" ], \"PANNo\": [ \"The 'PANNo' field is required. Please provide a name and try again.\" ] }")]
        [InlineData("", "", "AABCU9603R", "{\"Name\": [ \"The 'Name' field is required. Please provide a name and try again.\" ],\"GSTNo\": [ \"The 'GSTNo' field is required. Please provide a name and try again.\" ] }")]
        [InlineData("Tech Solutions Inc.", "27AABCU9603R1ZV", "", "{\"PANNo\": [ \"The 'PANNo' field is required. Please provide a name and try again.\" ] }")]
        [InlineData("Tech Solutions Inc.", "", "AABCU9603R", "{\"GSTNo\": [ \"The 'GSTNo' field is required. Please provide a name and try again.\" ]}")]
        [InlineData("", "27AABCU9603R1ZV", "AABCU9603R", "{\"Name\": [ \"The 'Name' field is required. Please provide a name and try again.\" ]}")]
        public async void Add_WhenRequiredFieldIsBlank_ShouldReturnBadRequest(string companyName, string GSTNo, string PanNo, string errors)
        {
            //Arrange
            string url = $"/api/company/add";

            //Assert
            CompanyResult result = this._resourceUtils.readAndDeserializeFileFile<CompanyResult>("Invoice.Test.Properties.Company.Add.companyModel.json");
            result.Payload.Name = companyName;
            result.Payload.PANNo = PanNo;
            result.Payload.GSTNo = GSTNo;

            Dictionary<string, List<string>> error =  JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(errors);
            result.Response.Errors = error;

            string json = JsonConvert.SerializeObject(result.Payload);

            var payload = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await this._client.PostAsync(url, payload);
            var content = await response.Content.ReadAsStringAsync();

            ValidationErrorResponse validationResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(content);

            //Act
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal(result.Response, validationResponse);
        }

        [Fact]
        public async void Add_WhenAllRequiredFieldsAreAvailable_ShouldSaveObject()
        {
            //Arrange
            string url = $"/api/company/add";
            Company nullCompany = null;
            CompanyResultPositiveCase result = this._resourceUtils.readAndDeserializeFileFile<CompanyResultPositiveCase>("Invoice.Test.Properties.Company.Add.companyModelPositiveCase.json");
            this._factory.CompanyRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Company, bool>>>(), true)).ReturnsAsync(nullCompany);
            Company company = new Company() { Id = 1, Name = "Tech Solutions Inc.", Address1 = "123 Main Street", Address2 = "Suite 400", Address3 = "Business Park", City = "San Francisco", State = "California", Country = "USA", Zip = "94107", GSTNo = "27AABCU9603R1ZV", PANNo = "AABCU9603R", PhoneNumber = "+1-800-123-4567" };
            this._factory.CompanyRepository.Setup(x => x.Add(It.IsAny<Invoice.Model.Company>())).ReturnsAsync(company);

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecutePost<CompanyDtoTest>(url, result.Payload);

            //Assert
            CompanyDtoTest actualResponse = JsonConvert.DeserializeObject<CompanyDtoTest>(responseDto.Content);
            Assert.Equal(HttpStatusCode.Created, responseDto.Status);
            Assert.Equal(result.Response, actualResponse);
        }

        [Fact]
        public async void Add_WhenIdIsGreterThenZero_ShouldReturnBadRequest()
        {
            //Arrange
            string url = $"/api/company/add";
            CompanyResult result =  this._resourceUtils.readAndDeserializeFileFile<CompanyResult>("Invoice.Test.Properties.Company.Add.CompanyIdIsNonZeroWhileAdding.json");

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecutePost(url, result.Payload);

            //Assert
            ValidationErrorResponse errorResponse =  JsonConvert.DeserializeObject<ValidationErrorResponse>(responseDto.Content);
            Assert.Equal(HttpStatusCode.BadRequest, responseDto.Status);
            Assert.Equal(result.Response, errorResponse);
        }

        [Fact]
        public async void Add_WhenCompanyNameIsExist_ShouldReturnConflict()
        {
            //Arrange
            string url = $"/api/company/add";
            CompanyResult result = this._resourceUtils.readAndDeserializeFileFile<CompanyResult>("Invoice.Test.Properties.Company.Add.CompanyModelForDuplicate.json");
            this._factory.CompanyRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Company, bool>>>(), true)).ReturnsAsync(new Company() { Id = 1 });

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecutePost(url, result.Payload);

            //Act
            ValidationErrorResponse errorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(responseDto.Content);
            Assert.Equal(HttpStatusCode.Conflict, responseDto.Status);
            Assert.Equal(result.Response, errorResponse);
        }

        #endregion

        #region "GetById"

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void GetById_InvalidId_ShouldReturnBadRequest(int id)
        {
            //Arrange
            string url = $"/api/company/get/{id}";
            ValidationErrorResponse errorResponse = this._resourceUtils.readAndDeserializeFileFile<ValidationErrorResponse>("Invoice.Test.Properties.Company.GetById.ValidationException.json");

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecuteGet(url);

            //Assert
            ValidationErrorResponse actualResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(responseDto.Content);
            Assert.Equal(HttpStatusCode.BadRequest, responseDto.Status);
            Assert.Equal(errorResponse, actualResponse);
        }

        [Fact]
        public async void GetById_NoDataForId_ShouldReturnNoContent()
        {
            //Arrange
            string url = $"/api/company/get/2";
            Company nullCompany = null;
            this._factory.CompanyRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Company, bool>>>(), true)).ReturnsAsync(nullCompany);

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecuteGet(url);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, responseDto.Status);
        }

        [Fact]
        public async void GetById_HasRecordForId_ShouldReturnOK()
        {
            //Arrange
            string url = $"/api/company/get/2";
            Company result = this._resourceUtils.readAndDeserializeFileFile<Company>("Invoice.Test.Properties.Company.CompanyModel.json");
            CompanyDtoTest exepctedModel = this._resourceUtils.readAndDeserializeFileFile<CompanyDtoTest>("Invoice.Test.Properties.Company.CompanyModel.json");
            this._factory.CompanyRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Company, bool>>>(), true)).ReturnsAsync(result);

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecuteGet(url);

            //Assert
            CompanyDtoTest actualModel = JsonConvert.DeserializeObject<CompanyDtoTest>(responseDto.Content);
            Assert.Equal(HttpStatusCode.OK, responseDto.Status);
            Assert.Equal(exepctedModel, actualModel);

        }

        #endregion


    }
}