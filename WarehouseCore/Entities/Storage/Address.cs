using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Interfaces;

namespace WarehouseCore.Entities.Storage;

///  /// <summary>
/// Address is a reference place where container can be allocated, that means that address dont handle neither with container nor articles related logic
/// </summary>
public class Address : CodeEntity, IAttachableToContainer
{
    public ICollection<Container>? Containers { get; set; }

    public Address(string codeId) : base(codeId)
    {
    }
}