using WarehouseApp.Interfaces;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Entities.Unities;
using WarehouseInfrastructure.Contexts;

namespace WarehouseApp.Storage;

public class ArticleRules : IArticleRules
{
    private readonly WarehouseDbContext _context;

    public ArticleRules(WarehouseDbContext context)
    {
        _context = context;
    }

    public Article Create(int id, string name, ICollection<Container>? containers = default,
        Dimension? dimension = default, Heaviness? heaviness = default)
    {
        Article article = new(id, name)
        {
            Containers = containers,
            Dimension = dimension,
            Heaviness = heaviness
        };
        
            _context.Articles.Add(article);
            _context.SaveChanges();
        return article;
    }

    public Article Modify(int id, string? name = default,
        Dimension? dimension = default, Heaviness? heaviness = default)
    {
        var article = _context.Articles.FirstOrDefault(c => c.Id == id);
        if (article == null) throw new Exception($"Article ID doesn't exists: {id}");

        if (name == article.Name && dimension == article.Dimension && heaviness == article.Heaviness)
            throw new Exception("there's nothing here to update");

        article.Name = name ?? article.Name;
        article.Dimension = dimension ?? article.Dimension;
        article.Heaviness = heaviness ?? article.Heaviness;
        _context.SaveChanges();
        return article;
    }

    public bool Delete(int id)
    {
        var article = _context.Articles.FirstOrDefault(a => a.Id == id);
        if (article == null) throw new Exception($"Article ID doesn't exists:{id}");

        _context.Articles.Remove(article);
        _context.SaveChanges();
        return true;
    }
}