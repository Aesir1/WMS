using ApiRest.Extensions;
using Microsoft.AspNetCore.Mvc;
using WarehouseApp.Interfaces;
using WarehouseApp.Storage;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Entities.Unities;
using WarehouseInfrastructure.Contexts;

namespace ApiRest.Controllers;

public class ArticleController : Controller
{
    private readonly WarehouseDbContext _context;

    public ArticleController(WarehouseDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("internal/[controller]/getArticle:Id")]
    public ActionResult<Article> GetArticle(int id)
    {
        Article? article = _context.Articles.FirstOrDefault(a => a.Id == id);
        if (article == null)
        {
            return NotFound();
        }
        return Ok(article);
    }
    
    [HttpGet]
    [Route("internal/[controller]/getArticles")]
    public ActionResult<ICollection<Article>> GetArticles()
    {
        var articles = _context.Articles.ToList();
        if (!articles.Any())
        {
            return NotFound();
        }
        return Ok(articles);
    }

    [HttpPost]
    [Route("internal/[controller]/createArticle")]
    public ActionResult<Article> CreateArticle([FromBody] int id, [FromBody] string name,
        [FromBody] ICollection<Container>? containers = default)
    {
        IArticleRules articleRules = new ArticleRules(_context);
        Article article;
        try
        {
            article = articleRules.Create(id, name, containers);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e);
        }
        // Todo refinement from URI signalization
        return Created($"internal/AddressController/getAddress:{article.Id}",article);
    }

    [HttpPatch]
    [Route("internal/[controller]/modifyArticle")]
    public ActionResult<Article> ModifyArticle([FromBody] int id, [FromBody] string? name = default,
        [FromBody] Dimension? dimension = default,[FromBody] Heaviness? heaviness = default)
    {
        IArticleRules articleRules = new ArticleRules(_context);
        Article article;
        try
        {
            article = articleRules.Modify(id, name, dimension, heaviness);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return this.NotModified(e);
        }
        return Ok(article);
    }
    
    [HttpDelete]
    [Route("internal/[controller]/deleteArticle")]
    public ActionResult DeleteArticle(int id)
    {
        IArticleRules articleRules = new ArticleRules(_context);
        try
        {
            articleRules.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return this.NotModified(e);
        }
        return NoContent();
    }
}