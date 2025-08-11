namespace ProgressTrackerApp.Models
{
    public class CalendarEventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Color { get; set; } = null!;
        public string Type { get; set; } = null!;

        public CalendarEventViewModel()
        {
            
        }
    }
}
