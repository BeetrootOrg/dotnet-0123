using BatteryMonitorApp.Domain.Repositories;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BatteryMonitorApp.WebApp.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepository _repository;

        public ReportController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, IRepository repository)
        {
            _logger = logger;
            _userManager = userManager;
            _repository = repository;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Report()
        {
            return View();
        }
    }
}
