using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;

namespace IntegrationTest.Interfaces;

public interface IContainerCreateTest
{
    Container Create(int qty, Article article, Address address);
    
}