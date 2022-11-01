using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.Product;

public class ExternalArticle : GuidEntity
{
    public ExternalArticle(string isbn)
    {
        ISBN = isbn;
    }

    public string ISBN { get; set; }
}