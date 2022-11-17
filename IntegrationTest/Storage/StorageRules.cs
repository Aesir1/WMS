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
        var container = containerCreateTest.Create(1, new Article("Coco"), new Address("STRA1") );
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