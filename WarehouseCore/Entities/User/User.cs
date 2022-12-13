using WarehouseCore.Entities.AbstractEntities;
using WarehouseCore.Entities.Organisation;

namespace WarehouseCore.Entities.User;

public class User : IdEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Permission Permission { get; set; }
    public UserInfo? UserInfo { get; set; }
    public ICollection<Department> Departments { get; set; }
}