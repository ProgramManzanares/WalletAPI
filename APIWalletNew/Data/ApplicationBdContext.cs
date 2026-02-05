using APIWalletNew.Models;
using Microsoft.EntityFrameworkCore;

namespace APIWalletNew.Data;

public class ApplicationBdContext(DbContextOptions<ApplicationBdContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await base.SaveChangesAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationBdContext).Assembly);
    }
}