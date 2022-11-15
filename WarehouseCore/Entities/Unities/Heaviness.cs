using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Entities.Product;

namespace WarehouseCore.Entities.Unities;

public class Heaviness : CodeEntity
{
    public Heaviness(string codeId, double weight) : base(codeId)
    {
        Weight = weight;
    }

    public double Weight { get; set; }
    public ICollection<Article> Articles { get; set; }
}