using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.Contracts.Http;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

using Newtonsoft.Json;

using Shouldly;

namespace BatteryMonitorApp.IntegrationTests
{
    public class DatApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public DatApiTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task PutDataShouldDoItSuccessfully()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();
            float volt = 5;
            Guid device = Guid.NewGuid();

            // Act
            HttpResponseMessage response = await client.PutAsync("api/data", new StringContent(
                JsonConvert.SerializeObject(new BatteryDataRequest
                {
                     DeviceId= device, Voltage=volt
                }), Encoding.UTF8, "application/json"));

            // Assert
            _ = response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();
            BatteryDataResponse responseModel = JsonConvert.DeserializeObject<BatteryDataResponse>(responseString);

            responseModel.Result.ShouldBeTrue();
//            response.Headers.Location.ToString().ShouldBe($"api/data/{responseModel.Result}");
        }

        //[Fact]
        //public async Task GetTaskByIdShouldDoItSuccessfully()
        //{
        //    // Arrange
        //    HttpClient client = _factory.CreateClient();

        //    string title = Guid.NewGuid().ToString();
        //    string description = Guid.NewGuid().ToString();

        //    HttpResponseMessage createResponse = await client.PutAsync("tasks", new StringContent(
        //        JsonConvert.SerializeObject(new CreateTaskRequest
        //        {
        //            Title = title,
        //            Description = description
        //        }), Encoding.UTF8, "application/json"));

        //    _ = createResponse.EnsureSuccessStatusCode();
        //    string createResponseString = await createResponse.Content.ReadAsStringAsync();
        //    CreateTaskResponse createResponseModel = JsonConvert.DeserializeObject<CreateTaskResponse>(createResponseString);

        //    // Act
        //    HttpResponseMessage getResponse = await client.GetAsync($"tasks/{createResponseModel.Id}");

        //    // Assert
        //    _ = getResponse.EnsureSuccessStatusCode();
        //    string getResponseString = await getResponse.Content.ReadAsStringAsync();
        //    GetTaskByIdResponse getResponseModel = JsonConvert.DeserializeObject<GetTaskByIdResponse>(getResponseString);
        //    ContractsTask task = getResponseModel.Task;

        //    _ = task.ShouldNotBeNull();
        //    task.Id.ShouldBe(createResponseModel.Id);
        //    task.Title.ShouldBe(title);
        //    task.Description.ShouldBe(description);
        //    task.Status.ShouldBe(ContractsTaskStatus.New);
        //    task.AssigneeEmail.ShouldBeNull();
        //    task.UpdatedAt.ShouldBeNull();
        //}

        //[Fact]
        //public async Task GetTaskByIdShouldReturnNotFound()
        //{
        //    // Arrange
        //    HttpClient client = _factory.CreateClient();

        //    // Act
        //    HttpResponseMessage response = await client.GetAsync($"tasks/{Guid.NewGuid()}");

        //    // Assert
        //    response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        //}
    }
}
