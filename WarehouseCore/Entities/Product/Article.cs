using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Entities.Unities;

namespace WarehouseCore.Entities.Product;

public class Article : GuidEntity
{
    public Article(string name, Dimension dimension, Heaviness heaviness)
    {
        Name = name;
        Dimension = dimension;
        Heaviness = heaviness;
    }

    public string Name { get; set; }
    public Dimension Dimension { get; set; }
    public Heaviness Heaviness { get; set; }
}