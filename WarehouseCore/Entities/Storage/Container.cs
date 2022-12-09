using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Entities.Product;
using WarehouseCore.Exceptions;

namespace WarehouseCore.Entities.Storage;

/// <summary>
///     The container entity serve as storage form where articles will be storage into specific an address
/// </summary>
public class Container : IdEntity
{
    public Container(int qty)
    {
        Qty = qty > 0 ? qty : throw new ContainerQtyZeroException();
    }
    public int Qty { get; set; }
    public Address Address { get; set; }
    public Article Article { get; set; }
}