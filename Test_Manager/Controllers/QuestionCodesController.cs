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
    public class QuestionCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.questionCodes.ToListAsync());
        }

        // GET: QuestionCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionCode = await _context.questionCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionCode == null)
            {
                return NotFound();
            }

            return View(questionCode);
        }

        // GET: QuestionCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,question")] QuestionCode questionCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionCode);
        }

        // GET: QuestionCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionCode = await _context.questionCodes.FindAsync(id);
            if (questionCode == null)
            {
                return NotFound();
            }
            return View(questionCode);
        }

        // POST: QuestionCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,question")] QuestionCode questionCode)
        {
            if (id != questionCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionCodeExists(questionCode.Id))
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
            return View(questionCode);
        }

        // GET: QuestionCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionCode = await _context.questionCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionCode == null)
            {
                return NotFound();
            }

            return View(questionCode);
        }

        // POST: QuestionCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionCode = await _context.questionCodes.FindAsync(id);
            if (questionCode != null)
            {
                _context.questionCodes.Remove(questionCode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionCodeExists(int id)
        {
            return _context.questionCodes.Any(e => e.Id == id);
        }
    }
}
