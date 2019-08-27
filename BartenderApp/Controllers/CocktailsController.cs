using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BartenderApp.Models
{
    public class CocktailsController : Controller
    {
        private readonly BartenderAppContext _context;

        public CocktailsController(BartenderAppContext context)
        {
            _context = context;
        }

        // GET: Cocktails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cocktails.ToListAsync());
        }

        // GET: Cocktails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocktails = await _context.Cocktails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cocktails == null)
            {
                return NotFound();
            }

            return View(cocktails);
        }

        // GET: Cocktails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cocktails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CocktailName,CocktailPrice")] Cocktails cocktails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cocktails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cocktails);
        }

        // GET: Cocktails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocktails = await _context.Cocktails.FindAsync(id);
            if (cocktails == null)
            {
                return NotFound();
            }
            return View(cocktails);
        }

        // POST: Cocktails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CocktailName,CocktailPrice")] Cocktails cocktails)
        {
            if (id != cocktails.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cocktails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocktailsExists(cocktails.ID))
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
            return View(cocktails);
        }

        // GET: Cocktails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocktails = await _context.Cocktails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cocktails == null)
            {
                return NotFound();
            }

            return View(cocktails);
        }

        // POST: Cocktails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cocktails = await _context.Cocktails.FindAsync(id);
            _context.Cocktails.Remove(cocktails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CocktailsExists(int id)
        {
            return _context.Cocktails.Any(e => e.ID == id);
        }
    }
}
