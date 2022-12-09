using WarehouseApp.Interfaces;
using WarehouseApp.Storage;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;

namespace IntegrationTest.Fixture;

public static class ContainerFixture
{
    public static readonly int Qty = 5;
    public static readonly Address Address = new Address("STRA1");
    public static readonly Article Article = new Article(11, "Laptop");

    public static void CreateOneContainer(WarehouseDbContext context)
    {
        IContainerRules containerRules = new ContainerRules(context);
        containerRules.Create(Qty, Article, Address);
    }

    public static void CreateListOfContainer(WarehouseDbContext context)
    {
        IContainerRules containerRules = new ContainerRules(context);
        containerRules.Create(245, new Article(523, "Schuhe"), new Address("STRA3"));
        containerRules.Create(20, new Article(54, "Caldo"), new Address("STRA2"));
    }
}