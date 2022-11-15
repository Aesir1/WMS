using WarehouseCore.Entities.Storage;

namespace WarehouseApp.Interfaces;

public interface IAddressDelete
{
    bool Delete(string codeId);
}