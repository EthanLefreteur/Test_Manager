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
    public class QuestionRedactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionRedactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionRedactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.questionRedactions.ToListAsync());
        }

        // GET: QuestionRedactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionRedaction = await _context.questionRedactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionRedaction == null)
            {
                return NotFound();
            }

            return View(questionRedaction);
        }

        // GET: QuestionRedactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionRedactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("reponse_correcte,Id,question")] QuestionRedaction questionRedaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionRedaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionRedaction);
        }

        // GET: QuestionRedactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionRedaction = await _context.questionRedactions.FindAsync(id);
            if (questionRedaction == null)
            {
                return NotFound();
            }
            return View(questionRedaction);
        }

        // POST: QuestionRedactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("reponse_correcte,Id,question")] QuestionRedaction questionRedaction)
        {
            if (id != questionRedaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionRedaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionRedactionExists(questionRedaction.Id))
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
            return View(questionRedaction);
        }

        // GET: QuestionRedactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionRedaction = await _context.questionRedactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionRedaction == null)
            {
                return NotFound();
            }

            return View(questionRedaction);
        }

        // POST: QuestionRedactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionRedaction = await _context.questionRedactions.FindAsync(id);
            if (questionRedaction != null)
            {
                _context.questionRedactions.Remove(questionRedaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionRedactionExists(int id)
        {
            return _context.questionRedactions.Any(e => e.Id == id);
        }
    }
}
