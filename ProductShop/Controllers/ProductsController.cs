using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductShop.Models;

namespace ProductShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsContext _context;

        public ProductsController(ProductsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        {
            return View(await _context.Products.ToArrayAsync(cancellationToken));
        }
        public async Task<IActionResult> Details([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            return product == null ? NotFound() : View(product);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Product product, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                _ = await _context.Products.AddAsync(product, cancellationToken);
                _ = await _context.SaveChangesAsync(cancellationToken);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        public async Task<IActionResult> Edit([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            return product == null ? NotFound() : View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] Product product, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                product.Id = id;
                _ = _context.Products.Update(product);
                _ = await _context.SaveChangesAsync(cancellationToken);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            _ = _context.Products.Remove(new Product { Id = id });
            _ = await _context.SaveChangesAsync(cancellationToken);

            return RedirectToAction(nameof(Index));
        }
    }
}