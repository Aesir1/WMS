using IntegrationTest.Interfaces;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using Xunit;

namespace IntegrationTest.Storage;

public class StorageRules
{
    [Fact]
    public void ContainerCreate()
    {    // Arrange
        IContainerRulesTest containerRulesTest = new ContainerRulesTest();
        //Assert
        var container = containerRulesTest.Create(111, 1, new Article("Coco"), new Address { CodeId = "STRA1" });
    }
}