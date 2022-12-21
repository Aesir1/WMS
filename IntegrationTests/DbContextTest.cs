using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WarehouseInfrastructure.Contexts;

namespace IntegrationTests;

public sealed class DbContextTest : WarehouseDbContext
{
    public DbContextTest() : base(new DbContextOptionsBuilder<WarehouseDbContext>().UseSqlite(OpenConnection()).Options)
    {
        Database.EnsureCreated();
    }

    private static SqliteConnection OpenConnection()
    {
        SqliteConnection sqliteConnection = new("DataSource=:memory:");
        sqliteConnection.Open();
        return sqliteConnection;
    }
}