using WarehouseApp.InterfacesStorage;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Entities.Unities;
using WarehouseInfrastructure.Contexts;

namespace WarehouseApp.Storage;

public class ArticleRules : IArticleCreate, IArticleModified, IArticleDelete
{
    private readonly WarehouseDbContext _context;

    public ArticleRules(WarehouseDbContext context)
    {
        _context = context;
    }

    public Article Create(int id, string name, ICollection<Container> containers)
    {
        Article article = new(name) { Containers = containers };
        try
        {
            // ToDo possible double address id reference specific implementations required  
            _context.Articles.Add(article);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return article;
    }

    public Article Modified(int id, string? name = default,
        Dimension? dimension = default, Heaviness? heaviness = default,
        ICollection<Container>? containers = default)
    {
        Article? article = _context.Articles.First(c => c.Id == id);
        if (article == null)
        {
            throw new($"address id doesn't exists: {id}");
        }

        if (name == default && dimension == default && heaviness == default && containers == default)
        {
            throw new("there's nothing here to update");
        }

        article.Name = name ?? article.Name;
        article.Dimension = dimension ?? article.Dimension;
        article.Heaviness = heaviness ?? article.Heaviness;
        //Todo containers action need to be handle
        _context.SaveChanges();
        return article;
    }

    public bool Delete(int id)
    {
        Article? article = _context.Articles.First(a => a.Id == id);
        if (article == null)
        {
            throw new($"Address id doesn't exists:{id}");
        }

        try
        {
            _context.Articles.Remove(article);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}