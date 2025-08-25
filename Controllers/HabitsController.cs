using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgressTrackerApp.Data;
using ProgressTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressTrackerApp.Controllers
{
    public class HabitsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HabitsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Habits
        public async Task<IActionResult> Index(string sortOrder)
        {
            // Find User
            var user = await _userManager.GetUserAsync(User);

            var habits = await _context.Habit
                .Where(h => h.UserId == user.Id)
                .Include(h => h.Category)
                .OrderBy(h => h.Name)
                .ToListAsync();

            // Sort
            switch (sortOrder)
            {
                case "name":
                    habits = habits.OrderBy(h => h.Name).ToList();
                    break;
                case "description":
                    habits = habits.OrderBy(h => h.Description).ToList();
                    break;
                case "isActive":
                    habits = habits.OrderBy(h => h.IsActive).ToList();
                    break;
                case "visibility":
                    habits = habits.OrderBy(h => h.Visibility).ToList();
                    break;
                case "color":
                    habits = habits.OrderBy(h => h.BackgroundColor).ToList();
                    break;
                case "category":
                    // Sorting with null categories
                    List<Habit> habitsWithCategory = new List<Habit>();
                    List<Habit> habitsWithoutCategory = new List<Habit>();

                    foreach (var habit in habits)
                    {
                        if (habit.Category != null) {
                            habitsWithCategory.Add(habit);
                        }
                        else
                        {
                            habitsWithoutCategory.Add(habit);
                        }
                    }
                    habits = habitsWithCategory.OrderBy(h => h.Category.Name).ToList();
                    foreach (var habit in habitsWithoutCategory)
                    {
                        habits.Add(habit);
                    }

                    break;
            }

            return View(habits);
        }

        // POST: Habits/ToggleVisibility
        public async Task<IActionResult> ToggleVisibility(int id)
        {
            var habit = await _context.Habit.FindAsync(id);

            if (habit == null)
            {
                return NotFound();
            }

            habit.Visibility = !habit.Visibility;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Habits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habit = await _context.Habit
                .Include(h => h.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habit == null)
            {
                return NotFound();
            }

            return View(habit);
        }

        // GET: Habits/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

        // POST: Habits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsActive,Visibility,BackgroundColor,TextColor,CategoryId")] Habit habit)
        {
            // Find User
            var user = await _userManager.GetUserAsync(User);
            habit.UserId = user.Id;

            if (ModelState.IsValid)
            {
                _context.Add(habit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", habit.CategoryId);
            return View(habit);
        }

        // GET: Habits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habit = await _context.Habit.FindAsync(id);
            if (habit == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", habit.CategoryId);
            return View(habit);
        }

        // POST: Habits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,IsActive,Visibility,CategoryId,UserId")] Habit habit)
        {
            if (id != habit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitExists(habit.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", habit.CategoryId);
            return View(habit);
        }

        // GET: Habits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habit = await _context.Habit
                .Include(h => h.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habit == null)
            {
                return NotFound();
            }

            return View(habit);
        }

        // POST: Habits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habit = await _context.Habit.FindAsync(id);
            if (habit != null)
            {
                _context.Habit.Remove(habit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitExists(int id)
        {
            return _context.Habit.Any(e => e.Id == id);
        }
    }
}
