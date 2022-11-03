using WarehouseCore.Entities.Storage;
using WarehouseCore.Enums;

namespace WarehouseCore.Entities.TransitEntities;

public class ReceiptTransit : TransitBase
{
    public ReceiptTransit(Address address) : base(address , TransitLabel.GoodsReceipt)
    {
    }

    
}