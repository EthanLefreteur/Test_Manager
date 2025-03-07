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
    public class ResultatCampagnesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResultatCampagnesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResultatCampagnes
        public async Task<IActionResult> Index()
        {
            return View(await _context.resultatCampagnes.ToListAsync());
        }

        // GET: ResultatCampagnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultatCampagne = await _context.resultatCampagnes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultatCampagne == null)
            {
                return NotFound();
            }

            return View(resultatCampagne);
        }

        // GET: ResultatCampagnes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResultatCampagnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ResultatCampagne resultatCampagne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultatCampagne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resultatCampagne);
        }

        // GET: ResultatCampagnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultatCampagne = await _context.resultatCampagnes.FindAsync(id);
            if (resultatCampagne == null)
            {
                return NotFound();
            }
            return View(resultatCampagne);
        }

        // POST: ResultatCampagnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ResultatCampagne resultatCampagne)
        {
            if (id != resultatCampagne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultatCampagne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultatCampagneExists(resultatCampagne.Id))
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
            return View(resultatCampagne);
        }

        // GET: ResultatCampagnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultatCampagne = await _context.resultatCampagnes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultatCampagne == null)
            {
                return NotFound();
            }

            return View(resultatCampagne);
        }

        // POST: ResultatCampagnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultatCampagne = await _context.resultatCampagnes.FindAsync(id);
            if (resultatCampagne != null)
            {
                _context.resultatCampagnes.Remove(resultatCampagne);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultatCampagneExists(int id)
        {
            return _context.resultatCampagnes.Any(e => e.Id == id);
        }
    }
}
