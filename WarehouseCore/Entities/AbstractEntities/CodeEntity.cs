namespace WarehouseCore.Entities.AbstractEntities;

public abstract class CodeEntity : BaseEntity
{
    protected CodeEntity(string codeId)
    {
        CodeId = codeId;
    }

    public string CodeId { get; set; }
    public string? Description { get; set; }
}