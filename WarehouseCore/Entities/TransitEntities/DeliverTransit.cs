using WarehouseCore.Entities.Storage;
using WarehouseCore.Enums;

namespace WarehouseCore.Entities.TransitEntities;

public class DeliverTransit : TransitBase
{
    public DeliverTransit(Address address) : base(address, TransitLabel.GoodsReceipt)
    {
    }
}