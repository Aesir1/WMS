using IntegrationTest.Interfaces;
using Shouldly;
using WarehouseApp.Storage;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;
using Xunit;

namespace IntegrationTest.Storage;

public class StorageRules
{
    [Fact]
    public void ContainerCreate()
    {
        // Arrange
        WarehouseDbContext _context = new DbContextTest();
        ContainerRules containerCreateTest = new ContainerRules(_context);
        // Act
        var container = containerCreateTest.Create(1, new Article(1, "Coco"), new Address("STRA1") );
        //Assert
        //ToDo test aren't accurate
        //container.Id.ShouldBe(111);
    }

    [Fact]
    public void ContainerDelete()
    {
        // Arrange
        IContainerDeleteTest containerCreateTest = new ContainerRulesTest();
        // Act
        //Assert
        bool containerState = containerCreateTest.Delete(111);
        containerState.ShouldBeTrue();
    }
}