using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.Domain;
using BatteryMonitorApp.Domain.DbContexts;
using BatteryMonitorApp.Domain.Models.DataBase;
using BatteryMonitorApp.UnitTests.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace BatteryMonitorApp.UnitTests
{
    public class BatteryMonitorRepoTest
    {
        [Fact]
        public void RepoIsCreated()
        {
            // Arrange
            var repo = CreateRepo();
            // Act
            // Assert
            Assert.NotNull(repo);
        }
        [Fact]
        public async Task RepoCanAddDataAndCountChanges()
        {
            // Arrange
            var repo = CreateRepo();
            var data = PhysicalDeviceEmulator.PhysicalDeviceEmulator.TestBatteryData;
            data.Current = 12;
            data.Status = 1;
            // Act 
            var countb =await repo.GetBatteryData(data.DeviceId,
                data.DateTime.Subtract(new TimeSpan(12, 1, 1)),
                DateTime.UtcNow, new int[] { data.Status });
            await repo.AddData(data);
            var counta = await repo.GetBatteryData(data.DeviceId,
                data.DateTime.Subtract(new TimeSpan(12, 1, 1)),
                DateTime.UtcNow, new int[] { data.Status });
            // Assert
            Assert.True(countb.Length < counta.Length);
        }
        [Fact]
        public async Task RepoCanAddDataAndDataIsCorrect()
        {
            // Arrange
            var repo = CreateRepo();
            var data = new BatteryData() { DeviceId = Guid.NewGuid() };
            data.Current = 12;
            data.Status = 0;
            // Act 
            var changes=await repo.AddData(data);
            repo = CreateRepo();
            BatteryData[] arrdata = await repo.GetBatteryData(data.DeviceId,
                data.DateTime.Subtract(new TimeSpan(24, 12, 1)),
                DateTime.UtcNow, new int[] { 0,1,2,3,4 });
            BatteryData datafromdb = arrdata.LastOrDefault();
            // Assert
            Assert.True(arrdata?.Length > 0);
            Assert.NotNull(datafromdb);
            Assert.True(data.DeviceId == datafromdb?.DeviceId);
            Assert.True(data.Current == datafromdb?.Current);
            Assert.True(data.Status == datafromdb?.Status);
        }


        internal static IRepository CreateRepo()
        {
            
            var builder = new DbContextOptionsBuilder().UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;DataBase=battery_mon;User Id=batt_app;Password=batt_app;");
            var context=new BatteryMonitorContext(builder.Options);
            return new Repository(context);
        }
    }
}
