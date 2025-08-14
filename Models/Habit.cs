namespace ProgressTrackerApp.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool Visibility { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; }
        public ICollection<HabitCompletion> Completions { get; set; } = new List<HabitCompletion>();

        public Habit()
        {
            
        }
    }
}
