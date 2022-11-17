using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Enums;

namespace WarehouseCore.Entities.TransitEntities;

public abstract class TransitBase : IdEntity
{
    protected TransitBase(Address address, TransitLabel transitLabel)
    {
        Address = address;
        TransitLabel = transitLabel;
    }

    public Address Address { get; set; }
    public TransitLabel TransitLabel { get; set; }
}