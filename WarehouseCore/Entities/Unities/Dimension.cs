using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Entities.Product;

namespace WarehouseCore.Entities.Unities;

public class Dimension : CodeEntity
{
    public Dimension(string codeId, decimal length, decimal width) : base(codeId)
    {
        Length = length;
        Width = width;
    }

    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public ICollection<Article> Articles { get; set; }
}