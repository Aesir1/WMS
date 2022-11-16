using WarehouseCore.Entities.Organisation;
using WarehouseCore.Entities.User;
using WarehouseInfrastructure.Contexts;

namespace WarehouseApp.UserDepartment;

public class UserRules
{
    private readonly WarehouseDbContext _context;

    public UserRules(WarehouseDbContext context)
    {
        _context = context;
    }

    public User Create(int id, string email, string password,
        ICollection<Department> departments, Permission permission, UserInfo? userInfo = default)
    {
        User user = new(id)
        {
            Email = email,
            Password = password,
            Permission = permission,
            UserInfo = userInfo, 
            Departments = departments
        };
        try
        {
            // ToDo possible user id reference specific implementations required  
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return user;
    }

    public User Modified(int id, string? email = default, string? password = default, Permission? permission = default,
        UserInfo? userInfo = default)
    {
        var user = _context.Users.First(c => c.Id == id);
        if (user == null) throw new Exception($"address id doesn't exists: {id}");
        if (email == default || password == default || permission == default || userInfo == default)
            throw new Exception("there's nothing here to update");

        user.Email = email;
        user.Password = password;
        user.Permission = permission;
        user.UserInfo = userInfo;
        _context.SaveChanges();
        return user;
    }

    public bool Delete(int id)
    {
        var user = _context.Users.First(c => c.Id == id);
        if (user == null) throw new Exception($"Address id doesn't exists:{id}");

        try
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}