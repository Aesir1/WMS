using IntegrationTest;
using Shouldly;
using WarehouseApp.Interfaces;
using WarehouseApp.Storage;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;
using Xunit;

namespace XunitTest.Storage;

public class ContainerRulesTest
{
    [Fact]
    public void ContainerCreate()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        IContainerRules containerCreateTest = new ContainerRules(context);
        // Act
        var container = containerCreateTest.Create(1, new Article(1, "Coco"), new Address("STRA1") ).Result;
        var containerFromDb = context.Containers.First();
        // Assert
        context.Containers.Count().ShouldBe(1);
        container.Id.ShouldBe(containerFromDb.Id);
    }
    [Fact]
    public void ContainerModified()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        IContainerRules containerTest = new ContainerRules(context);
        var container = containerTest.Create(1, new Article(1, "Coco"), new Address("STRA1") ).Result;
        // Act
        containerTest.Modified(container.Id, 100);
        var containerQtyModified = context.Containers.First();
        //Assert
        context.Containers.Count().ShouldBe(1);
        containerQtyModified.Qty.ShouldBe(100);
    }

    [Fact]
    public void ContainerDelete()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        IContainerRules containerRules = new ContainerRules(context);
        var container = containerRules.Create(1, new Article(1, "Coco"), new Address("STRA1") ).Result;
        // Act
        bool containerState = containerRules.Delete(container.Id);
        //Assert
        containerState.ShouldBeTrue();
        context.Containers.Count().ShouldBe(0);
    }
}