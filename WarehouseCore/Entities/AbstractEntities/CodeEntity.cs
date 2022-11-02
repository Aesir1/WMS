namespace WarehouseCore.Entities.AbstractEntities;

public abstract class CodeEntity : BaseEntity
{
    public string CodeId { get; set; }
    public string? Description { get; set; }
}