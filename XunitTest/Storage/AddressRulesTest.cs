using IntegrationTest;
using Shouldly;
using WarehouseApp.Interfaces;
using WarehouseApp.Storage;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;
using Xunit;

namespace XunitTest.Storage;

public class AddressRulesTest
{
    [Fact]
    public void AddressCreate()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        IAddressRules addressCreateTest = new AddressRules(context);
        //Act
        var address = addressCreateTest.Create("Temp1", description: "Temporary address");
        var addressFromDb = context.Addresses.First();
        //Assert
        context.Addresses.Count().ShouldBe(1);
        address.CodeId.ShouldBe(addressFromDb.CodeId);
    }
    
    [Fact]
    public void AddressModified()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        IAddressRules addressCreateTest = new AddressRules(context);
        var articleRef = new Article(21, "Something");
        var address = addressCreateTest.Create("Temp1",
            new List<Container>
            {
                new(3) { Article = articleRef },
                new(69) { Article = articleRef }
            }, "Temporary text");

        // Act
        addressCreateTest.Modify("Temp1", "Forever young");
        var addressFromDb = context.Addresses.First();
        // Assert
        context.Addresses.Count().ShouldBe(1);
        context.Containers.Count().ShouldBe(2);
        context.Articles.Count().ShouldBe(1);
        addressFromDb.CodeId.ShouldBe("Temp1");
        addressFromDb.Description.ShouldBe("Forever young");
    }

    [Fact]
    public void AddressDeleteInvariableWhenExistingContainer()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        IAddressRules addressCreateTest = new AddressRules(context);
        var articleRef = new Article(21, "Something");
        var address = addressCreateTest.Create("Temp1",
            new List<Container>
            {
                new(3) { Article = articleRef },
                new(69) { Article = articleRef }
            }, "Temporary text");
        // Assert 
        Should.Throw<Exception>(() => addressCreateTest.Delete("Temp1"));
    }

    [Fact]
    public void AddressDelete()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        IAddressRules addressCreateTest = new AddressRules(context);
        var articleRef = new Article(21, "Something");
        var address = addressCreateTest.Create("Temp1", description: "Temporary text");
        // Act 
        var addressdeleted = addressCreateTest.Delete("Temp1");
        // Assert
        addressdeleted.ShouldBe(true);
    }
}