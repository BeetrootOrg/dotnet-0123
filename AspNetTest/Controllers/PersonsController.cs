using AspNetTest.Database;
using AspNetTest.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetTest.Controllers
{
    public class PersonsController : Controller
    {
        private readonly PersonsContext _personsContext;

        public PersonsController(PersonsContext personsContext)
        {
            _personsContext = personsContext;
        }

        public async Task<IActionResult> Index(CancellationToken token = default)
        {
            Person[] persons = await _personsContext.Persons!.OrderBy(p => p.Id).ToArrayAsync(token);
            return View(persons);
        }

        public async Task<IActionResult> Details(int? id, CancellationToken token = default)
        {
            Person? person = await _personsContext.Persons!.FirstOrDefaultAsync(p => p.Id == id, token);
            return View(person);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Person person, CancellationToken token = default)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            _ = await _personsContext.AddAsync(person, token);
            _ = await _personsContext.SaveChangesAsync(token);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id, CancellationToken token = default)
        {
            Person? person = await _personsContext.Persons!.FirstOrDefaultAsync(p => p.Id == id, token);
            return View(person);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePerson(int id, CancellationToken token = default)
        {
            _ = _personsContext.Remove(new Person { Id = id });
            _ = await _personsContext.SaveChangesAsync(token);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id, CancellationToken token = default)
        {
            Person? person = await _personsContext.Persons!.FirstOrDefaultAsync(p => p.Id == id, token);
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Person person, CancellationToken token = default)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            _ = _personsContext.Update(person);
            _ = await _personsContext.SaveChangesAsync(token);

            return RedirectToAction(nameof(Index));
        }
    }
}