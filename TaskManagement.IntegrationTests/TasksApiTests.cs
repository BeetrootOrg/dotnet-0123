using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Testing;

using Newtonsoft.Json;

using Shouldly;

using TaskManagement.Contracts.Http;

namespace TaskManagement.IntegrationTests
{
    public class TasksApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public TasksApiTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CreateTaskShouldDoItSuccessfully()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.PutAsync("tasks", new StringContent(
                JsonConvert.SerializeObject(new CreateTaskRequest
                {
                    Title = "Title",
                    Description = "Description"
                }), Encoding.UTF8, "application/json"));

            // Assert
            _ = response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();
            CreateTaskResponse responseModel = JsonConvert.DeserializeObject<CreateTaskResponse>(responseString);

            responseModel.Id.ShouldNotBeEmpty();
            response.Headers.Location.ToString().ShouldBe($"tasks/{responseModel.Id}");
        }
    }
}