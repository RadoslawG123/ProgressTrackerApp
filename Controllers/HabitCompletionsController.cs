using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgressTrackerApp.Data;
using ProgressTrackerApp.Models;

public class HabitCompletionsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public HabitCompletionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: HabitCompletions
    public async Task<IActionResult> Index()
    {
        // Find User
        var user = await _userManager.GetUserAsync(User);

        var completions = await _context.HabitCompletion
            .Where(h => h.UserId == user.Id)
            .Include(h => h.Habit)
            .Include(h => h.User)
            .ToListAsync();

        return View(completions);
    }

    // GET: HabitCompletions/Create
    [HttpGet]
    public IActionResult Create(string date)
    {
        ViewData["HabitId"] = new SelectList(_context.Habit, "Id", "Name");
        ViewData["HabitDate"] = DateTime.Parse(date).ToString("yyyy-MM-dd");
        return View();
    }

    // POST: HabitCompletions/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("HabitId,Date")] HabitCompletion habitCompletion)
    {
        // Find User
        var user = await _userManager.GetUserAsync(User);
        habitCompletion.UserId = user.Id;



        habitCompletion.Habit = _context.Habit.FirstOrDefault(h => h.Id == habitCompletion.HabitId);

        if (ModelState.IsValid)
        {
            _context.Add(habitCompletion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["HabitId"] = new SelectList(_context.Habit, "Id", "Name", habitCompletion.HabitId);
        return View(habitCompletion);
    }
}
