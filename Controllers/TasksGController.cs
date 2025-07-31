using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgressTrackerApp.Data;
using ProgressTrackerApp.Models;

namespace ProgressTrackerApp.Controllers
{
    public class TasksGController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksGController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TasksG
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaskG.Include(t => t.Goal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TasksG/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskG = await _context.TaskG
                .Include(t => t.Goal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskG == null)
            {
                return NotFound();
            }

            return View(taskG);
        }

        // GET: TasksG/Create
        public IActionResult Create()
        {
            ViewData["GoalId"] = new SelectList(_context.Goal, "Id", "Name");
            return View();
        }

        // POST: TasksG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Finish,Name,Priority,Status,FinishDate,GoalId")] TaskG taskG)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskG);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GoalId"] = new SelectList(_context.Goal, "Id", "Name", taskG.GoalId);
            return View(taskG);
        }

        // GET: TasksG/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskG = await _context.TaskG.FindAsync(id);
            if (taskG == null)
            {
                return NotFound();
            }
            ViewData["GoalId"] = new SelectList(_context.Goal, "Id", "Name", taskG.GoalId);
            return View(taskG);
        }

        // POST: TasksG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Finish,Name,Priority,Status,FinishDate,GoalId")] TaskG taskG)
        {
            if (id != taskG.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskG);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskGExists(taskG.Id))
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
            ViewData["GoalId"] = new SelectList(_context.Goal, "Id", "Name", taskG.GoalId);
            return View(taskG);
        }

        // GET: TasksG/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskG = await _context.TaskG
                .Include(t => t.Goal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskG == null)
            {
                return NotFound();
            }

            return View(taskG);
        }

        // POST: TasksG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskG = await _context.TaskG.FindAsync(id);
            if (taskG != null)
            {
                _context.TaskG.Remove(taskG);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskGExists(int id)
        {
            return _context.TaskG.Any(e => e.Id == id);
        }
    }
}
