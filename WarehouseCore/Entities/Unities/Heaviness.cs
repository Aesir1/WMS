using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.Unities;

public class Heaviness : UnitEntity
{
    public Heaviness(string unit, double weight) : base(unit)
    {
        Weight = weight;
    }

    public double Weight { get; set; }
}