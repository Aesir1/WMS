using WarehouseApp.InterfacesStorage;
using WarehouseCore.Entities.Storage;
using WarehouseInfrastructure.Contexts;

namespace WarehouseApp.Storage;

public class AddressRules : IAddressCreate, IAddressModified, IAddressDelete
{
    private readonly WarehouseDbContext _context;

    public AddressRules(WarehouseDbContext context)
    {
        _context = context;
    }
    
    public Address Create(string codeId, ICollection<Container>? containers,
        string? description = default)
    {
        Address address = new (codeId)
        {
            Containers = containers,
            Description = description
        };
        try
        {
            // ToDo possible double address id reference specific implementations required  
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            
            throw ex;
        }

        return address;
    }
    
    public Address Modified(string codeId, string? description = default, ICollection<Container>? containers = default)
    {
        Address? address = _context.Addresses.First(c => c.CodeId == codeId);
        if (address == null)
        {
            throw new ($"address id doesn't exists: {codeId}");
        }
        if (description == default && containers == default)
        {
            throw new ("there's nothing here to update");
        }
        
        address.Description = description;
        // ToDo Containers collections need to be handle
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