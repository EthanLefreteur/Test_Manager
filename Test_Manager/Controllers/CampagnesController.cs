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
    public class CampagnesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampagnesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Campagnes
        public async Task<IActionResult> Index()
        {
            return View(await _context.campagnes.ToListAsync());
        }

        // GET: Campagnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campagne = await _context.campagnes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campagne == null)
            {
                return NotFound();
            }

            return View(campagne);
        }

        // GET: Campagnes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campagnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name")] Campagne campagne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campagne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campagne);
        }

        // GET: Campagnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campagne = await _context.campagnes.FindAsync(id);
            if (campagne == null)
            {
                return NotFound();
            }
            return View(campagne);
        }

        // POST: Campagnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name")] Campagne campagne)
        {
            if (id != campagne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campagne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampagneExists(campagne.Id))
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
            return View(campagne);
        }

        // GET: Campagnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campagne = await _context.campagnes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campagne == null)
            {
                return NotFound();
            }

            return View(campagne);
        }

        // POST: Campagnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campagne = await _context.campagnes.FindAsync(id);
            if (campagne != null)
            {
                _context.campagnes.Remove(campagne);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampagneExists(int id)
        {
            return _context.campagnes.Any(e => e.Id == id);
        }
    }
}
