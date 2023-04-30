using System.Threading;
using System.Threading.Tasks;

using Marketplace.Models;
using Marketplace.ProductContexts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _productContext;
        public ProductsController(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        {
            return View(await _productContext.Products.ToArrayAsync(cancellationToken));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                _ = await _productContext.Products.AddAsync(product, cancellationToken);
                _ = await _productContext.SaveChangesAsync(cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken = default)
        {
            var product = _productContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public async Task<IActionResult> Edit([FromRoute]int id, CancellationToken cancellationToken = default)
        {
            var Product = await _productContext.Products.FindAsync(id, cancellationToken);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                _ = _productContext.Products.Update(product);
                _ = await _productContext.SaveChangesAsync(cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var product = _productContext.Products.FindAsync(id, cancellationToken);
            if (product == null)
            {
                return NotFound();
            }
            return View(await product);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            { 
                _ = _productContext.Products.Remove(new Product { Id = id });
                _ = await _productContext.SaveChangesAsync(cancellationToken);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}