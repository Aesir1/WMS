using WarehouseCore.Entities.Storage;

namespace WarehouseApp.InterfacesStorage;

public interface IAddressCreate
{
    Address Create(string codeId, string? description = default);
}