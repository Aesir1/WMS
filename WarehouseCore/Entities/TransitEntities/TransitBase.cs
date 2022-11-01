using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Enums;

namespace WarehouseCore.Entities.TransitEntities;

public abstract class TransitBase : GuidEntity
{
    public abstract Address Address { get; set; }
    public TransitLabel TransitLabel { get; set; }
}