using ApiRest.Extensions;
using Microsoft.AspNetCore.Mvc;
using WarehouseApp.Interfaces;
using WarehouseApp.Storage;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;

namespace ApiRest.Controllers;

public class AddressController : Controller
{
    private readonly WarehouseDbContext _context;

    public AddressController(WarehouseDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Route("internal/[controller]/getAddress:codeId")]
    public ActionResult<Address> GetAddress(string codeId)
    {
        Address? address = _context.Addresses.FirstOrDefault(a => a.CodeId == codeId);
        if (address == null)
        {
            return NotFound();
        }
        return Ok(address);
    }
    
    [HttpGet]
    [Route("internal/[controller]/getAddresses")]
    public ActionResult<ICollection<Address>> GetAddresses()
    {
        var addresses = _context.Addresses.ToList();
        if (!addresses.Any())
        {
            return NotFound();
        }
        return Ok(addresses);
    }

    [HttpPost]
    [Route("internal/[controller]/createAddress")]
    public ActionResult<Address> CreateAddress([FromBody] string id,
        [FromBody] ICollection<Container>? containers = default, [FromBody] string? description = default)
    {
        IAddressRules addressRules = new AddressRules(_context);
        Address address;
        try
        {
            address = addressRules.Create(id, containers, description);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e);
        }
        // Todo refinement from URI signalization
        return Created($"internal/AddressController/getAddress:{address.CodeId}", address);
    }

    [HttpPatch]
    [Route("internal/[controller]/modifiedAddress")]
    public ActionResult<Address> ModifyAddress([FromBody] string codeId, string? description = default)
    {
        IAddressRules addressRules = new AddressRules(_context);
        Address address;
        try
        {
            address = addressRules.Modify(codeId, description);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return this.NotModified(e);
        }
        return Ok(address);
    }

    [HttpDelete]
    [Route("internal/[controller]/deleteAddress")]
    public ActionResult DeleteAddress(string codeId)
    {
        IAddressRules addressRules = new AddressRules(_context);
        try
        {
            addressRules.Delete(codeId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return this.NotModified(e);
        }
        return NoContent();
    }
}