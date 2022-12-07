using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;

namespace WarehouseApp.Interfaces;

public interface IContainerRules
{
    Task<Container> Create(int qty, Article article, Address address);
    Task<Container> Modified(int id, int qty, Address? address = default, Article? article = default);
    bool Delete(int id);
}