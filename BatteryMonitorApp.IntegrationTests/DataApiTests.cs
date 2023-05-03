using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

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
