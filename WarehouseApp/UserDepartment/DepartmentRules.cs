using WarehouseInfrastructure.Contexts;

namespace WarehouseApp.UserDepartment;

public class DepartmentRules
{
    private readonly WarehouseDbContext _context;

    public DepartmentRules(WarehouseDbContext context)
    {
        _context = context;
    }
    
    // ToDo Future feature create/delete departments and modified the personal attach to it
}