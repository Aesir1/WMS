using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;

namespace WarehouseApp.InterfacesStorage;

public interface IContainerModified
{
    Container Modified(int id, int qty, Address? address = default, Article? article = default);
}