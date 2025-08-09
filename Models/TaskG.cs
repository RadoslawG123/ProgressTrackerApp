using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressTrackerApp.Models
{
    public class TaskG
    {
        public int Id { get; set; }
        public bool Finish { get; set; } = false;
        public required string Name { get; set; }
        public string Priority { get; set; } = "Low";
        public string Status { get; set; } = "Not started";
        public DateTime? FinishDate { get; set; }
        public string UserId { get; set; } = null!;
        public int GoalId { get; set; }
        public Goal? Goal { get; set; } = null!;

        public TaskG()
        {
            
        }
    }
}
