using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;

namespace WarehouseApp.InterfacesStorage;

public interface IContainerCreate
{
     Container Create(int id, int qty, Article article, Address address);
}