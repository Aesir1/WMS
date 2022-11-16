using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Entities.Unities;

namespace WarehouseApp.InterfacesStorage;

public interface IArticleModified
{
    Article Modified(int id, string? name = default,
        Dimension? dimension = default, Heaviness? heaviness = default,
        ICollection<Container>? containers = default);
}