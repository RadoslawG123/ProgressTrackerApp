using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ProgressTrackerApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
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
