using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.Domain.Models.DataBase;

using Microsoft.EntityFrameworkCore;

namespace BatteryMonitorApp.Domain.DbContexts
{
    public class BatteryMonitorContext:DbContext
    {
        public DbSet<BatteryData> BatteryDatas { get; set; }
        public BatteryMonitorContext() { }
        public BatteryMonitorContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=battery_mon;User Id=batt_app;Password=batt_app;");
            base.OnConfiguring(optionsBuilder);
        }



    }
}
