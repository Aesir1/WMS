namespace WarehouseCore.Entities.AbstractEntities;

public abstract class IdEntity : BaseEntity
{
    protected IdEntity(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}