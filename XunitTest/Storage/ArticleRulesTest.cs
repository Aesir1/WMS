using IntegrationTest;
using Shouldly;
using WarehouseApp.Interfaces;
using WarehouseApp.Storage;
using WarehouseCore.Entities.Unities;
using WarehouseInfrastructure.Contexts;
using Xunit;

namespace XunitTest.Storage;

public class ArticleRulesTest
{
    [Fact]
    public void ArticleCreate()
    {
        // Arrange 
        WarehouseDbContext context = new DbContextTest();
        IArticleRules articleRules = new ArticleRules(context);
        // Act
        var article = articleRules.Create(10, "Laptop");
        
        var articleFromDb = context.Articles.First();
        // Assert
        context.Articles.Count().ShouldBe(1);
        article.Id.ShouldBe(articleFromDb.Id);
    }

    [Fact]
    public void ArticleModified()
    {
        // Arrange 
        WarehouseDbContext context = new DbContextTest();
        IArticleRules articleRules = new ArticleRules(context);
        articleRules.Create(10, "Laptop");
        // Act
        articleRules.Modify(10, "Display", new Dimension("cm", 40, 60), new Heaviness("kg", 6));
        var articleFromDb = context.Articles.First();
        // Assert
        articleFromDb.Name.ShouldBe("Display");
        articleFromDb.Dimension.ShouldNotBeNull();
        articleFromDb.Heaviness.ShouldNotBeNull();
    }

    [Fact]
    public void ArticleDelete()
    {
        // Arrange 
        WarehouseDbContext context = new DbContextTest();
        IArticleRules articleRules = new ArticleRules(context);
        articleRules.Create(10, "Laptop");
        // Act
        bool articleDeleted = articleRules.Delete(10);
         
        // Assert
        articleDeleted.ShouldBe(true);
        context.Articles.Count().ShouldBe(0);
    }
}