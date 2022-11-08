using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WarehouseInfrastructure.Contexts;

namespace IntegrationTest;

public class DbContextTest : WarehouseDbContext
{
    public DbContextTest(SqliteConnection sqliteConnection) : base(new DbContextOptionsBuilder<WarehouseDbContext>()
        .UseSqlite(sqliteConnection).Options)
    {
    }
}