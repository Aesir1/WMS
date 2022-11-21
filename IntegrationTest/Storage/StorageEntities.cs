using Shouldly;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Exceptions;
using WarehouseInfrastructure.Contexts;
using Xunit;

namespace IntegrationTest.Storage;

public class StorageEntities
{
    [Fact]
    public void StorageRelatedEntitiesAreCreated()
    {
        // Arrange
        WarehouseDbContext dbContext = new DbContextTest();

        dbContext.Articles.Add(new Article(1,"Laptop")
        {
            Containers = new List<Container>
            {
                new(5)
                {
                    Address = new Address("STRA1")
                    {
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
        WarehouseDbContext dbContext = new DbContextTest();
        dbContext.Articles.Add(new Article(1, "Laptop")
        {
            Containers = new List<Container>
            {
                new(5)
                {
                    Address = new Address("STRA1")
                    {
                        Description = "Wertarticle"
                    }
                }
            }
        });
        dbContext.SaveChanges();
        // Act
        var containerToDelete = dbContext.Containers.First();
        dbContext.Containers.Remove(containerToDelete);
        var articleToDelete = dbContext.Articles.First();
        dbContext.Articles.Remove(articleToDelete);
        dbContext.SaveChanges();
        var article = dbContext.Articles.ToList();
        var container = dbContext.Containers.ToList();
        // Assert
        article.Count.ShouldBe(0);
        container.Count.ShouldBe(0);
    }
    
    [Fact]
    public void AddressPersistenceAfterArticleAndContainerDeleted()
    {
        // Arrange
        WarehouseDbContext dbContext = new DbContextTest();

        dbContext.Articles.Add(new Article(1,"Laptop")
        {
            Containers = new List<Container>
            {
                new(5)
                {
                    Address = new Address("STRA1")
                    {
                        Description = "Wertarticle"
                    }
                }
            }
        });
        dbContext.SaveChanges();
        // Act
        var containerToDelete = dbContext.Containers.First();
        dbContext.Containers.Remove(containerToDelete);
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
    public void ContainerDeleted()
    {
        // Arrange
        WarehouseDbContext dbContext = new DbContextTest();

        dbContext.Articles.Add(new Article(1,"Laptop")
        {
            Containers = new List<Container>
            {
                new(5)
                {
                    Address = new Address("STRA1")
                    {
                        Description = "Wertarticle"
                    }
                }
            }
        });
        dbContext.SaveChanges();
        // Act
        var containerToDelete = dbContext.Containers.First();
        dbContext.Containers.Remove(containerToDelete);
        dbContext.SaveChanges();
        var article = dbContext.Articles.ToList();
        var address = dbContext.Addresses.ToList();
        var container = dbContext.Containers.ToList();
        // Assert
        article.Count.ShouldBe(1);
        address.Count.ShouldBe(1);
        container.Count.ShouldBe(0);
    }
    [Fact]
    public void ContainerNotCreatedWhenQtyZero()
    {
        // Arrange
        WarehouseDbContext dbContext = new DbContextTest();
        // Act & Assert
        Should.Throw<ContainerQtyZeroException>(() => dbContext.Articles.Add(new Article(1, "Laptop")
        {
            Containers = new List<Container>
            {
                new(0)
                {
                    Address = new Address("STRA1")
                    {
                        Description = "Wertarticle"
                    }
                }
            }
        }));
    }
}