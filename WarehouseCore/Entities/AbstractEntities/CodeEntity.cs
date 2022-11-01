namespace WarehouseCore.Entities.AbstractEntities;

public abstract class CodeEntity : BaseEntity
{
    public string Code { get; set; }
    public string? Description { get; set; }

    protected CodeEntity(string code)
    {
        Code = code;
    }
}