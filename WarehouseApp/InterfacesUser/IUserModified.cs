using WarehouseCore.Entities.Organisation;
using WarehouseCore.Entities.User;

namespace WarehouseApp.InterfacesUser;

public interface IUserModified
{
    User Modified(int id, string? email = default, string? password = default, Permission? permission = default,
        UserInfo? userInfo = default);
}