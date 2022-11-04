using Microsoft.Data.Sqlite;
using Shouldly;
using WarehouseCore.Entities.Product;
using Xunit;

namespace IntegrationTest.Storage;

public class ArticleTest
{   [Fact]
    public void ArticleCreated()
    {
        // Arrange
        SqliteConnection sqliteConnection = new SqliteConnection("DataSource=:memory:");
        sqliteConnection.Open();
        DbContextTest dbContext = new DbContextTest(sqliteConnection);
        dbContext.Database.EnsureCreated();
        
        dbContext.Articles.Add(new Article("first Article"));
        // Act
        dbContext.SaveChanges();
        var article = dbContext.Articles.ToList();
        // Assert
        article.Count.ShouldBe(1);

    }
}