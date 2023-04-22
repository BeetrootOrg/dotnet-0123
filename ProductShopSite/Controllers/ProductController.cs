using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}