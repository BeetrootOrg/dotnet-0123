using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class GoodImagesController : Controller
    {
        private readonly WebContext _context;

        public GoodImagesController(WebContext context)
        {
            _context = context;
        }

        // GET: GoodImages
        public async Task<IActionResult> Index()
        {
            return _context.GoodsImage != null ?
                        View(await _context.GoodsImage.ToListAsync()) :
                        Problem("Entity set 'WebContext.GoodsImage'  is null.");
        }

        // GET: GoodImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GoodsImage == null)
            {
                return NotFound();
            }

            var goodImage = await _context.GoodsImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodImage == null)
            {
                return NotFound();
            }

            return View(goodImage);
        }

        // GET: GoodImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoodImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Path,CreateDateTime")] GoodImage goodImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goodImage);
        }

        // GET: GoodImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GoodsImage == null)
            {
                return NotFound();
            }

            var goodImage = await _context.GoodsImage.FindAsync(id);
            if (goodImage == null)
            {
                return NotFound();
            }
            return View(goodImage);
        }

        // POST: GoodImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Path,CreateDateTime")] GoodImage goodImage)
        {
            if (id != goodImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodImageExists(goodImage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(goodImage);
        }

        // GET: GoodImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GoodsImage == null)
            {
                return NotFound();
            }

            var goodImage = await _context.GoodsImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodImage == null)
            {
                return NotFound();
            }

            return View(goodImage);
        }

        // POST: GoodImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GoodsImage == null)
            {
                return Problem("Entity set 'WebContext.GoodsImage'  is null.");
            }
            var goodImage = await _context.GoodsImage.FindAsync(id);
            if (goodImage != null)
            {
                _context.GoodsImage.Remove(goodImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodImageExists(int id)
        {
            return (_context.GoodsImage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
