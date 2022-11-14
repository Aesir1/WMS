using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;

namespace WarehouseApp.Interfaces;

public interface IContainerRules
{
     Container Create(int id, int qty, Article article, Address address);
     Container Modified(int id, int qty, Address? address = default, Article? article = default);
     bool Delete(int id);
}