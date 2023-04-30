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




    }
}
