using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.Storage;

/// <summary>
///     The container entity serve as storage form where articles will be storage and later on are able to receive an
///     address
/// </summary>
public class Container  : BaseEntity
{
    public int ContainerId { get; set; }
}