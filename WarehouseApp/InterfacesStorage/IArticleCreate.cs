using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;

namespace WarehouseApp.InterfacesStorage;

public interface IArticleCreate
{
    Article Create(int id, string name, ICollection<Container> containers);
}