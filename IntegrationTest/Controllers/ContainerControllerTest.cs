using ApiRest.Controllers;
using IntegrationTest.Fixture;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
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
            ContainerFixtureCreate.Address);
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
            ContainerFixtureCreate.Address);
        // Assert
        result.Result.ShouldBeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public void ModifiedContainerOnSuccess()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerController controller = new ContainerController(context);
        var result = controller.CreateContainer(ContainerFixtureCreate.Qty, ContainerFixtureCreate.Article,
            ContainerFixtureCreate.Address);
        // Act
    }
    
    [Fact]
    public void ModifiedContainerOnFail()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerController controller = new ContainerController(context);
        var toModified = controller.CreateContainer(ContainerFixtureCreate.Qty, ContainerFixtureCreate.Article,
            ContainerFixtureCreate.Address);
        int id = toModified.Value.Id;
        // Act
        var result = controller.ModifiedContainer(id, 3);
        // Assert
        result.Result.ShouldBeOfType<OkObjectResult>();
    }
}