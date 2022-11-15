using WarehouseCore.Entities.Product;

namespace WarehouseApp.InterfacesStorage;

public interface IArticleCreate
{
    Article Create(int id, string name);
}