using ApiRest.Extensions;
using Microsoft.AspNetCore.Mvc;
using WarehouseApp.Interfaces;
using WarehouseApp.Storage;
using WarehouseCore.Entities.Product;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;

namespace ApiRest.Controllers;

public class ContainerController : Controller
{
    private readonly WarehouseDbContext _context;

    public ContainerController(WarehouseDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("internal/[controller]/getContainers")]
    public ActionResult<ICollection<Container>> GetContainer()
    {
        var containers = _context.Containers.ToList();
        return Ok(containers);
    }

    [HttpPost]
    [Route("internal/[controller]/createContainer")]
    public ActionResult<Container> CreateContainer([FromBody] int qty, [FromBody] Article article,
        [FromBody] Address address)
    {
        IContainerRules containerCreate = new ContainerRules(_context);
        Container container;
        try
        {
            container = containerCreate.Create(qty, article, address);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e);
        }

        // Todo refinement from URI signalization
        return Created($"internal/[controller]/getContainer:{container.Id}", container);
    }

    [HttpPatch]
    [Route("internal/[controller]/modifiedContainer")]
    public ActionResult<Container> ModifiedContainer(int id, int qty, [FromBody] Address? address,
        [FromBody] Article? article)
    {
        IContainerRules containerCreate = new ContainerRules(_context);
        Container container;
        try
        {
            container = containerCreate.Modified(id, qty, address, article);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // Todo check extension method works fine
            //return StatusCode(304,e);
            return this.NotModified(e);
        }
        // Todo refinement from URI signalization
        return Created($"internal/[controller]/getContainer:{container.Id}", container);
    }

    [HttpDelete]
    [Route("internal/[controller]/deleteContainer")]
    public ActionResult DeleteContainer(int id)
    {
        IContainerRules containerCreate = new ContainerRules(_context);
        Container container;
        try
        {
            containerCreate.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return this.NotModified(e);
        }
        return NoContent();
    }
}