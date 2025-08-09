using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgressTrackerApp.Models;

namespace ProgressTrackerApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProgressTrackerApp.Models.Goal> Goal { get; set; } = default!;
        public DbSet<ProgressTrackerApp.Models.TaskG> TaskG { get; set; } = default!;
        public DbSet<ProgressTrackerApp.Models.Category> Categroy { get; set; } = default!;
        public DbSet<ProgressTrackerApp.Models.Habit> Habit { get; set; } = default!;
        public DbSet<ProgressTrackerApp.Models.HabitCompletion> HabitCompletion { get; set; } = default!;
    }
}
