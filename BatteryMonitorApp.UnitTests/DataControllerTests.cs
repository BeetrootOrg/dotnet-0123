using AutoMapper;

using BatteryMonitorApp.Domain.Repositories;
using BatteryMonitorApp.WebApi.Controllers;
using Microsoft.EntityFrameworkCore;

using Moq;

namespace BatteryMonitorApp.UnitTests
{
    public class DataControllerTests
    {
        [Fact]
        public void ControllerCreateTest()
        {
            // Arrange
            var repo= new Mock<IRepository>();
            var mapper = new Mock<IMapper>();
            // Act
            var controller = new DataController(repo.Object, mapper.Object);
            // Assert
            Assert.NotNull(controller);
        }
        
    }
}
