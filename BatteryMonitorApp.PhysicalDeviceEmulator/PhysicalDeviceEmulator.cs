﻿using BatteryMonitorApp.Contracts.Models.Http;
using BatteryMonitorApp.Domain.Models.DataBase;

using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BatteryMonitorApp.PhysicalDeviceEmulator
{
    public class PhysicalDeviceEmulator
    {
        public double NominalCapacity { get; set; }
        public double NominalVolts { get; set; }
        private double _currentVolts = 0;


        public static readonly Guid Id = new Guid("DE88CE88-E888-8A88-8888-888888888888");
        public static readonly BatteryData TestBatteryData = new()
        {
            DeviceId = Id,
            Voltage = 12,
            DateTime = new DateTime(2000, 1, 1, 0, 0, 0, 0, 0),
            Status = 0,
            Current = 1,
            VoltageCharger = 0,
        };

        public static async Task<DateTime> DischargeApi(PhysicalDevice device, string urisite, CancellationToken token = default)
        {
            using var _client = new HttpClient() { BaseAddress = new Uri(urisite) };
            double _stepcapacity = 0;
            double _capacity = device. NominalCapacity;
            long i = 0;

            HttpResponseMessage res;
            do
            {
                var _currentVolts = GetVoltsIndex(_capacity / device. NominalCapacity) * device.NominalVolts;
                _stepcapacity = device.Current * device.delaysecs / 3600;

                BatteryDataShortFormat data = new()
                {
                    C = (float)device.Current,
                    Di = device.DeviceId,
                    V = (float)_currentVolts,
                    Dt =device.start,
                    S = 0
                };
                try
                {
                    res = await PutDataAsync(_client, data, token);
                }
                catch (Exception ex) { break; }
                device.start = device.start.AddSeconds(device.delaysecs);
                _capacity -= _stepcapacity;
                i++;
            } while (!token.IsCancellationRequested && _capacity > 0 && res.IsSuccessStatusCode);
            return device.start;
        }

        public static async Task<HttpResponseMessage> PutDataAsync(HttpClient client, BatteryDataShortFormat data, CancellationToken token = default)=>
             await client.PutAsync("api/data", new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"),token);



        internal static List<CapVolts> arr = new()
            {
                new() {c=0.98, r=1.35 },new() {c= 0.95,r= 1.15 }, new(){c= 0.93,r= 1.1 },
                new() { c=0.92,r= 1.05 },new() {c= 0.91, r=1 },new(){c= 0.90,r= 0.95 },new() {c= 0.7,r= 0.9 },
                new() {c= 0.5, r=0.85 },new() {c= 0.3,r= 0.75 }, new() {c= 0.15,r= .65 }, new(){ c=0.1,r= .35 },
                new() { c=0.09,r= 0.2}, new(){c= 0.07, r=0.1 },new(){c= 0.05,r= 0.08 }, new(){ c=0.25,r= 0.06 },
                new() {c= 0.0,r=0.01 }
            };

        public static double GetVoltsIndex(double capacityindex)
        {
            var res = arr.FirstOrDefault(x => x.c >= capacityindex);
            return res != null ? res.r : -1;
        }


    }

    internal record CapVolts
    {
        public double c { get; set; }
        public double r { get; set; }
    }

}