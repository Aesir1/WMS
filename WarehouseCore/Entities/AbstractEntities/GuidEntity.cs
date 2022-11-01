namespace WarehouseCore.Entities.AbstractEntities;

public abstract class GuidEntity : BaseEntity
{
    protected GuidEntity()
    {
        Guid = new Guid();
    }

    public Guid Guid { get; set; }
}