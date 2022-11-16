using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CastsController : Controller
    {
        private readonly TestDbContext _context;

        public CastsController(TestDbContext context)
        {
            _context = context;
        }

        // GET: Casts
        public async Task<IActionResult> Index()
        {
              return View(await _context.Casts.ToListAsync());
        }

        // GET: Casts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Casts == null)
            {
                return NotFound();
            }

            var cast = await _context.Casts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cast == null)
            {
                return NotFound();
            }

            return View(cast);
        }

        // GET: Casts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Casts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShowId,ShowName,JobTitle,PersonId,PersonName")] Cast cast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cast);
        }

        // GET: Casts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Casts == null)
            {
                return NotFound();
            }

            var cast = await _context.Casts.FindAsync(id);
            if (cast == null)
            {
                return NotFound();
            }
            return View(cast);
        }

        // POST: Casts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowId,ShowName,JobTitle,PersonId,PersonName")] Cast cast)
        {
            if (id != cast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CastExists(cast.Id))
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
            return View(cast);
        }

        // GET: Casts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Casts == null)
            {
                return NotFound();
            }

            var cast = await _context.Casts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cast == null)
            {
                return NotFound();
            }

            return View(cast);
        }

        // POST: Casts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Casts == null)
            {
                return Problem("Entity set 'TestDbContext.Casts'  is null.");
            }
            var cast = await _context.Casts.FindAsync(id);
            if (cast != null)
            {
                _context.Casts.Remove(cast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CastExists(int id)
        {
          return _context.Casts.Any(e => e.Id == id);
        }
    }
}
