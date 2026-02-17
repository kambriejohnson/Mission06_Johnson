using Microsoft.EntityFrameworkCore;

namespace Mission06_Johnson.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; } // Added to match Categories table
    }
}