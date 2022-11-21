using WarehouseCore.Entities.Storage;

namespace WarehouseApp.Interfaces;

public interface IAddressRules
{
    Address Create(string codeId, ICollection<Container>? containers,string? description = default);
    Address Modified(string codeId, string? description = default, ICollection<Container>? containers = default);
    bool Delete(string codeId);
}