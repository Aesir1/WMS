using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Entities.Product;

namespace WarehouseCore.Entities.Unities;

public class Heaviness : UnitEntity
{
    public Heaviness(string unit, double weight) : base(unit)
    {
        Weight = weight;
    }
    
    public double Weight { get; set; }
}