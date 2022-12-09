using WarehouseApp.Interfaces;
using WarehouseApp.Storage;
using WarehouseInfrastructure.Contexts;

namespace IntegrationTest.Fixture;

public class AddressFixture
{
    public static readonly string CodeId = "STRA1";
    public static readonly string Description = "Halle1";
    
    public static void CreateOneAddress(WarehouseDbContext context)
    {
        IAddressRules addressRules = new AddressRules(context);
        addressRules.Create(CodeId, description: Description);
    }
    
    public static void CreateListOfAddress(WarehouseDbContext context)
    {
        IAddressRules addressRules = new AddressRules(context);
        addressRules.Create(CodeId, description: Description);
        addressRules.Create("STRA2", description: "Halle2");
    }
}