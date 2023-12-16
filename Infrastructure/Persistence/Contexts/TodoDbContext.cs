using System.Reflection;
using Domain.Entites;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class TodoDbContext : DbContext
{

    public TodoDbContext() : base() { }

    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(
                Assembly
                    .GetExecutingAssembly()
            );

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}