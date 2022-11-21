using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Entities.Unities;

namespace WarehouseApp.Interfaces;

public interface IArticleRules
{
    Article Create(int id, string name, ICollection<Container> containers);
    Article Modified(int id, string? name = default,
        Dimension? dimension = default, Heaviness? heaviness = default,
        ICollection<Container>? containers = default);
    bool Delete(int id);
}