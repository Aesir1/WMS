using ApiRest.Controllers;
using IntegrationTest.Fixture;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;
using Xunit;

namespace IntegrationTest.Controllers;

public class ContainerControllerTest
{
    [Fact]
    public void GetOnSuccessContainerList()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerController controller = new ContainerController(context);
        // Act
        var result = controller.GetContainer().Result;
        // Assert
        result.ShouldBeOfType<OkObjectResult>();
    }

    [Fact]
    public void CreateContainerOnSuccess()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerController controller = new ContainerController(context);
        // Act
        var result = controller.CreateContainer(ContainerFixtureCreate.Qty, ContainerFixtureCreate.Article,
            ContainerFixtureCreate.Address).Result;
        // Assert
        result.Result.ShouldBeOfType<CreatedResult>();
    }

    [Fact]
    public void CreateContainerOnFail()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerController controller = new ContainerController(context);
        // Act
        var result = controller.CreateContainer(0, ContainerFixtureCreate.Article,
            ContainerFixtureCreate.Address).Result;
        // Assert
        result.Result.ShouldBeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async void ModifiedContainerOnSuccess()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerController controller = new ContainerController(context);
        await controller.CreateContainer(ContainerFixtureCreate.Qty, ContainerFixtureCreate.Article,
            ContainerFixtureCreate.Address);
        // Act
        ActionResult<Container> result = controller.ModifiedContainer(1, 3).Result;
        var resultFromResult = result.Result as OkObjectResult;
        // Assert
        result.Result.ShouldBeOfType<OkObjectResult>().StatusCode.ShouldBe(200);
        resultFromResult.Value.ShouldBeOfType<Container>().Qty.ShouldBe(3);
    }

    [Fact]
    public async void ModifiedContainerIdOnFail()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerController controller = new ContainerController(context);
        await controller.CreateContainer(ContainerFixtureCreate.Qty, ContainerFixtureCreate.Article,
            ContainerFixtureCreate.Address);
        // Act
        var result = controller.ModifiedContainer(2, 3).Result;
        var resultFromResult = result.Result as ObjectResult;
        // Assert
        result.Result.ShouldBeOfType<ObjectResult>().StatusCode.ShouldBe(304);
        resultFromResult.Value.ShouldBeOfType<Exception>().Message.ShouldBe("Container ID: 2 not found");
    }

    [Fact]
    public async void ModifiedContainerHasNothingToModified()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerController controller = new ContainerController(context);
        await controller.CreateContainer(ContainerFixtureCreate.Qty, ContainerFixtureCreate.Article,
            ContainerFixtureCreate.Address);
        // Act
        var result = controller.ModifiedContainer(1, ContainerFixtureCreate.Qty, ContainerFixtureCreate.Address,
            ContainerFixtureCreate.Article).Result;
        var resultFromResult = result.Result as ObjectResult;
        // Assert
        result.Result.ShouldBeOfType<ObjectResult>().StatusCode.ShouldBe(304);
        resultFromResult.Value.ShouldBeOfType<Exception>().Message.ShouldBe("Container Nr: 1 has nothing to modified");
    }

    [Fact]
    public async void DeletedContainer()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerController controller = new ContainerController(context);
        await controller.CreateContainer(ContainerFixtureCreate.Qty, ContainerFixtureCreate.Article,
            ContainerFixtureCreate.Address);
        // Act
        var result = controller.DeleteContainer(1);
        //Assert
        result.ShouldBeOfType<NoContentResult>().StatusCode.ShouldBe(204);
    }

    [Fact]
    public void DeleteContainerFail()
    {
        WarehouseDbContext context = new DbContextTest();
        ContainerController controller = new ContainerController(context);
        var todelete = controller.CreateContainer(ContainerFixtureCreate.Qty, ContainerFixtureCreate.Article,
            ContainerFixtureCreate.Address);
        // Act
        var result = controller.DeleteContainer(2);
        var hardresult = result as ObjectResult;
        // Assert
        result.ShouldBeOfType<ObjectResult>().StatusCode.ShouldBe(304);
        hardresult.Value.ShouldBeOfType<Exception>().Message.ShouldBe("Container ID: 2 not found");
    }
}