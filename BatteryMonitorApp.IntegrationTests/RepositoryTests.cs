using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.Domain.DbContexts;
using BatteryMonitorApp.Domain.Models.DataBase;
using BatteryMonitorApp.UnitTests.Repositories;

using Microsoft.EntityFrameworkCore;

using Shouldly;

using Xunit;

namespace BatteryMonitorApp.IntegrationTests
{
    public class RepositoryTests
    {
        private readonly IRepository _repository;

        public RepositoryTests()
        {
            var options = new DbContextOptionsBuilder<BatteryMonitorContext>().
                UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;DataBase=battery_mon;User Id=batt_app;Password=batt_app;").
                Options;
            _repository = new Repository(new(options));
        }

        [Fact]
        public async Task PutDataShouldSucess()
        {
            Guid device = Guid.NewGuid();
            float volt = 8;
            int stat = 4;
            float current = 1.0f;
            DateTime time = DateTime.UtcNow;
            var data = new BatteryData { Current = current, DeviceId = device, Status = stat, Voltage = volt, DateTime = time };
            await _repository.AddData(data);
            var options = new DbContextOptionsBuilder<BatteryMonitorContext>().
    UseSqlServer(
    "Server=(localdb)\\MSSQLLocalDB;DataBase=battery_mon;User Id=batt_app;Password=batt_app;").
    Options;
            using var context = new BatteryMonitorContext(options);
            var dbdata=context.BatteryDatas.ToArray().Last();
            dbdata.DateTime.ShouldBe(time);
            dbdata.Voltage.ShouldBe(volt);
            dbdata.DeviceId.ShouldBe(device);
            dbdata.Current.ShouldBe(current);
            dbdata.Status.ShouldBe(stat);
        }
    }
}
