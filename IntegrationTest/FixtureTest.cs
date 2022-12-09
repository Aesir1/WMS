using IntegrationTest.Fixture;
using Shouldly;
using WarehouseInfrastructure.Contexts;
using Xunit;

namespace IntegrationTest;

public class FixtureTest
{
    [Fact]
    public void CreateOneContainerFixtureOnSuccess()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        // Act
        var containersBefore = context.Containers.ToList();
        ContainerFixture.CreateOneContainer(context);
        var containersAfter = context.Containers.ToList();
        // Assert
        containersBefore.Count.ShouldBe(0);
        containersAfter.Count.ShouldBe(1);
    }
    
    [Fact]
    public void CreateListOfContainerFixtureOnSuccess()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        // Act
        var containersBefore = context.Containers.ToList();
        ContainerFixture.CreateListOfContainer(context);
        var containersAfter = context.Containers.ToList();
        // Assert
        containersBefore.Count.ShouldBe(0);
        containersAfter.Count.ShouldBe(2);
    }
    
    [Fact]
    public void CreateOneArticleFixtureOnSuccess()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        // Act
        var articlesBefore = context.Articles.ToList();
        ArticleFixture.CreateOneArticle(context);
        var articlesAfter = context.Articles.ToList();
        // Assert
        articlesBefore.Count.ShouldBe(0);
        articlesAfter.Count.ShouldBe(1);
    }
    
    [Fact]
    public void CreateListOfArticleFixtureOnSuccess()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        // Act
        var articlesBefore = context.Articles.ToList();
        ArticleFixture.CreateListOfArticle(context);
        var articlesAfter = context.Articles.ToList();
        // Assert
        articlesBefore.Count.ShouldBe(0);
        articlesAfter.Count.ShouldBe(3);
    }
    
    [Fact]
    public void CreateOneAddressFixtureOnSuccess()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        // Act
        var addressesBefore = context.Addresses.ToList();
        AddressFixture.CreateOneAddress(context);
        var addressesAfter = context.Addresses.ToList();
        // Assert
        addressesBefore.Count.ShouldBe(0);
        addressesAfter.Count.ShouldBe(1);
    }
    
    [Fact]
    public void CreateListOfAddressesFixtureOnSuccess()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        // Act
        var addressesBefore = context.Addresses.ToList();
        AddressFixture.CreateListOfAddress(context);
        var addressesAfter = context.Addresses.ToList();
        // Assert
        addressesBefore.Count.ShouldBe(0);
        addressesAfter.Count.ShouldBe(2);
    }
}