using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BitcubeEval.Data;
using BitcubeEval.Models;

namespace BitcubeEval.Controllers
{
    public class DegreesController : Controller
    {
        private readonly CollegeContext _context;

        public DegreesController(CollegeContext context)
        {
            _context = context;
        }

        // GET: Degrees
        public async Task<IActionResult> Index()
        {
            var collegeContext = _context.Degrees.Include(d => d.Lecturer);
            return View(await collegeContext.ToListAsync());
        }

        // GET: Degrees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees
                .Include(d => d.Lecturer)
                .Include(d => d.Courses)
                .SingleOrDefaultAsync(m => m.DegreeID == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // GET: Degrees/Create
        public IActionResult Create()
        {
            ViewData["LecturerID"] = new SelectList(_context.Lecturers, "ID", "Email");
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreeID,DegreeName,DegreeDuration,LecturerID")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LecturerID"] = new SelectList(_context.Lecturers, "ID", "Email", degree.LecturerID);
            return View(degree);
        }

        // GET: Degrees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees.FindAsync(id);
            if (degree == null)
            {
                return NotFound();
            }
            ViewData["LecturerID"] = new SelectList(_context.Lecturers, "ID", "Email", degree.LecturerID);
            return View(degree);
        }

        // POST: Degrees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreeID,DegreeName,DegreeDuration,LecturerID")] Degree degree)
        {
            if (id != degree.DegreeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeExists(degree.DegreeID))
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
            ViewData["LecturerID"] = new SelectList(_context.Lecturers, "ID", "Email", degree.LecturerID);
            return View(degree);
        }

        // GET: Degrees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees
                .Include(d => d.Lecturer)
                .FirstOrDefaultAsync(m => m.DegreeID == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degree = await _context.Degrees.FindAsync(id);
            _context.Degrees.Remove(degree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreeExists(int id)
        {
            return _context.Degrees.Any(e => e.DegreeID == id);
        }
    }
}
