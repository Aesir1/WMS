using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.Organisation;

public class Permission : IdEntity
{
    public bool UserManager { get; set; }
    public bool Delete { get; set; }
    public bool Modified { get; set; }
    public bool Create { get; set; }
    public bool Read { get; set; }
    public ICollection<User.User> Users { get; set; }

    public Permission(int id) : base(id)
    {
    }
}