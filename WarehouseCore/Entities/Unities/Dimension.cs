using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Entities.Product;

namespace WarehouseCore.Entities.Unities;

public class Dimension : CodeEntity
{
    public Dimension(decimal length, decimal width)
    {
        Length = length;
        Width = width;
    }

    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public ICollection<Article> Articles { get; set; }
}