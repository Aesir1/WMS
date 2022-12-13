using WarehouseApp.Interfaces;
using WarehouseApp.Storage;
using WarehouseCore.Entities.Unities;
using WarehouseInfrastructure.Contexts;

namespace IntegrationTest.Fixture;

public static class ArticleFixture
{
    public static readonly int Id = 7;
    public static readonly string Name = "Laptop";
    public static readonly Dimension Dimension = new("cm", 20, 40);
    public static readonly Heaviness Heaviness = new("kg", 2.2);


    public static void CreateOneArticle(WarehouseDbContext context)
    {
        IArticleRules articleRules = new ArticleRules(context);
        articleRules.Create(Id, Name, dimension: Dimension, heaviness: Heaviness);
    }

    public static void CreateListOfArticle(WarehouseDbContext context)
    {
        IArticleRules articleRules = new ArticleRules(context);
        articleRules.Create(Id, Name, dimension: Dimension, heaviness: Heaviness);
        articleRules.Create(10, "Coco",
            dimension: new Dimension("cm", 20, 40),
            heaviness: new Heaviness("kg", 2.2));
        articleRules.Create(69, "Surprise",
            dimension: new Dimension("cm", 20, 40),
            heaviness: new Heaviness("kg", 2.2));
    }
}