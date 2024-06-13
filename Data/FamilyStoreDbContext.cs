using FamilyStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyStore.Data;

public class FamilyStoreDbContext:DbContext
{
    public FamilyStoreDbContext(DbContextOptions<FamilyStoreDbContext> options):base(options)
    {
        
    }
    
    public DbSet<Company> Companies { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Subscription> Subscriptions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(p => p.RowVersion)
            .IsRowVersion()
            .IsConcurrencyToken();
    }
}