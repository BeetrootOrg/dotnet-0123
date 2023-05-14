using BatteryMonitorApp.Contracts.Models.Http;
using BatteryMonitorApp.Domain.Repositories;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BatteryMonitorApp.WebApp.Controllers
{
    [Authorize]
    public class Physical : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepository _repository;

        public Physical(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, IRepository repository)
        {
            _logger = logger;
            _userManager = userManager;
            _repository = repository;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EmulatorAsync(CancellationToken token=default)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) {return Unauthorized();}
            var data = new PhysicalDevice();
            data.Devices = (await _repository.GetRegisteredDevices(new Guid (user.Id), default)).Select(x => 
            new NameGuidDevice() {Name=x.DeviceName, Id=x.Id  }).ToList();
            return View(data);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EmulatorAsync(PhysicalDevice device, CancellationToken token = default)
        {
            var dev = device;
            var start = dev.start;
            string site = $"{HttpContext.Request.Scheme.ToString()}://{Request.Host.Value}";

            var end = await PhysicalDeviceEmulator.PhysicalDeviceEmulator.DischargeApi(dev, site, token);
            var date = new ReportGet()
            {
                DeviceId = dev.DeviceId,
                From = start,
                To = end
            };


            return RedirectToAction("Report", "report", date);
        }
    }
}
