using FastDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastDelivery.Infrastructure.Contexts;

public class ApplicationDbContext : DbContext
{
  public DbSet<Product>? Products { get; set; }

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder
      .LogTo(x => System.Console.WriteLine(x))
      .EnableSensitiveDataLogging();

    base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    base.OnModelCreating(modelBuilder);
  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
  {
    configurationBuilder.Properties<string>()
    .AreUnicode(false)
    .HaveColumnType("vachar(100)");
  }
}