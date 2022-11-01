using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.Unities;

public class Heaviness : CodeEntity
{
    public Heaviness(double weight, string code) : base(code)
    {
        Weight = weight;
    }

    public double Weight { get; set; }
}