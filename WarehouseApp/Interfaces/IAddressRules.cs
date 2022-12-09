using WarehouseCore.Entities.Storage;

namespace WarehouseApp.Interfaces;

public interface IAddressRules
{
    Address Create(string codeId, ICollection<Container>? containers = default,string? description = default);
    Address Modify(string codeId, string? description = default);
    bool Delete(string codeId);
}