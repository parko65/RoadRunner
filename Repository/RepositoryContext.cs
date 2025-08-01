using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

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

        modelBuilder.Entity<RecipeBitumenTank>()
            .HasKey(rb => new { rb.RecipeId, rb.BitumenTankId });

        modelBuilder.ApplyConfiguration(new DestinationConfiguration());
    }

    // DbSet properties for your entities
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Aggregate> Aggregates { get; set; }
    public DbSet<HotBin> HotBins { get; set; }
    public DbSet<RecipeHotBin> RecipeHotBins { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<RecipeBitumenTank> RecipeBitumenTanks { get; set; }
    public DbSet<BitumenTank> BitumenTanks { get; set; }
    public DbSet<Bitumen> Bitumens { get; set; }
}