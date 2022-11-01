namespace WarehouseCore.Entities.AbstractEntities;

public abstract class BaseEntity
{
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeUpdated { get; set; }
}