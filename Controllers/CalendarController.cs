using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index()
        {
            ViewData["Habits"] = JSONListHelper.GetHabitListJSONString( 
                _context.HabitCompletion
                .Include(h => h.Habit)
                .ToList() 
                );
            return View();
        }
    }
}
