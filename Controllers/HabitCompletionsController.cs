using Microsoft.AspNetCore.Mvc;

namespace ProgressTrackerApp.Controllers
{
    public class HabitCompletionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
