using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}