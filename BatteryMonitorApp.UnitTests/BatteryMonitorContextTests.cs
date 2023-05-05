using BatteryMonitorApp.Domain.DbContexts;
using Microsoft.EntityFrameworkCore;
using BatteryMonitorApp.Domain.Models.DataBase;

namespace BatteryMonitorApp.UnitTests
{
    public class BatteryMonitorContextTests
    {
        [Fact]
        public void BatteryMonitorContextIsCreatedAndConnected()
        {
            // Arrange
            using var context = CreateContext();
            // Act
            // Assert
            Assert.NotNull(context);
            Assert.IsType<BatteryMonitorContext>(context);
            Assert.True(context.Database.CanConnect());
        }

        [Fact]
        public async Task BatteryMonitorContextCanAddAndNotEmpty()
        {
            // Arrange
            using var context = CreateContext();
            // Act 
            await context.BatteryDatas.AddAsync(new() { DeviceId = Guid.NewGuid(), Voltage=10 });
            var savecount = await context.SaveChangesAsync();
            var countrecs = await context.BatteryDatas.CountAsync();
            // Assert
            Assert.True(savecount > 0);
            Assert.True(countrecs > 0);
        }
        [Fact]
        public async Task BatteryMonitorContextAddededDataEquals()
        {
            // Arrange
            using var context = CreateContext();
            var data =new BatteryData() {DeviceId=Guid.NewGuid() };
            data.Current = 12;
            data.Status = 1;
            // Act 
            await context.BatteryDatas.AddAsync(data);
            await context.SaveChangesAsync();
            var datafromdb = context.BatteryDatas.
                Where(x => x.DeviceId == data.DeviceId).ToArray().Last();
            // Assert
            Assert.True(data.DeviceId==datafromdb.DeviceId);
            Assert.True(data.Current == datafromdb.Current);
            Assert.True(data.Status == datafromdb.Status);
        }

        [Fact]
        public async Task BatteryMonitorContextBatteryDatasNotEmpty()
        {
            // Arrange
            using var context = CreateContext();
            // Act 
            var data=await context.BatteryDatas.FirstOrDefaultAsync(x=>true);
            // Assert
            Assert.NotNull(data);
        }

        internal static BatteryMonitorContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder().UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;DataBase=battery_mon;User Id=batt_app;Password=batt_app;");
            return new BatteryMonitorContext(builder.Options);
        }
    }
}
