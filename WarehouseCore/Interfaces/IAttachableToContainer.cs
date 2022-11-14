using WarehouseCore.Entities.Storage;

namespace WarehouseCore.Interfaces;

public interface IAttachableToContainer
{
    ICollection<Container> Containers { get; set; }
}