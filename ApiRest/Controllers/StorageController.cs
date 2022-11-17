using Microsoft.AspNetCore.Mvc;
using WarehouseApp.InterfacesStorage;
using WarehouseApp.Storage;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;

namespace ApiRest.Controllers;
[ApiController]
public class StorageController : Controller
{
    private readonly WarehouseDbContext _context;

    public StorageController(WarehouseDbContext context)
    {
        _context = context;
    }
    // GET
    // public IActionResult Index()
    // {
    //     return View();
    // }
    
    [HttpPost]
    [Route("api/[controller]/createContainer")]
    public IActionResult CreateContainer()
    {
        IContainerCreate containerCreate = new ContainerRules(_context);
        
        Container myContinaer = containerCreate.Create( 2, new Article( "Laptop"), new Address("STRA1"));
        
        return Ok();
    }
    
    [HttpGet]
    [Route("api/[controller]/getContainer")]
    public ActionResult<ICollection<Container>> GetContainer()
    {
        var containers = _context.Containers.ToList();
        return containers;
    }
}