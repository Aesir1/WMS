using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;

namespace IntegrationTest.Fixture;

public static class ContainerFixtureCreate
{
    public static int Qty = 5;
    public static Address Address = new Address("STRA1");
    public static Article Article = new Article(11, "Laptop");
}