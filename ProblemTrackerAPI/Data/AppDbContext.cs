using ProblemTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ProblemTrackerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Problem> Problems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
