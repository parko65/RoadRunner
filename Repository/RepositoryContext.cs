using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RecipeHotBin>()
            .HasKey(rh => new { rh.RecipeId, rh.HotBinId });
    }
    
    // DbSet properties for your entities
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Aggregate> Aggregates { get; set; }
    public DbSet<HotBin> HotBins { get; set; }
    public DbSet<RecipeHotBin> RecipeHotBins { get; set; }
}
