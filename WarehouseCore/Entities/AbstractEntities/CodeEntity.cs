namespace WarehouseCore.Entities.AbstractEntities;

public abstract class CodeEntity : BaseEntity
{
    protected CodeEntity(string code)
    {
        Code = code;
    }

    public string Code { get; set; }
    public string? Description { get; set; }
}