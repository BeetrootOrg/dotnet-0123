
namespace BatteryMonitorApp.Contracts.Models.Http
{
    public class BatteryDataRequest
    {
        public Guid Di { get; set; }
        public DateTime F { get; set; }= DateTime.MinValue;
        public DateTime T  { get; set; }=DateTime.MaxValue;
        public int[] S { get; set; } = new int[] { 0,1,2,3,4,5,6,7,8,9 };
    }
}
