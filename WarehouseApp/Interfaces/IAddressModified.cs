using WarehouseCore.Entities.Storage;

namespace WarehouseApp.Interfaces;

public interface IAddressModified
{
    Address Modified(string codeId, string? description = default);
}