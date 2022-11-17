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
    public int ArticleId { get; set; }
    public Article Article { get; set; }
}