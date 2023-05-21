using System;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Testing;

using AccountingManagement.Contracts.Http;

using Newtonsoft.Json;
using System.Text;
using Shouldly;

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

            // Act
            HttpResponseMessage response = await client.PutAsync("accountings", new StringContent(
                JsonConvert.SerializeObject(new CreateAccountingRequest
                {
                    Title = "Title",
                    Value = 0,
                }), Encoding.UTF8, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();
            CreateAccountingResponse responseModel = JsonConvert.DeserializeObject<CreateAccountingResponse>(responseString);

            responseModel.Id.ShouldNotBeEmpty();
            response.Headers.Location.ToString().ShouldBe($"accounting/{responseModel.Id}");
        }
    }
}