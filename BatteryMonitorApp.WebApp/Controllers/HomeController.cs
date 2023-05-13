using System.Diagnostics;

using BatteryMonitorApp.Contracts.Models.Http;
using BatteryMonitorApp.Domain.Models.DataBase;
using BatteryMonitorApp.Domain.Repositories;
using BatteryMonitorApp.WebApp.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BatteryMonitorApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepository _repository;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, IRepository repository)
        {
            _logger = logger;
            _userManager = userManager;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult WikiApi()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> GetRegisteredDevices(CancellationToken token = default)
        {
            BatteryDevice[] result = Array.Empty<BatteryDevice>();
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                result = (await _repository.GetRegisteredDevices(new Guid(user.Id), token))
               .Select(x => new BatteryDevice(x)).ToArray();
            }
            return View(result);
        }
        [Authorize]
        public IActionResult CreateRegisteredDevices()
        {
            var data = new BatteryDevice();
            return View(data);
        }
        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateRegisteredDevices(BatteryDevice device,CancellationToken token=default)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Error");
            BatteryRegisteredDevice dev = new()
            {
                DeviceDescription = device.DeviceDescription,
                DeviceName = device.DeviceName,
                Id = device.Id,
                UserId = new Guid(user.Id)
            };
            await _repository.AddRegisteredDevices(dev, token);
            return RedirectToAction("GetRegisteredDevices");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public async Task PutData(CancellationToken token = default)
        //{
        //    using var _client = new HttpClient() { BaseAddress = new Uri("~/api/data") };
        //    HttpResponseMessage response = await _client.PutAsync("api/data", 
        //        new StringContent(@"{""Di"":""DE88CE88-E888-8A88-8888-888888888888"",""V"":""12""}"),token);
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        //ToDo Something in your local storage
        //    }
        //}

    }
}