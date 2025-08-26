using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProgressTrackerApp.Data;
using ProgressTrackerApp.Helpers;
using ProgressTrackerApp.Models;

namespace ProgressTrackerApp.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CalendarController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index(string redirectionDate)
        {
            // Habits to show
            ViewData["Habits"] = JSONListHelper.GetHabitListJSONString( 
                _context.HabitCompletion
                .Include(h => h.Habit)
                .Where(h => h.Habit.Visibility == true)
                .ToList() 
                );

            // Categories to show
            ViewData["Categories"] = JSONListHelper.GetCategoriesListJSONString(
                _context.Category
                .ToList()
                );

            // Current page date of the calendar
            ViewData["RedirectionDate"] = string.IsNullOrEmpty(redirectionDate) ? DateTime.Today.ToString("yyyy-MM-dd") : redirectionDate;
            return View();
        }

        // POST: HabitCompletions/Create
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] HabitCompletion habitCompletion)
        {  
            var updatedHabitCompletion = await _context.HabitCompletion.FindAsync(habitCompletion.Id);
            if (updatedHabitCompletion == null)
            {
                return NotFound();
            }

            try
            {
                updatedHabitCompletion.Date = habitCompletion.Date;
                _context.Update(updatedHabitCompletion);
                await _context.SaveChangesAsync();

                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Błąd serwera: {ex.Message}");
            }
        }
    }
}
