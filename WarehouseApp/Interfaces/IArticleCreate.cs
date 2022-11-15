using WarehouseCore.Entities.Product;

namespace WarehouseApp.Interfaces;

public interface IArticleCreate
{
    Article Create(int id, string name);
}