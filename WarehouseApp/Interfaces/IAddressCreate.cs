using WarehouseCore.Entities.Storage;

namespace WarehouseApp.Interfaces;

public interface IAddressCreate
{
    Address Create(string codeId, string? description = default);
}