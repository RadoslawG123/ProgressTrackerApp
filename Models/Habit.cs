using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ProgressTrackerApp.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool Visibility { get; set; }
        [Display(Name = "Background Color")]
        public string? BackgroundColor { get; set; }
        [Display(Name = "Text Color")]
        public string? TextColor { get; set; }
        [Display(Name = "Category")]
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
