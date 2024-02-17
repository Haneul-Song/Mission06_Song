using Microsoft.EntityFrameworkCore;

namespace Mission06_Song.Models
{
    public class MovieAddedContext : DbContext
    {
        public MovieAddedContext(DbContextOptions<MovieAddedContext> options) : base (options) 
        {
        }

        public DbSet<AddMovie> MoviesAdded { get; set; }
    }
}
 