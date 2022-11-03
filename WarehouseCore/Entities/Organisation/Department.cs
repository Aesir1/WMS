using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.Organisation;

public class Department : GuidEntity
{
    public string Name { get; set; }
    public ICollection<User.User> Users { get; set; }
}