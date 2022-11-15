using WarehouseCore.Entities.Storage;
using WarehouseCore.Enums;

namespace WarehouseCore.Entities.TransitEntities;

public class ReceiptTransit : TransitBase
{
    public ReceiptTransit(int id, Address address) : base(id, address, TransitLabel.GoodsReceipt)
    {
    }
}