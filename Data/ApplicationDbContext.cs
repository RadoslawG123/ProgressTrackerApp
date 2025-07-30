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
    }
}
