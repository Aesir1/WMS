using WarehouseCore.Entities.AbstractEntities;

namespace WarehouseCore.Entities.User;

public class UserInfo : IdEntity
{
    public string Street { get; set; }
    public string Nr { get; set; }
    public int PostalCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public User User { get; set; }
}