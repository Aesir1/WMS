using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseCore.Entities.Storage;
using WarehouseCore.Interfaces;

namespace WarehouseInfrastructure.Extensions;

public static class EfExtensions
{
    public static void IsConnectedWithContainer<T>(this EntityTypeBuilder<T> entitytype,
        Expression<Func<Container, T>> expresion) where T : class, IAttachableToContainer
    {
        entitytype.HasMany(a => a.Containers).WithOne(expresion).OnDelete(DeleteBehavior.NoAction);
    }
}