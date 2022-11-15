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
        IContainerRulesTest containerRulesTest = new ContainerRulesTest();
        // Act
        var container = containerRulesTest.Create(111, 1, new Article("Coco"), new Address { CodeId = "STRA1" });
        //Assert
        container.ContainerId.ShouldBe(111);
    }

    [Fact]
    public void ContainerDelete()
    {
        // Arrange
        IContainerRulesTest containerRulesTest = new ContainerRulesTest();
        // Act
        var container = containerRulesTest.Create(111, 1, new Article("Coco"), new Address { CodeId = "STRA1" });
        //Assert
        container.ContainerId.ShouldBe(111);
        bool containerState = containerRulesTest.Delete(111);
        containerState.ShouldBeTrue();
    }
}