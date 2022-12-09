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
        Address address = new(codeId)
        {
            Containers = containers,
            Description = description
        };
        _context.Addresses.Add(address);
        _context.SaveChanges();

        return address;
    }

    public Address Modify(string codeId, string? description = default)
    {
        var address = _context.Addresses.FirstOrDefault(c => c.CodeId == codeId);
        if (address == null) throw new Exception($"Address id doesn't exists: {codeId}");
        if (description == address.Description) throw new Exception("there's nothing here to update");

        address.Description = description;
        _context.SaveChanges();
        return address;
    }

    public bool Delete(string codeId)
    {
        var address = _context.Addresses.FirstOrDefault(c => c.CodeId == codeId);
        if (address == null) throw new Exception($"Address id doesn't exists:{codeId}");

        if (address.Containers != null)
            throw new Exception(
                $"Address {codeId} has {address.Containers.Count} container. In order to delete an address, no container should be inside of it.");

        _context.Addresses.Remove(address);
        _context.SaveChanges();
        return true;
    }
}