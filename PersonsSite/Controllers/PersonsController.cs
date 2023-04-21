using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonsSite.Models;

namespace PersonsSite.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonsContext _context;

        public PersonController(PersonsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        {
            return View(await _context.Persons.ToArrayAsync(cancellationToken));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Person person, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                _ = await _context.Persons.AddAsync(person, cancellationToken);
                _ = await _context.SaveChangesAsync(cancellationToken);
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }
    }
}