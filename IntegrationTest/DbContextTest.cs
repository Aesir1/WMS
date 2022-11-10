using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WarehouseInfrastructure.Contexts;

namespace IntegrationTest;

public class DbContextTest
{
    public WarehouseDbContext ContextTest;

    public DbContextTest()
    {
        ContextTest =
            new WarehouseDbContext(
                new DbContextOptionsBuilder<WarehouseDbContext>().UseSqlite(OpenConnection()).Options);
        ContextTest.Database.EnsureCreated();
    }

    private static SqliteConnection OpenConnection()
    {
        SqliteConnection sqliteConnection = new("DataSource=:memory:");
        sqliteConnection.Open();
        return sqliteConnection;
    }
}