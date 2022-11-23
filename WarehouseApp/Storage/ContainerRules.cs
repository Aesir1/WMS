using WarehouseApp.Interfaces;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;

namespace WarehouseApp.Storage;

public class ContainerRules : IContainerRules
{
    private readonly WarehouseDbContext _context;

    public ContainerRules(WarehouseDbContext warehouseDbContext)
    {
        _context = warehouseDbContext;
    }

    public Container Create(int qty, Article article, Address address)
    {
        Container container = new Container(qty)
        {
            Article = article,
            Address = address
        };
        _context.Containers.Add(container);
        _context.SaveChanges();

        return container;
    }
    public Container Modified(int id, int qty, Address? address = default, Article? article = default)
    {
        Container? container = _context.Containers.First(c => c.Id == id);
        if (container == null)
        {
            throw new Exception($"Container ID: {id} not found");
        }
        if (qty == default && address == default && article == default)
        {
            throw new Exception($"Container Nr: {id} has nothing to modified");
        }
        container.Qty = qty;
        container.Address = address ?? container.Address;
        container.Article = article ?? container.Article;
        _context.SaveChanges();
        return container;
    }

    public bool Delete(int id)
    {
        Container? container = _context.Containers.First(c => c.Id == id);
        if (container == null)
        {
            throw new Exception($"Container ID: {id} not found");
        }

        _context.Containers.Remove(container);
        _context.SaveChanges();
        return true;
    }
}