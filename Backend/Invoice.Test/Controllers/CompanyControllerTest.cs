using Invoice.DTO;
using Invoice.Model;
using Invoice.Test.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace Invoice.Test.Controllers
{
    public class CompanyControllerTest : IClassFixture<InvoiceWebAppFactory>
    {

        private readonly HttpClient _client;
        private readonly InvoiceWebAppFactory _factory;

        public CompanyControllerTest(InvoiceWebAppFactory factory)
        {
            this._client = factory.CreateClient(); // Simulates real HTTP requests
            this._factory = factory;
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
            var response = await this._client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            //Act

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


        [Fact]
        public async void GetAll_Throws_An_Exception()
        {
            string url = $"/api/company/get-all";
            this._factory.CompanyRepository.Setup(x => x.GetAll()).ThrowsAsync(new Exception());

            var response = await this._client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Fact]
        public async void GetAll_Return_AllObject()
        {
            //Arrange
            string url = $"/api/company/get-all";
            var list = readFile<List<Company>>("Invoice.Test.Properties.Company.companiesModel.json");
            this._factory.CompanyRepository.Setup(x => x.GetAll()).ReturnsAsync(list);

            //Act
            var response = await this._client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            //Assert
            List<CompanyDtoTest> expectedDto = this.readFile<List<CompanyDtoTest>>("Invoice.Test.Properties.Company.companiesDto.json");
            List<CompanyDtoTest> compDto = JsonConvert.DeserializeObject<List<CompanyDtoTest>>(content);

            Assert.True(expectedDto.SequenceEqual(compDto));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            
        }

        #endregion

        private T readFile<T>(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
                throw new FileNotFoundException($"Embedded resource '{resourceName}' not found.");

            using StreamReader reader = new StreamReader(stream);
            string json = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<T>(json); //serializer.Deserialize(reader, typeof(List<Company>));
        }
    }
}