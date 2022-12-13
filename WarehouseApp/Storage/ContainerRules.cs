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
        var container = new Container(qty)
        {
            Article = article,
            Address = address
        };
        try
        {
            _context.Containers.Add(container);
            // Todo Try and Catch for failing container saving
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return container;
    }

    public Container Modified(int id, int qty, Address? address = default, Article? article = default)
    {
        var container = _context.Containers.FirstOrDefault(c => c.Id == id);
        if (container == null) throw new Exception($"Container ID: {id} not found");
        if (qty == container.Qty && address == container.Address && article == container.Article)
            throw new Exception($"Container Nr: {id} has nothing to modified");
        container.Qty = qty;
        container.Address = address ?? container.Address;
        container.Article = article ?? container.Article;
        _context.SaveChanges();
        return container;
    }

    public bool Delete(int id)
    {
        var container = _context.Containers.FirstOrDefault(c => c.Id == id);
        if (container == null) throw new Exception($"Container ID: {id} not found");

        _context.Containers.Remove(container);
        // Todo Try and catch for failing saveChanges
        _context.SaveChanges();
        return true;
    }
}