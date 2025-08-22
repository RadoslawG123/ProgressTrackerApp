using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public CalendarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string redirectionDate)
        {
            // Habits to show
            ViewData["Habits"] = JSONListHelper.GetHabitListJSONString( 
                _context.HabitCompletion
                .Include(h => h.Habit)
                .ToList() 
                );

            // Current page date of the calendar
            ViewData["RedirectionDate"] = string.IsNullOrEmpty(redirectionDate) ? DateTime.Today.ToString("yyyy-MM-dd") : redirectionDate;
            return View();
        }
    }
}
