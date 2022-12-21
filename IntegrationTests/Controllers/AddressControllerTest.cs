using ApiRest.Controllers;
using IntegrationTests.Fixture;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;

namespace IntegrationTests.Controllers;

public class AddressControllerTest
{
    [Fact]
    public void GetOnSuccessAddressWithId()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        AddressFixture.CreateOneAddress(context);
        var addressController = new AddressController(context);
        // Act
        var result = addressController.GetAddress(AddressFixture.CodeId).Result;
        // Assert
        result.ShouldBeOfType<OkObjectResult>();
    }

    [Fact]
    public void GetOnFailAddressWithId()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        var addressController = new AddressController(context);
        // Act
        var result = addressController.GetAddress(AddressFixture.CodeId).Result;
        // Assert
        result.ShouldBeOfType<NotFoundResult>();
    }

    [Fact]
    public void GetOnSuccessAddressList()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        AddressFixture.CreateListOfAddress(context);
        var addressController = new AddressController(context);
        // Act
        var result = addressController.GetAddresses().Result;
        // Assert
        result.ShouldBeOfType<OkObjectResult>();
    }

    [Fact]
    public void GetOnFailAddressList()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        var addressController = new AddressController(context);
        // Act
        var result = addressController.GetAddresses().Result;
        // Assert
        result.ShouldBeOfType<NotFoundResult>();
    }

    [Fact]
    public void CreateOnSuccessAddress()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        var addressController = new AddressController(context);
        // Act
        var result = addressController.CreateAddress(AddressFixture.CodeId, description: AddressFixture.Description)
            .Result;
        // Assert
        result.ShouldBeOfType<CreatedResult>();
    }

    [Fact]
    public void CreateOnFailAddressWithSameId()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        AddressFixture.CreateOneAddress(context);
        var addressController = new AddressController(context);
        // Act
        var result = addressController.CreateAddress(AddressFixture.CodeId, description: AddressFixture.Description)
            .Result;
        // Assert
        result.ShouldBeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public void ModifyAddressOnSuccess()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        AddressFixture.CreateOneAddress(context);
        var addressController = new AddressController(context);
        // Act
        var result = addressController.ModifyAddress(AddressFixture.CodeId, "address was moved").Result;
        var resultFromResult = result as OkObjectResult;
        // Assert
        result.ShouldBeOfType<OkObjectResult>();
        resultFromResult.Value.ShouldBeOfType<Address>().Description.ShouldBe("address was moved");
    }

    [Fact]
    public void ModifyAddressOnFailWhenIdDoesntExists()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        AddressFixture.CreateOneAddress(context);
        var addressController = new AddressController(context);
        // Act
        var result = addressController.ModifyAddress("STRA5", "address was moved").Result;
        //
        result.ShouldBeOfType<ObjectResult>().StatusCode.ShouldBe(304);
        result.ShouldBeOfType<ObjectResult>()
            .Value.ShouldBeOfType<Exception>().Message.ShouldBe("Address id doesn't exists: STRA5");
    }

    [Fact]
    public void ModifyAddressOnFailWhenNothingToModify()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        AddressFixture.CreateOneAddress(context);
        var addressController = new AddressController(context);
        // Act
        var result = addressController.ModifyAddress(AddressFixture.CodeId, AddressFixture.Description).Result;
        //
        result.ShouldBeOfType<ObjectResult>().StatusCode.ShouldBe(304);
        result.ShouldBeOfType<ObjectResult>()
            .Value.ShouldBeOfType<Exception>().Message.ShouldBe("there's nothing here to update");
    }

    [Fact]
    public void DeleteAddressOnSuccess()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        AddressFixture.CreateOneAddress(context);
        var addressController = new AddressController(context);
        // Act
        var result = addressController.DeleteAddress(AddressFixture.CodeId);
        // Assert
        result.ShouldBeOfType<NoContentResult>();
    }

    [Fact]
    public void DeleteAddressOnFail()
    {
        // Arrange
        WarehouseDbContext context = new DbContextTest();
        var addressController = new AddressController(context);
        // Act
        var result = addressController.DeleteAddress(AddressFixture.CodeId);
        var resultFromResult = result as ObjectResult;
        // Assert
        result.ShouldBeOfType<ObjectResult>().StatusCode.ShouldBe(304);
        resultFromResult.Value.ShouldBeOfType<Exception>().Message
            .ShouldBe($"Address id doesn't exists:{AddressFixture.CodeId}");
    }
}