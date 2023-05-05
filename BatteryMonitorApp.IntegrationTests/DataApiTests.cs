

using System.Net;

using BatteryMonitorApp.Contracts.Models.Http;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

using Newtonsoft.Json;

using Shouldly;

namespace BatteryMonitorApp.IntegrationTests
{
    public class DataApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public DataApiTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task PutDataCheckUri()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();
            // Act
            HttpResponseMessage response = await client.PutAsync("api/data", new StringContent(""));
            var code = response.StatusCode;
            // Assert
            Assert.True(code != HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task PutDataCheckCheckIsSuccessStatusCode()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();
            var formdata = new BatteryDataShortFormat()
            {
                Di = Guid.NewGuid(),
                V = 33.5f
            };
            // Act
            HttpResponseMessage response = await client.PutAsync("api/data", new StringContent(
            JsonConvert.SerializeObject(formdata), System.Text.Encoding.UTF8, "application/json"));
            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }
        [Fact]
        public async Task PutDataSendEmptyData()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();
            // Act
            HttpResponseMessage response = await client.PutAsync("api/data", new StringContent(""));
            var code = response.StatusCode;
            // Assert
            Assert.True(code == HttpStatusCode.UnsupportedMediaType);
        }

        //[Fact]
        //public async Task PutDataShouldDoItSuccessfully()
        //{
        //    // Arrange
        //    HttpClient client = _factory.CreateClient();
        //    float volt = 5;
        //    Guid device = Guid.NewGuid();

        //    // Act
        //    HttpResponseMessage response = await client.PutAsync("api/data", new StringContent(
        //        JsonConvert.SerializeObject(new BatteryDataRequest
        //        {
        //             DeviceId= device, Voltage=volt
        //        }), Encoding.UTF8, "application/json"));

        //    // Assert
        //    _ = response.EnsureSuccessStatusCode();
        //    string responseString = await response.Content.ReadAsStringAsync();
        //    BatteryDataResponse responseModel = JsonConvert.DeserializeObject<BatteryDataResponse>(responseString);
        //    responseModel.Result.ShouldBeTrue();
        //}
    }
}
