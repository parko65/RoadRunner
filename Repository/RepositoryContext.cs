using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
    {
    }
    
    // DbSet properties for your entities
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Destination> Destinations { get; set; }
}
