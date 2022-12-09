using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.Organisation;

public class Department : IdEntity
{
    public string Name { get; set; }
    public ICollection<User.User> Users { get; set; }

}