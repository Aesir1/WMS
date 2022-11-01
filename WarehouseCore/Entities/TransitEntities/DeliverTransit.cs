using WarehouseCore.Entities.Storage;
using WarehouseCore.Enums;

namespace WarehouseCore.Entities.TransitEntities;

public class DeliverTransit : TransitBase
{
    public DeliverTransit(Address address)
    {
        Address = address;
        TransitLabel = TransitLabel.GoodsIssue;
    }

    public override Address Address { get; set; }
}