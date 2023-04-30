using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.Domain.Commands;
using BatteryMonitorApp.Domain.Models.DataBase;
using BatteryMonitorApp.UnitTests.Repositories;

using MediatR;

using Moq;

namespace BatteryMonitorApp.UnitTests.Commands
{
    public class BatteryDataCommandTests
    {
        private readonly Mock<IRepository> _repositotyMock = new();
        private readonly IRequestHandler<BatteryDataCommand, BatteryDataResult> _handler;

        public BatteryDataCommandTests()
        {
            _handler = new BatteryDataCommandHandler(_repositotyMock.Object);
        }
        [Fact]
        public async Task HadnleShouldAddDataToRepository()
        {
            var dev = Guid.NewGuid();
            var volt = 1;
            //Arange
            var command = new BatteryDataCommand()
            {
                DeviceId = dev,
                Voltage = volt,
            };
            //Act
            await _handler.Handle(command, CancellationToken.None);
            //Assert
            _repositotyMock.Verify(x => x.AddData(It.Is<BatteryData>(t =>
                t.Current == 0 &&
                t.Status == 0 &&
                t.DeviceId == dev &&
                t.Voltage == volt &&
                t.VoltageCharger == 0
            ), It.IsAny<CancellationToken>())
            , Times.Once);
        }
    }
}
