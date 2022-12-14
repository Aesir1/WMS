using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Entities.Unities;
using WarehouseCore.Interfaces;

namespace WarehouseCore.Entities.Product;

/// <summary>
///     Article is a product reference that can be allocated into many container
/// </summary>
public class Article : IdEntity, IAttachableToContainer
{
    public Article(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; }


    public Dimension? Dimension { get; set; }

    public Heaviness? Heaviness { get; set; }
    public ICollection<Container>? Containers { get; set; }
}