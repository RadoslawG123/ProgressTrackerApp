using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ProgressTrackerApp.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool Visibility { get; set; }
        public string? BackgroundColor { get; set; }
        public string? TextColor { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; } = null!;
        [ValidateNever]
        public string UserId { get; set; } = null!;
        [ValidateNever]
        public ApplicationUser User { get; set; }
        public ICollection<HabitCompletion> Completions { get; set; } = new List<HabitCompletion>();

        public Habit()
        {
            
        }
    }
}
