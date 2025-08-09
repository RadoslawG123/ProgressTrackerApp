namespace ProgressTrackerApp.Models
{
    public class HabitCompletion
    {
        public int Id { get; set; }
        public int HabitId { get; set; }
        public Habit Habit { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime Date { get; set; }

        public HabitCompletion()
        {
            
        }
    }
}
