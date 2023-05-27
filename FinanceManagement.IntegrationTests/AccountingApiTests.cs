using System;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Testing;

using AccountingManagement.Contracts.Http;

using Newtonsoft.Json;
using System.Text;
using Shouldly;
using FinanceManagement.Contracts.Http;
using System.Net;

namespace FinanceManagement.IntegrationTests
{
    public class TasksApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public TasksApiTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CreateAccountingShouldDoItSuccessfully()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            Random r = new Random();
            int value = r.Next(0, 1000);
            string title = Guid.NewGuid().ToString();

            // Act
            HttpResponseMessage response = await client.PutAsync("accountings", new StringContent(
                JsonConvert.SerializeObject(new CreateAccountingRequest
                {
                    Title = title,
                    Value = value,
                }), Encoding.UTF8, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();
            CreateAccountingResponse responseModel = JsonConvert.DeserializeObject<CreateAccountingResponse>(responseString);

            responseModel.Id.ShouldNotBeEmpty();
            response.Headers.Location.ToString().ShouldBe($"accounting/{responseModel.Id}");
        }


        [Theory]
        [InlineData(-100)]
        [InlineData(0.5)]
        public async Task CreateAccountingShouldReturnBadRequestWhenValueIsNotValid(int value)
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            string title = Guid.NewGuid().ToString();

            // Act
            HttpResponseMessage response = await client.PutAsync("accountings", new StringContent(
                JsonConvert.SerializeObject(new CreateAccountingRequest
                {
                    Title = title,
                    Value = value,
                }), Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }


        [Fact]
        public async Task GetAccountingByIdShouldDoItSuccessfully()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            Random r = new Random();
            int value = r.Next(0, 1000);
            string title = Guid.NewGuid().ToString();

            HttpResponseMessage createResponse = await client.PutAsync("accountings", new StringContent(
                JsonConvert.SerializeObject(new CreateAccountingRequest
                {
                    Title = title,
                    Value = value
                }), Encoding.UTF8, "application/json"));

            createResponse.EnsureSuccessStatusCode();
            string createResponseString = await createResponse.Content.ReadAsStringAsync();
            CreateAccountingResponse createResponseModel = JsonConvert.DeserializeObject<CreateAccountingResponse>(createResponseString);

            // Act
            HttpResponseMessage getResponse = await client.GetAsync($"accountings/{createResponseModel.Id}");

            // Assert
            getResponse.EnsureSuccessStatusCode();
            string getResponseString = await getResponse.Content.ReadAsStringAsync();
            GetAccountingByIdResponse getResponseModel = JsonConvert.DeserializeObject<GetAccountingByIdResponse>(getResponseString);
            var accounting = getResponseModel.Accounting;

            accounting.ShouldNotBeNull();
            accounting.Id.ShouldBe(createResponseModel.Id);
            accounting.Title.ShouldBe(title);
            accounting.Value.ShouldBe(value);
        }


    }
}