using ApiRest.Controllers;
using IntegrationTests.Fixture;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;

namespace IntegrationTests.Controllers;

public class ContainerControllerTest
{
    [Fact]
    public void GetOnSuccessContainerWithId()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerFixture.CreateOneContainer(context);
        var controller = new ContainerController(context);
        var container = context.Containers.FirstOrDefault();
        // Act
        var result = controller.GetContainer(container.Id).Result;
        // Assert
        result.ShouldBeOfType<OkObjectResult>();
        context.Containers.Count().ShouldBe(1);
    }

    [Fact]
    public void GetOnFailContainerWithId()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        var controller = new ContainerController(context);
        // Act
        var result = controller.GetContainer(1).Result;
        // Assert
        result.ShouldBeOfType<NotFoundResult>();
        context.Containers.Count().ShouldBe(0);
    }

    [Fact]
    public void GetOnSuccessContainerList()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerFixture.CreateListOfContainer(context);
        var controller = new ContainerController(context);
        // Act
        var result = controller.GetContainers().Result;
        // Assert
        result.ShouldBeOfType<OkObjectResult>();
        context.Containers.Count().ShouldBe(2);
    }

    [Fact]
    public void GetOnFailContainerList()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        var controller = new ContainerController(context);
        // Act
        var result = controller.GetContainers().Result;
        // Assert
        result.ShouldBeOfType<NotFoundResult>();
        context.Containers.Count().ShouldBe(0);
    }

    [Fact]
    public void CreateContainerOnSuccess()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        var controller = new ContainerController(context);
        // Act
        var result = controller.CreateContainer(54, new Article(87, "Skateboard"), new Address("STRA99")).Result;
        // Assert
        result.ShouldBeOfType<CreatedResult>();
    }

    [Fact]
    public void CreateContainerOnFailWhenQtyZero()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        var controller = new ContainerController(context);
        // Act
        var result = controller.CreateContainer(0, ContainerFixture.Article,
            ContainerFixture.Address).Result;
        // Assert
        result.ShouldBeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public void ModifiedContainerOnSuccess()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerFixture.CreateOneContainer(context);
        var controller = new ContainerController(context);
        // Act
        var result = controller.ModifyContainer(1, 3).Result;
        var resultFromResult = result as OkObjectResult;
        // Assert
        result.ShouldBeOfType<OkObjectResult>().StatusCode.ShouldBe(200);
        resultFromResult.Value.ShouldBeOfType<Container>().Qty.ShouldBe(3);
    }

    [Fact]
    public void ModifiedContainerWithIdOnFail()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerFixture.CreateOneContainer(context);
        var controller = new ContainerController(context);
        // Act
        var result = controller.ModifyContainer(2, 3).Result;
        var resultFromResult = result as ObjectResult;
        // Assert
        result.ShouldBeOfType<ObjectResult>().StatusCode.ShouldBe(304);
        resultFromResult.Value.ShouldBeOfType<Exception>().Message.ShouldBe("Container ID: 2 not found");
    }

    [Fact]
    public void ModifiedContainerHasNothingToModified()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerFixture.CreateOneContainer(context);
        var controller = new ContainerController(context);
        // Act
        var result = controller.ModifyContainer(1, ContainerFixture.Qty, ContainerFixture.Address,
            ContainerFixture.Article).Result;
        var resultFromResult = result as ObjectResult;
        // Assert
        result.ShouldBeOfType<ObjectResult>().StatusCode.ShouldBe(304);
        resultFromResult.Value.ShouldBeOfType<Exception>().Message.ShouldBe("Container Nr: 1 has nothing to modified");
    }

    [Fact]
    public void DeletedContainer()
    {
        //Arrange
        WarehouseDbContext context = new DbContextTest();
        ContainerFixture.CreateOneContainer(context);
        var controller = new ContainerController(context);
        // Act
        var result = controller.DeleteContainer(1);
        //Assert
        result.ShouldBeOfType<NoContentResult>().StatusCode.ShouldBe(204);
    }

    [Fact]
    public void DeleteContainerFail()
    {
        WarehouseDbContext context = new DbContextTest();
        var controller = new ContainerController(context);
        var todelete = controller.CreateContainer(ContainerFixture.Qty, ContainerFixture.Article,
            ContainerFixture.Address);
        // Act
        var result = controller.DeleteContainer(2);
        var hardresult = result as ObjectResult;
        // Assert
        result.ShouldBeOfType<ObjectResult>().StatusCode.ShouldBe(304);
        hardresult.Value.ShouldBeOfType<Exception>().Message.ShouldBe("Container ID: 2 not found");
    }
}