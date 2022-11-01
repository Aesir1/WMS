using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.Product;

public class ExternalArticle : GuidEntity
{
    public string ISBN { get; set; }
    public ExternalArticle(string isbn)
    {
        ISBN = isbn;
        
    }
}