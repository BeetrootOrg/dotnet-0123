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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("dzPVGfry7Qfdbri3bvz73ro0VGj5d4GcUC5NMOsRx6hOUtDbXq4qrmap41BXN9h6gG6TuvgKcV5MdeACABQ1MYx8BQnLNaX1Me7cXKlBu8VQex3dwQO0HpPBClHlEHUyNegLQOoQbFkgX1X2c8rwozu2jqWkw5peTEmfHdMs6BOZKpVmS5Pg1nZ5rgB3v8S2AOcn9eHQBJ8d5A5RnphrT9azfoUJyAUERgVzC99lK3HBXApPa8ugj1q54BIeuggLu2c2")]
        public async Task CreateTaskShouldReturnBadRequestWhenTitleIsNotValid(string title)
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            string description = Guid.NewGuid().ToString();

            // Act
            HttpResponseMessage response = await client.PutAsync("tasks", new StringContent(
                JsonConvert.SerializeObject(new CreateTaskRequest
                {
                    Title = title,
                    Description = description
                }), Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task CreateTaskShouldReturnBadRequestWhenDescriptionIsNotValid(string description)
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            string title = Guid.NewGuid().ToString();

            // Act
            HttpResponseMessage response = await client.PutAsync("tasks", new StringContent(
                JsonConvert.SerializeObject(new CreateTaskRequest
                {
                    Title = title,
                    Description = description
                }), Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abc")]
        [InlineData("abc@")]
        public async Task AssignToUserShouldReturnBadRequestIfEmailIsNotValid(string email)
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            AssignTaskRequest request = new()
            {
                Email = email
            };

            // Act
            HttpResponseMessage response = await client.PostAsync($"tasks/{Guid.NewGuid()}", new StringContent(
                JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task AssignToUserShouldDoItSuccessfully()
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

            AssignTaskRequest request = new()
            {
                Email = $"{Guid.NewGuid():N}@gmail.com"
            };

            // Act
            HttpResponseMessage assignResponse = await client.PostAsync($"tasks/{createResponseModel.Id}", new StringContent(
                JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            // Assert
            _ = assignResponse.EnsureSuccessStatusCode();

            HttpResponseMessage getResponse = await client.GetAsync($"tasks/{createResponseModel.Id}");

            _ = getResponse.EnsureSuccessStatusCode();
            string getResponseString = await getResponse.Content.ReadAsStringAsync();
            GetTaskByIdResponse getResponseModel = JsonConvert.DeserializeObject<GetTaskByIdResponse>(getResponseString);
            ContractsTask task = getResponseModel.Task;
            task.AssigneeEmail.ShouldBe(request.Email);
            task.Status.ShouldBe(ContractsTaskStatus.Assigned);
        }

        [Fact]
        public async Task AssignToUserShouldReturnBadRequestIfTaskIsAssignedToOtherUser()
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

            AssignTaskRequest initialRequest = new()
            {
                Email = $"{Guid.NewGuid():N}@gmail.com"
            };

            HttpResponseMessage assignResponse = await client.PostAsync($"tasks/{createResponseModel.Id}", new StringContent(
                JsonConvert.SerializeObject(initialRequest), Encoding.UTF8, "application/json"));

            _ = assignResponse.EnsureSuccessStatusCode();

            AssignTaskRequest request = new()
            {
                Email = $"{Guid.NewGuid():N}@gmail.com"
            };

            // Act
            HttpResponseMessage response = await client.PostAsync($"tasks/{createResponseModel.Id}", new StringContent(
                JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
            string responseString = await response.Content.ReadAsStringAsync();
            ErrorModel errorResponse = JsonConvert.DeserializeObject<ErrorModel>(responseString);
            errorResponse.Message.ShouldBe($"Task status is not New but {ContractsTaskStatus.Assigned}");
        }
    }
}