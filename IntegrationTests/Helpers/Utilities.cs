using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests;

public static class Utilities
{
    public static void InitializeDbForTests(TodoDbContext db)
    {
        db.Database.EnsureCreated();
        db.SaveChanges();
    }

    public static void ReinitializeDbForTests(TodoDbContext db)
    {
        db.Database.EnsureDeleted();
        InitializeDbForTests(db);
    }

}