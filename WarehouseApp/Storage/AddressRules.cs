using WarehouseApp.Interfaces;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;

namespace WarehouseApp.Storage;

public class AddressRules : IAddressRules
{
    private readonly WarehouseDbContext _context;

    public AddressRules(WarehouseDbContext context)
    {
        _context = context;
    }
    
    public Address Create(string codeId, ICollection<Container>? containers = default,
        string? description = default)
    {
        Address address = new (codeId)
        {
            Containers = containers,
            Description = description
        };
        try
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            
            throw ;
        }

        return address;
    }
   
    public Address Modify(string codeId, string? description = default)
    {
        Address? address = _context.Addresses.First(c => c.CodeId == codeId);
        if (address == null)
        {
            throw new ($"address id doesn't exists: {codeId}");
        }
        if (description == default)
        {
            throw new ("there's nothing here to update");
        }
        
        address.Description = description;
        _context.SaveChanges();
        return address;
    }
    
    public bool Delete(string codeId)
    {
        Address? address = _context.Addresses.First(c => c.CodeId == codeId);
        if (address == null)
        {
            throw new ($"Address id doesn't exists:{codeId}");
        }

        if (address.Containers != null)
        {
            throw new Exception($"Address {codeId} has {address.Containers.Count} container. In order to delete an address, no container should be inside of it.");
        }

        try
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}