﻿using BatteryMonitorApp.Domain.Models.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BatteryMonitorApp.UnitTests
{
     public class BatteryMonitorContextTest
    {
        private readonly MemoryContext _context;
        public BatteryMonitorContextTest()
        {
            var options = new DbContextOptionsBuilder<MemoryContext>()
            .UseInMemoryDatabase(databaseName: "MovieListDatabase")
            .Options;
            _context = new MemoryContext(options);
        }
        [Fact]
        public async Task CreateContextTestAndDbsetsNotEmpty()
        {
            var options = new DbContextOptionsBuilder<MemoryContext>()
            .UseInMemoryDatabase(databaseName: "MovieListDatabase")
            .Options;
            var con =new MemoryContext(options);
            var dev1 = new BatteryRegisteredDevice() { Id = PhysicalDeviceEmulator.PhysicalDeviceEmulator.Id, DeviceName = "Test", UserId = Guid.NewGuid() };
            var dev2 = new BatteryRegisteredDevice() { Id = Guid.NewGuid(), DeviceName = "Test", UserId = Guid.NewGuid() };
            var dev3 = new BatteryRegisteredDevice() { Id = Guid.NewGuid(), DeviceName = "Test", UserId = Guid.NewGuid() };
            var data = new BatteryData() { Device = dev1 };
            var data1 = new BatteryData() { Device = dev1 };
            var data2 = new BatteryData() { Device = dev1 };
            con.Devices.Add(dev1);
            con.Devices.Add(dev2);
            con.Devices.Add(dev3);
            con.BatteryDatas.Add(data);
            con.BatteryDatas.Add(data1);
            con.BatteryDatas.Add(data2);
            con.SaveChanges();
            //Asserts
            Assert.Contains(con.Devices, x => x == dev1);
            Assert.Contains(con.BatteryDatas, x => x == data);
        }
    }
}
