using WarehouseCore.Entities.Organisation;
using WarehouseCore.Entities.User;

namespace WarehouseApp.Interfaces;

public interface IUserRules
{
    User Create(string email, string password,
        ICollection<Department> departments, Permission permission, UserInfo? userInfo = default);
    User Modified(int id, string? email = default, string? password = default, Permission? permission = default,
        UserInfo? userInfo = default);
    bool Delete(int id);
}