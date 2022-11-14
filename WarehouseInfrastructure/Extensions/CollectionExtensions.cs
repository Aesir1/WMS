namespace WarehouseInfrastructure.Extensions;

public static class CollectionExtensions
{
    public static void Foreach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        foreach (T entity in enumerable)
        {
            action(entity);
        }
    }
}