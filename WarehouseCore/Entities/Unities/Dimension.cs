using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.Unities;

public class Dimension : UnitEntity
{
    public Dimension(string unit, decimal length, decimal width) : base(unit)
    {
        Length = length;
        Width = width;
    }

    public decimal Length { get; set; }

    public decimal Width { get; set; }
}