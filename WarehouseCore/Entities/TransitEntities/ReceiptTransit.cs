using WarehouseCore.Entities.Storage;
using WarehouseCore.Enums;

namespace WarehouseCore.Entities.TransitEntities;

public class ReceiptTransit : TransitBase
{
    public ReceiptTransit(Address address)
    {
        Address = address;
        TransitLabel = TransitLabel.GoodsReceipt;
    }

    public override Address Address { get; set; }
}