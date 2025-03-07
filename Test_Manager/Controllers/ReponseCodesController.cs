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
    public class ReponseCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReponseCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReponseCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.reponseCodes.ToListAsync());
        }

        // GET: ReponseCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponseCode = await _context.reponseCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reponseCode == null)
            {
                return NotFound();
            }

            return View(reponseCode);
        }

        // GET: ReponseCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReponseCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("reponse_candidat,Id")] ReponseCode reponseCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reponseCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reponseCode);
        }

        // GET: ReponseCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponseCode = await _context.reponseCodes.FindAsync(id);
            if (reponseCode == null)
            {
                return NotFound();
            }
            return View(reponseCode);
        }

        // POST: ReponseCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("reponse_candidat,Id")] ReponseCode reponseCode)
        {
            if (id != reponseCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reponseCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReponseCodeExists(reponseCode.Id))
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
            return View(reponseCode);
        }

        // GET: ReponseCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponseCode = await _context.reponseCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reponseCode == null)
            {
                return NotFound();
            }

            return View(reponseCode);
        }

        // POST: ReponseCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reponseCode = await _context.reponseCodes.FindAsync(id);
            if (reponseCode != null)
            {
                _context.reponseCodes.Remove(reponseCode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReponseCodeExists(int id)
        {
            return _context.reponseCodes.Any(e => e.Id == id);
        }
    }
}
