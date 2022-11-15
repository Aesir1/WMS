using WarehouseCore.Entities.Storage;

namespace WarehouseApp.InterfacesStorage;

public interface IAddressModified
{
    Address Modified(string codeId, string? description = default);
}