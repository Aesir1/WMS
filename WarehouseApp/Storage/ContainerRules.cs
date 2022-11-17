using WarehouseApp.InterfacesStorage;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Exceptions;
using WarehouseInfrastructure.Contexts;

namespace WarehouseApp.Storage;

public class ContainerRules : IContainerCreate, IContainerModified, IContainerDelete
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
        try
        {
            // possible double container id reference
            _context.Containers.Add(container);
            _context.SaveChanges();
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
        Container? container = _context.Containers.First(c => c.Id == id);
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
        _context.SaveChanges();
        return container;
    }

    public bool Delete(int id)
    {
        Container? container = _context.Containers.First(c => c.Id == id);
        if (container == null)
        {
            throw new ContainerIdMissing();
        }

        try
        {
            _context.Containers.Remove(container);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}