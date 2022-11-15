using WarehouseCore.Entities.Storage;
using WarehouseCore.Enums;

namespace WarehouseCore.Entities.TransitEntities;

public class DeliverTransit : TransitBase
{
    public DeliverTransit(int id, Address address) : base(id, address, TransitLabel.GoodsReceipt)
    {
    }
}