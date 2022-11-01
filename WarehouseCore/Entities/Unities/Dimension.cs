using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.Unities;

public class Dimension : CodeEntity
{
    public Dimension(decimal length, decimal width, string code) : base(code)
    {
        Length = length;
        Width = width;
    }

    public decimal Length { get; set; }
    public decimal Width { get; set; }
}