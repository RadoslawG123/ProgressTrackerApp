using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ProgressTrackerApp.Models
{
    public class HabitCompletion
    {
        public int Id { get; set; }
        public int HabitId { get; set; }
        public Habit? Habit { get; set; } = null!;
        [ValidateNever]
        public string UserId { get; set; } = null!;
        [ValidateNever]
        public ApplicationUser User { get; set; }
        public DateTime Date { get; set; }

        public HabitCompletion()
        {
            
        }
    }
}
