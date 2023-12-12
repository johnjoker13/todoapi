using System.Reflection;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(
                Assembly
                    .GetExecutingAssembly()
            );
    }
}