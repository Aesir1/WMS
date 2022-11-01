namespace WarehouseCore.Entities.AbstractEntities;
/// <summary>
/// BaseEntity contains time
/// </summary>
public abstract class BaseEntity
{
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeUpdated { get; set; }
}