using Invoice.DTO;
using Invoice.Model;
using Invoice.Test.Model.Bank;
using Invoice.Test.Model.Company;
using Invoice.Test.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankControllerTest : IClassFixture<InvoiceWebAppFactory>
    {
        private readonly HttpClient _client;
        private readonly InvoiceWebAppFactory _factory;
        private readonly ResourceUtils _resourceUtils;
        private readonly RestExecutorUtils _restUtils;

        private const string URL_BANK_GET_ALL = $"/api/bank/get-all";
        private const string URL_BANK_GETBYID = "/api/bank/get/{0}";
        private const string URL_BANK_ADD = "/api/bank/add";
        private const string URL_BANK_UPDATE = "/api/bank/update/{0}";

        private const string RESOURCE_ALL_BANKS = "Invoice.Test.Properties.Bank.Banks.Json";
        private const string RESOURCE_VALIDATION_TEMPLET = "Invoice.Test.Properties.ValidationResponseTemplet.Json";
        private const string RESOURCE_BANK_JSON = "Invoice.Test.Properties.Bank.Bank.Json";

        public BankControllerTest(InvoiceWebAppFactory factory)
        {
            this._client = factory.CreateClient(); // Simulates real HTTP requests
            this._factory = factory;
            this._resourceUtils = new ResourceUtils();
            this._restUtils = new RestExecutorUtils(this._client);
        }

        #region GetAll

        [Fact]
        public async void GetAll_WhenNoRecordIsFound_ShouldReturnNoContent()
        {
            //Arrange
            this._factory.BankRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Bank>());

            //Act
            HttpResponseDto response = await this._restUtils.ExecuteGet(URL_BANK_GET_ALL);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.Status);
        }

        [Fact]
        public async void GetAll_WhenRepositoryThrowAnError_ShouldReturnInternalServerError()
        {
            //Arrange
            this._factory.BankRepository.Setup(x => x.GetAll()).ThrowsAsync(new Exception());

            //Act
            HttpResponseDto response = await this._restUtils.ExecuteGet(URL_BANK_GET_ALL);

            //Assert
            Assert.Equal(HttpStatusCode.InternalServerError, response.Status);

        }

        [Fact]
        public async void GetAll_PositiveCase_ShouldReturnOK()
        {
            //Arrange
            List<Invoice.Model.Bank> banks = this._resourceUtils.readAndDeserializeFileFile<List<Invoice.Model.Bank>>(RESOURCE_ALL_BANKS);
            this._factory.BankRepository.Setup(x => x.GetAll()).ReturnsAsync(banks);

            //Act
            HttpResponseDto response = await this._restUtils.ExecuteGet(URL_BANK_GET_ALL);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.Status);
        }

        #endregion

        #region GetById

        [Fact]
        public async void GetById_WhenIdIsLessThenEqualToZero_ShouldReturnBadRequest()
        {
            //Arrange
            string url = string.Format(URL_BANK_GETBYID, 0);
            ValidationErrorResponse validationErrorResponse = this._resourceUtils.GetErrorObject(RESOURCE_VALIDATION_TEMPLET, "Id", "Id should be grater then zero. Please re-try with non zero id.", HttpStatusCode.BadRequest);

            //Act
            HttpResponseDto httpResponse = await this._restUtils.ExecuteGet(url);

            //Assert
            ValidationErrorResponse actualResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(httpResponse.Content);
            Assert.Equal(HttpStatusCode.BadRequest, httpResponse.Status);
            Assert.Equal(validationErrorResponse, actualResponse);
        }

        [Fact]
        public async void GetById_WhenNoBankFoundForTheId_ShouldReturnNoContent()
        {
            //Arrange
            string url = string.Format(URL_BANK_GETBYID, 1);
            Bank nullBank = null;
            this._factory.BankRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Bank, bool>>>(), true)).ReturnsAsync(nullBank);

            //Act
            HttpResponseDto httpResponseDto = await this._restUtils.ExecuteGet(url);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, httpResponseDto.Status);
        }

        [Fact]
        public async void GetById_WhenRepositoryMethodThrowAnError_ShouldReturnInternalServerError()
        {
            //Arrange
            string url = string.Format(URL_BANK_GETBYID, 1);
            Bank nullBank = null;
            this._factory.BankRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Bank, bool>>>(), true)).ThrowsAsync(new Exception());

            //Act
            HttpResponseDto httpResponseDto = await this._restUtils.ExecuteGet(url);

            //Assert
            Assert.Equal(HttpStatusCode.InternalServerError, httpResponseDto.Status);
        }

        [Fact]
        public async void GetById_WhenModelFoundAtId_ShouldReturnOK()
        {
            //Arrange
            string url = string.Format(URL_BANK_GETBYID, 1);
            Bank bank = this._resourceUtils.readAndDeserializeFileFile<Bank>(RESOURCE_BANK_JSON);
            BankDto bankDto = this._resourceUtils.readAndDeserializeFileFile<BankDto>(RESOURCE_BANK_JSON);
            this._factory.BankRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Bank, bool>>>(), true)).ReturnsAsync(bank);

            //Act
            HttpResponseDto httpResponseDto = await this._restUtils.ExecuteGet(url);

            //Assert
            BankDtoTest responsedto = JsonConvert.DeserializeObject<BankDtoTest>(httpResponseDto.Content);
            Assert.Equal(HttpStatusCode.OK, httpResponseDto.Status);
            Assert.Equal(responsedto, bankDto);

        }

        #endregion

        #region Add

        [Fact]
        public async void AddBank_WhenRequiredFieldIsEmpty_ShouldReturnBadRequest()
        {
            //Arrange
            Bank bank = new Bank();
            ValidationErrorResponse expectedResponse = this._resourceUtils.GetErrorObject(RESOURCE_VALIDATION_TEMPLET, "BankName", string.Format(Constants.ERROR_MESSAGE_REQUIRED_FIELD, "BankName"), HttpStatusCode.BadRequest);

            //Act
            HttpResponseDto response = await this._restUtils.ExecutePost<Bank>(URL_BANK_ADD, bank);

            //Assert
            ValidationErrorResponse actualResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(response.Content);
            Assert.Equal(HttpStatusCode.BadRequest, response.Status);
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async void AddBank_WhenWithTheDuplicateBankName_ShouldReturnConflict()
        {
            //Arrange
            BankDto bankDto = this._resourceUtils.readAndDeserializeFileFile<BankDto>(RESOURCE_BANK_JSON);
            bankDto.Id = 0;
            Bank bank = new Bank() { Id = 2, BankName = bankDto.BankName };
            this._factory.BankRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Bank, bool>>>(), true)).ReturnsAsync(bank);

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecutePost(URL_BANK_ADD, bankDto);

            //Assert
            Assert.Equal(HttpStatusCode.Conflict, responseDto.Status);
        }

        [Fact]
        public async void AddBank_WhenIdIsNonZero_ShouldReturnBadRequest()
        {
            //Arrange
            BankDto bankDto = this._resourceUtils.readAndDeserializeFileFile<BankDto>(RESOURCE_BANK_JSON);
            Bank bank = new Bank() { Id = 2, BankName = bankDto.BankName };
            this._factory.BankRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Bank, bool>>>(), true)).ReturnsAsync(bank);
            ValidationErrorResponse expectedResponse = this._resourceUtils.GetErrorObject(RESOURCE_VALIDATION_TEMPLET, "Id", string.Format(Constants.ERROR_MESSAGE_ZERO_ID, "Bank"), HttpStatusCode.BadRequest);

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecutePost(URL_BANK_ADD, bankDto);

            //Assert
            ValidationErrorResponse actualResponse = responseDto.GetObject<ValidationErrorResponse>();
            Assert.Equal(HttpStatusCode.BadRequest, responseDto.Status);
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async void AddBank_WhenAddMethodOfRepositoryThrowAnException_ShouldReturnBadRequest()
        {
            //Arrange
            BankDto bankDto = this._resourceUtils.readAndDeserializeFileFile<BankDto>(RESOURCE_BANK_JSON);
            bankDto.Id = 0;
            this._factory.BankRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Bank, bool>>>(), true)).ThrowsAsync(new Exception());

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecutePost(URL_BANK_ADD, bankDto);

            //Assert
            Assert.Equal(HttpStatusCode.InternalServerError, responseDto.Status);
        }

        [Fact]
        public async void AddBank_PositiveCase_ShouldReturnOK()
        {

            //Arrange
            BankDto bankDto = this._resourceUtils.readAndDeserializeFileFile<BankDto>(RESOURCE_BANK_JSON);
            bankDto.Id = 0;
            Bank bank = this._resourceUtils.readAndDeserializeFileFile<Bank>(RESOURCE_BANK_JSON);
            Bank nullBank = null;
            this._factory.BankRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Bank, bool>>>(), true)).ReturnsAsync(nullBank);
            this._factory.BankRepository.Setup(x => x.Add(It.IsAny<Bank>())).ReturnsAsync(bank);

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecutePost(URL_BANK_ADD, bankDto);

            //Assert
            BankDtoTest actualResponse = JsonConvert.DeserializeObject<BankDtoTest>(responseDto.Content);
            bankDto.Id = bank.Id;
            Assert.Equal(HttpStatusCode.Created, responseDto.Status);
            Assert.Equal(actualResponse, bankDto);
        }

        #endregion

        #region Update

        [Fact]
        public async void UpdateBank_WhenRequiredFieldIsEmpty_ShouldReturnBadRequest()
        {
            //Arrange
            string url = string.Format(URL_BANK_UPDATE, 1);
            BankDto payload = this._resourceUtils.readAndDeserializeFileFile<BankDtoTest>(RESOURCE_BANK_JSON);
            payload.BankName = string.Empty;
            ValidationErrorResponse expectedErrorResponse = this._resourceUtils.GetErrorObject(RESOURCE_VALIDATION_TEMPLET, "BankName", string.Format(Constants.ERROR_MESSAGE_REQUIRED_FIELD, "BankName"), HttpStatusCode.BadRequest);

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecutePut(url, payload);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, responseDto.Status);
            Assert.Equal(expectedErrorResponse, responseDto.GetObject<ValidationErrorResponse>());
        }

        [Fact]
        public async void UpdateBank_WhenSameNameIsPresent_ShouldReturnConflict()
        {
            //Arrange
            string url = string.Format(URL_BANK_UPDATE, 1);
            BankDto payload = this._resourceUtils.readAndDeserializeFileFile<BankDtoTest>(RESOURCE_BANK_JSON);
            Bank bankFromRepository = this._resourceUtils.readAndDeserializeFileFile<Bank>(RESOURCE_BANK_JSON);
            bankFromRepository.Id = 2;
            this._factory.BankRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Bank, bool>>>(), true)).ReturnsAsync(bankFromRepository);

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecutePut(url, payload);

            //Assert
            Assert.Equal(HttpStatusCode.Conflict, responseDto.Status);
        }

        [Fact]
        public async void UpdateBank_WithZeroId_ShouldReturnBadRequest()
        {
            //Arrange
            string url = string.Format(URL_BANK_UPDATE, 0);
            BankDto payload = this._resourceUtils.readAndDeserializeFileFile<BankDtoTest>(RESOURCE_BANK_JSON);
            ValidationErrorResponse expectedErrorResponse = this._resourceUtils.GetErrorObject(RESOURCE_VALIDATION_TEMPLET, "Id", string.Format(Constants.ERROR_MESSAGE_NON_ZERO_ID, "Bank"), HttpStatusCode.BadRequest);

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecutePut(url, payload);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, responseDto.Status);
            Assert.Equal(expectedErrorResponse, responseDto.GetObject<ValidationErrorResponse>());
        }

        [Fact]
        public async void UpdateBank_WithRepositoryMethodThrowAnException_ShouldReturnInternalServerError()
        {
            //Arrange
            string url = string.Format(URL_BANK_UPDATE, 0);
            BankDto payload = this._resourceUtils.readAndDeserializeFileFile<BankDtoTest>(RESOURCE_BANK_JSON);
            this._factory.BankRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Bank, bool>>>(), true)).ThrowsAsync(new Exception());

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecutePut(url, payload);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, responseDto.Status);
        }

        [Fact]
        public async void UpdateBank_PositiveCase_ShouldReturnOK()
        {
            //Arrange
            string url = string.Format(URL_BANK_UPDATE, 1);
            BankDto payload = this._resourceUtils.readAndDeserializeFileFile<BankDtoTest>(RESOURCE_BANK_JSON);
            Bank bankById = new Bank() { Id = payload.Id, BankName = payload.BankName };
            Bank updatedBank = this._resourceUtils.readAndDeserializeFileFile<Bank>(RESOURCE_BANK_JSON);
            updatedBank.BankName = "NewYork Bank";
            BankDtoTest expectedResult = new BankDtoTest() { Id = updatedBank.Id, BankName = updatedBank.BankName };
            this._factory.BankRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Bank, bool>>>(), true)).ReturnsAsync(bankById);
            this._factory.BankRepository.Setup(x => x.Update(It.IsAny<Bank>())).ReturnsAsync(updatedBank);

            //Act
            HttpResponseDto responseDto = await this._restUtils.ExecutePut(url, payload);

            //Assert
            Assert.Equal(HttpStatusCode.OK, responseDto.Status);
            Assert.Equal(expectedResult, responseDto.GetObject<BankDtoTest>());
        }

        #endregion
    }
}
