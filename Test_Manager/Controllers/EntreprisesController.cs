using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test_Manager.Data;
using Test_Manager.Models;

namespace Test_Manager.Controllers
{
    public class EntreprisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntreprisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entreprises
        public async Task<IActionResult> Index()
        {
            return View(await _context.entreprises.ToListAsync());
        }

        // GET: Entreprises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entreprise = await _context.entreprises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entreprise == null)
            {
                return NotFound();
            }

            return View(entreprise);
        }

        // GET: Entreprises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entreprises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nom")] Entreprise entreprise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entreprise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entreprise);
        }

        // GET: Entreprises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entreprise = await _context.entreprises.FindAsync(id);
            if (entreprise == null)
            {
                return NotFound();
            }
            return View(entreprise);
        }

        // POST: Entreprises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nom")] Entreprise entreprise)
        {
            if (id != entreprise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entreprise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrepriseExists(entreprise.Id))
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
            return View(entreprise);
        }

        // GET: Entreprises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entreprise = await _context.entreprises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entreprise == null)
            {
                return NotFound();
            }

            return View(entreprise);
        }

        // POST: Entreprises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entreprise = await _context.entreprises.FindAsync(id);
            if (entreprise != null)
            {
                _context.entreprises.Remove(entreprise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrepriseExists(int id)
        {
            return _context.entreprises.Any(e => e.Id == id);
        }
    }
}
