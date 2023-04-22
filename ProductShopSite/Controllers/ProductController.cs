using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProductShopSite.Models;

namespace ProductShopSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsContext _context;

        public ProductController(ProductsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        {
            return View(await _context.Products.ToArrayAsync(cancellationToken));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product , CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync(cancellationToken);
                return Redirect(nameof(Index));
            }
            
            return View(product);
        }
    }
}