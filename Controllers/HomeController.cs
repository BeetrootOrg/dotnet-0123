using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebContext _context;

        public HomeController(ILogger<HomeController> logger, WebContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            await _context.GoodsImage.LoadAsync();
            var mod = _context.Categories.ToList();
            return View(mod);
        }

        public async Task<IActionResult> Goods(int Id)
        {
           // await _context.GoodsImage.LoadAsync();
            List<Good> mod = _context.Goods.Where(x => x.CategoryId == Id).Include(x => x.Brend).Include(x => x.GoodImage).ToList();
            return View(mod);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<string> InitDb()
        {
            await _context.Initial();
            return $"{_context.Goods.Count()} Goods in DB";
        }

        public async Task<string> CheckIm()
        {
            int i = 0;
            foreach(var g in _context.Goods)
            {
                var im=_context.GoodsImage.Skip(i).First();
                g.GoodImage = im;
                i++;
                if (i > 3) i = 0;
            }
            await _context.SaveChangesAsync();
            return $"{_context.Goods.Count()} Goods in DB";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}