using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Interfaces;

namespace WarehouseCore.Entities.Storage;

/// <summary>
///     Address can only handle with container that means a direct assignment from article in one address isn't a allowed
/// </summary>
public class Address : CodeEntity, IAttachableToContainer
{
    public ICollection<Container> Containers { get; set; }
}