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
    public class BrendsController : Controller
    {
        private readonly WebContext _context;

        public BrendsController(WebContext context)
        {
            _context = context;
        }

        // GET: Brends
        public async Task<IActionResult> Index()
        {
            return _context.Brends != null ?
                        View(await _context.Brends.ToListAsync()) :
                        Problem("Entity set 'WebContext.Brends'  is null.");
        }

        // GET: Brends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brends == null)
            {
                return NotFound();
            }

            var brend = await _context.Brends
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brend == null)
            {
                return NotFound();
            }

            return View(brend);
        }

        // GET: Brends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CreateDateTime")] Brend brend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brend);
        }

        // GET: Brends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brends == null)
            {
                return NotFound();
            }

            var brend = await _context.Brends.FindAsync(id);
            if (brend == null)
            {
                return NotFound();
            }
            return View(brend);
        }

        // POST: Brends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreateDateTime")] Brend brend)
        {
            if (id != brend.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrendExists(brend.Id))
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
            return View(brend);
        }

        // GET: Brends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brends == null)
            {
                return NotFound();
            }

            var brend = await _context.Brends
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brend == null)
            {
                return NotFound();
            }

            return View(brend);
        }

        // POST: Brends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brends == null)
            {
                return Problem("Entity set 'WebContext.Brends'  is null.");
            }
            var brend = await _context.Brends.FindAsync(id);
            if (brend != null)
            {
                _context.Brends.Remove(brend);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrendExists(int id)
        {
            return (_context.Brends?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
