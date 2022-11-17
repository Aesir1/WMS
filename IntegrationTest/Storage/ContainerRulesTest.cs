using IntegrationTest.Interfaces;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Exceptions;
using WarehouseInfrastructure.Contexts;

namespace IntegrationTest.Storage;

public class ContainerRulesTest : IContainerCreateTest, IContainerDeleteTest
{
    public Container Create(int qty, Article article, Address address)
    {
        WarehouseDbContext context = new DbContextTest();
        Container container = new Container(qty)
        {
            Article = article,
            Address = address
        };
        try
        {
            // possible double container id reference
            context.Containers.Add(container);
            context.SaveChanges();
        }
        catch (ContainerIdMatch containerIdMatch)
        {
            // ToDo need to improve this exception will be part of the test phase
            throw containerIdMatch;
        }
        catch (Exception ex)
        {
            
            throw ex;
        }

        return container;
    }
    public Container Modified(int id, int qty, Address? address = default, Article? article = default)
    {
        WarehouseDbContext context = new DbContextTest();
        Container? container = context.Containers.First(c => c.Id == id);
        if (container == null)
        {
            throw new ContainerIdMissing();
        }
        if (qty == default && address == default && article == default)
        {
            throw new ContainerNoModified();
        }
        container.Qty = qty;
        container.Address = address ?? container.Address;
        container.Article = article ?? container.Article;
        context.SaveChanges();
        return container;
    }

    public bool Delete(int id)
    {
        WarehouseDbContext context = new DbContextTest();
        Container? container = context.Containers.First(c => c.Id == id);
        if (container == null)
        {
            throw new ContainerIdMissing();
        }

        try
        {
            context.Containers.Remove(container);
            context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}