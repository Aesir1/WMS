using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;

namespace IntegrationTest.Interfaces;

public interface IContainerModifiedTest
{
    Container Modified(int id, int qty, Address? address = default, Article? article = default);
}