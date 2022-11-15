using IntegrationTest.Interfaces;
using Shouldly;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using Xunit;

namespace IntegrationTest.Storage;

public class StorageRules
{
    [Fact]
    public void ContainerCreate()
    {
        // Arrange
        IContainerCreateTest containerCreateTest = new ContainerRulesTest();
        // Act
        var container = containerCreateTest.Create(111, 1, new Article(1, "Coco"), new Address("STRA1") );
        //Assert
        container.ContainerId.ShouldBe(111);
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