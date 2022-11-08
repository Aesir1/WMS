using Microsoft.Data.Sqlite;
using Shouldly;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Exceptions;
using Xunit;

namespace IntegrationTest.Storage;

public class StorageEntities
{
    [Fact]
    public void StorageRelatedEntitiesAreCreated()
    {
        // Arrange
        var sqliteConnection = new SqliteConnection("DataSource=:memory:");
        sqliteConnection.Open();
        var dbContext = new DbContextTest(sqliteConnection);
        dbContext.Database.EnsureCreated();

        dbContext.Articles.Add(new Article("Laptop")
        {
            Containers = new List<Container>
            {
                new()
                {
                    ContainerId = 1111,
                    Qty = 5,
                    Address = new Address
                    {
                        CodeId = "STR1",
                        Description = "Wertarticle"
                    }
                }
            }
        });
        // Act
        dbContext.SaveChanges();
        var article = dbContext.Articles.ToList();
        var address = dbContext.Addresses.ToList();
        var container = dbContext.Containers.ToList();
        // Assert
        article.Count.ShouldBe(1);
        address.Count.ShouldBe(1);
        container.Count.ShouldBe(1);
    }

    [Fact]
    public void ArticleAndContainerAreDeleted()
    {
        // Arrange
        var sqliteConnection = new SqliteConnection("DataSource=:memory:");
        sqliteConnection.Open();
        var dbContext = new DbContextTest(sqliteConnection);
        dbContext.Database.EnsureCreated();

        dbContext.Articles.Add(new Article("Laptop")
        {
            Containers = new List<Container>
            {
                new()
                {
                    ContainerId = 1111,
                    Qty = 5,
                    Address = new Address
                    {
                        CodeId = "STR1",
                        Description = "Wertarticle"
                    }
                }
            }
        });
        dbContext.SaveChanges();
        // Act
        var articleToDelete = dbContext.Articles.First();
        dbContext.Articles.Remove(articleToDelete);
        dbContext.SaveChanges();
        var article = dbContext.Articles.ToList();
        var address = dbContext.Addresses.ToList();
        var container = dbContext.Containers.ToList();
        // Assert
        article.Count.ShouldBe(0);
        container.Count.ShouldBe(0);
    }

    [Fact]
    public void AddressAreNotDeletedAfterArticleDeleted()
    {
        // Arrange
        var sqliteConnection = new SqliteConnection("DataSource=:memory:");
        sqliteConnection.Open();
        var dbContext = new DbContextTest(sqliteConnection);
        dbContext.Database.EnsureCreated();

        dbContext.Articles.Add(new Article("Laptop")
        {
            Containers = new List<Container>
            {
                new()
                {
                    ContainerId = 1111,
                    Qty = 5,
                    Address = new Address
                    {
                        CodeId = "STR1",
                        Description = "Wertarticle"
                    }
                }
            }
        });
        dbContext.SaveChanges();
        // Act
        var articleToDelete = dbContext.Articles.First();
        dbContext.Articles.Remove(articleToDelete);
        dbContext.SaveChanges();
        var article = dbContext.Articles.ToList();
        var address = dbContext.Addresses.ToList();
        var container = dbContext.Containers.ToList();
        // Assert
        article.Count.ShouldBe(0);
        address.Count.ShouldBe(1);
        container.Count.ShouldBe(0);
    }

    [Fact]
    public void ContainerNotCreatedWhenQtyZero()
    {
        // Arrange
        var sqliteConnection = new SqliteConnection("DataSource=:memory:");
        sqliteConnection.Open();
        var dbContext = new DbContextTest(sqliteConnection);
        dbContext.Database.EnsureCreated();
        // Act & Assert
        Should.Throw<ContainerZeroException>(() => dbContext.Articles.Add(new Article("Laptop")
        {
            Containers = new List<Container>
            {
                new()
                {
                    ContainerId = 1111,
                    Qty = 0,
                    Address = new Address
                    {
                        CodeId = "STR1",
                        Description = "Wertarticle"
                    }
                }
            }
        }));
    }
}