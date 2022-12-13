using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.Product;

public class ExternalArticle : IdEntity
{
    public ExternalArticle(string isbn)
    {
        Isbn = isbn;
    }

    public string Isbn { get; set; }
}