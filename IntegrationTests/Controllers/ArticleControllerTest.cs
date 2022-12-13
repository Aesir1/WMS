using ApiRest.Controllers;
using IntegrationTests.Fixture;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using WarehouseCore.Entities.Product;
using WarehouseInfrastructure.Contexts;

namespace IntegrationTests.Controllers;

public class ArticleControllerTest
{
    [Fact]
    public void GetOnSuccessArticleWithId()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        ArticleFixture.CreateOneArticle(context);
        var articleController = new ArticleController(context);
        // Act
        var result = articleController.GetArticle(ArticleFixture.Id).Result;
        // Assert
        result.ShouldBeOfType<OkObjectResult>();
    }

    [Fact]
    public void GetOnFailArticleWithId()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        ArticleFixture.CreateOneArticle(context);
        var articleController = new ArticleController(context);
        // Act
        var result = articleController.GetArticle(4).Result;
        // Assert
        result.ShouldBeOfType<NotFoundResult>();
    }

    [Fact]
    public void GetOnSuccessArticlesList()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        ArticleFixture.CreateListOfArticle(context);
        var articleController = new ArticleController(context);
        // Act
        var result = articleController.GetArticles().Result;
        // Assert
        result.ShouldBeOfType<OkObjectResult>();
    }

    [Fact]
    public void GetOnFailArticlesList()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        var articleController = new ArticleController(context);
        // Act
        var result = articleController.GetArticles().Result;
        // Assert
        result.ShouldBeOfType<NotFoundResult>();
    }

    [Fact]
    public void CreateOnSuccessArticle()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        var articleController = new ArticleController(context);
        // Act
        var result = articleController.CreateArticle(ArticleFixture.Id, ArticleFixture.Name,
            dimension: ArticleFixture.Dimension, heaviness: ArticleFixture.Heaviness).Result;
        // Assert
        result.ShouldBeOfType<CreatedResult>();
    }


    [Fact]
    public void CreateOnFailArticleWithSameId()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        ArticleFixture.CreateOneArticle(context);
        var articleController = new ArticleController(context);
        // Act
        var result = articleController.CreateArticle(ArticleFixture.Id, ArticleFixture.Name,
            dimension: ArticleFixture.Dimension, heaviness: ArticleFixture.Heaviness).Result;
        // Assert
        result.ShouldBeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public void ModifyArticleOnSuccess()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        ArticleFixture.CreateOneArticle(context);
        var articleController = new ArticleController(context);
        // Act
        var result = articleController.ModifyArticle(ArticleFixture.Id,
            "Changed name").Result;
        var resultFromResult = result as OkObjectResult;
        // Assert
        result.ShouldBeOfType<OkObjectResult>();
        resultFromResult.Value.ShouldBeOfType<Article>().Name.ShouldBe("Changed name");
    }

    [Fact]
    public void ModifyArticleOnFailWhenIdDoesntExists()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        ArticleFixture.CreateOneArticle(context);
        var articleController = new ArticleController(context);
        // Act
        var result = articleController.ModifyArticle(1, "Changed name").Result;
        //
        result.ShouldBeOfType<ObjectResult>().StatusCode.ShouldBe(304);
        result.ShouldBeOfType<ObjectResult>()
            .Value.ShouldBeOfType<Exception>().Message.ShouldBe($"Article ID doesn't exists: {1}");
    }

    [Fact]
    public void ModifyArticleOnFailWhenNothingToModify()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        ArticleFixture.CreateOneArticle(context);
        var articleController = new ArticleController(context);
        // Act
        var result = articleController.ModifyArticle(ArticleFixture.Id, ArticleFixture.Name, dimension: ArticleFixture.Dimension, heaviness: ArticleFixture.Heaviness).Result;
        //
        result.ShouldBeOfType<ObjectResult>().StatusCode.ShouldBe(304);
        result.ShouldBeOfType<ObjectResult>()
            .Value.ShouldBeOfType<Exception>().Message.ShouldBe("there's nothing here to update");
    }

    [Fact]
    public void DeleteArticleOnSuccess()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        ArticleFixture.CreateOneArticle(context);
        var articleController = new ArticleController(context);
        // Act
        var result = articleController.DeleteArticle(ArticleFixture.Id);
        // Assert
        result.ShouldBeOfType<NoContentResult>();
    }

    [Fact]
    public void DeleteArticleOnFail()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        var articleController = new ArticleController(context);
        // Act
        var result = articleController.DeleteArticle(ArticleFixture.Id);
        var resultFromResult = result as ObjectResult;
        // Assert
        result.ShouldBeOfType<ObjectResult>().StatusCode.ShouldBe(304);
        resultFromResult.Value.ShouldBeOfType<Exception>().Message
            .ShouldBe($"Article ID doesn't exists:{ArticleFixture.Id}");
    }
}