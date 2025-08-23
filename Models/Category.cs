using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ProgressTrackerApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Visibility { get; set; }
        public string? BackgroundColor { get; set; }
        public string? TextColor { get; set; }
        [ValidateNever]
        public string UserId { get; set; } = null!;
        [ValidateNever]
        public ApplicationUser User { get; set; }
        public ICollection<Habit> Habits { get; set; } = new List<Habit>();

        public Category()
        {
            
        }
    }
}
