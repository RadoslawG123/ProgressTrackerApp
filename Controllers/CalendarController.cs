using Microsoft.AspNetCore.Mvc;

namespace ProgressTrackerApp.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
