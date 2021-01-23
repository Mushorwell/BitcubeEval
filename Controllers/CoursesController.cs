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
    public class CoursesController : Controller
    {
        private readonly CollegeContext _context;

        public CoursesController(CollegeContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var collegeContext = _context.Courses.Include(c => c.Degree);
            return View(await collegeContext.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Degree)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }
            int degreeID = course.DegreeID;
            var degreeCourses = await GetAllDegreeCoursesAsync(degreeID);
            ViewBag.degreeCourses = degreeCourses.Courses;
            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "DegreeID");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,DegreeID,CourseName,CourseDuration")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "DegreeID", course.DegreeID);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "DegreeID", course.DegreeID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("CourseID,DegreeID,CourseName,CourseDuration")] Course course)
        {
            if (id != course.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseID))
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
            ViewData["DegreeID"] = new SelectList(_context.Degrees, "DegreeID", "DegreeID", course.DegreeID);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Degree)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int? id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }

        private async Task<Degree> GetAllDegreeCoursesAsync(int id)
        {
            int degreeID = id;
            var degree = await _context.Degrees
                .Include(d => d.Courses)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.DegreeID == degreeID);
            try
            {
                return degree;
            }
            catch (Exception e)
            {
                throw /*e*/;
            }            
        }
    }
}
