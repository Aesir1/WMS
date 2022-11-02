using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Entities.Unities;

namespace WarehouseCore.Entities.Product;

public class Article : GuidEntity
{
    public Article(string name, int qty)
    {
        Name = name;
        Qty = qty;
    }

    public string Name { get; set; }
    public int Qty { get; set; }


    public Dimension Dimension { get; set; }

    public Heaviness Heaviness { get; set; }
    public ICollection<Container> Containers { get; set; }
}