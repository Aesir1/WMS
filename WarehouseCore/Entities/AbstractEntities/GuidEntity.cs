namespace WarehouseCore.Entities.AbstractEntities;

public abstract class GuidEntity : BaseEntity
{
    public Guid Guid { get; set; }

    protected GuidEntity()
    {
        Guid = new Guid();
    }
    
}