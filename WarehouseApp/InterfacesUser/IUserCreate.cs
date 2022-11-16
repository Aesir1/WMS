using WarehouseCore.Entities.Organisation;
using WarehouseCore.Entities.User;

namespace WarehouseApp.InterfacesUser;

public interface IUserCreate
{
    User Create(int id, string email, string password,
        ICollection<Department> departments, Permission permission, UserInfo? userInfo = default);
}