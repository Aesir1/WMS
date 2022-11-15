using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;

namespace IntegrationTest.Interfaces;

public interface IContainerCreateTest
{
    Container Create(int id, int qty, Article article, Address address);
    
}