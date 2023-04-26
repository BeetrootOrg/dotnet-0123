using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Testing;

using Newtonsoft.Json;

using Shouldly;

using TaskManagement.Contracts.Http;

using ContractsTask = TaskManagement.Contracts.Models.Task;
using ContractsTaskStatus = TaskManagement.Contracts.Models.TaskStatus;

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

            string title = Guid.NewGuid().ToString();
            string description = Guid.NewGuid().ToString();

            // Act
            HttpResponseMessage response = await client.PutAsync("tasks", new StringContent(
                JsonConvert.SerializeObject(new CreateTaskRequest
                {
                    Title = title,
                    Description = description
                }), Encoding.UTF8, "application/json"));

            // Assert
            _ = response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();
            CreateTaskResponse responseModel = JsonConvert.DeserializeObject<CreateTaskResponse>(responseString);

            responseModel.Id.ShouldNotBeEmpty();
            response.Headers.Location.ToString().ShouldBe($"tasks/{responseModel.Id}");
        }

        [Fact]
        public async Task GetTaskByIdShouldDoItSuccessfully()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            string title = Guid.NewGuid().ToString();
            string description = Guid.NewGuid().ToString();

            HttpResponseMessage createResponse = await client.PutAsync("tasks", new StringContent(
                JsonConvert.SerializeObject(new CreateTaskRequest
                {
                    Title = title,
                    Description = description
                }), Encoding.UTF8, "application/json"));

            _ = createResponse.EnsureSuccessStatusCode();
            string createResponseString = await createResponse.Content.ReadAsStringAsync();
            CreateTaskResponse createResponseModel = JsonConvert.DeserializeObject<CreateTaskResponse>(createResponseString);

            // Act
            HttpResponseMessage getResponse = await client.GetAsync($"tasks/{createResponseModel.Id}");

            // Assert
            _ = getResponse.EnsureSuccessStatusCode();
            string getResponseString = await getResponse.Content.ReadAsStringAsync();
            GetTaskByIdResponse getResponseModel = JsonConvert.DeserializeObject<GetTaskByIdResponse>(getResponseString);
            ContractsTask task = getResponseModel.Task;

            _ = task.ShouldNotBeNull();
            task.Id.ShouldBe(createResponseModel.Id);
            task.Title.ShouldBe(title);
            task.Description.ShouldBe(description);
            task.Status.ShouldBe(ContractsTaskStatus.New);
            task.AssigneeEmail.ShouldBeNull();
            task.UpdatedAt.ShouldBeNull();
        }

        [Fact]
        public async Task GetTaskByIdShouldReturnNotFound()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync($"tasks/{Guid.NewGuid()}");

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }
    }
}