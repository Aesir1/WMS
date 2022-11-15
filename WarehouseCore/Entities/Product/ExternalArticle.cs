using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.Product;

public class ExternalArticle : IdEntity
{
    public ExternalArticle(int id, string isbn) : base(id)
    {
        ISBN = isbn;
    }

    public string ISBN { get; set; }
}