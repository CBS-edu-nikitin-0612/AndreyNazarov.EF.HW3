// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

internal class Context : DbContext
{
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Appartment> Appartments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=HW3.Task2.Model;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AppartemntConfiguring());
        modelBuilder.ApplyConfiguration(new BuildingConfiguring());
    }
}