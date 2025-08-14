using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace ProgressTrackerApp.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public double Progress { get; set; } = 0.0;
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; }
        public ICollection<TaskG> Tasks { get; set; } = new List<TaskG>();

        public Goal()
        {
            
        }
    }
}
