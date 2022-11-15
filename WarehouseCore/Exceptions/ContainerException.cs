namespace WarehouseCore.Exceptions;

public class ContainerQtyZeroException : Exception
{
    public ContainerQtyZeroException(string message = "Container quantity cannot be ZERO") : base(message)
    {
    }
}

public class ContainerIdMissing : Exception
{
    public ContainerIdMissing(string message = "Container id doesn't exists") : base(message)
    {
    }
}

public class ContainerIdMatch : Exception
{
    public ContainerIdMatch(int id, string message = "Container with id already exist: ") : base(message + id)
    {
    } 
}

public class ContainerNoModified : Exception
{
    public ContainerNoModified(string message = "Container has not been modified") : base(message)
    {
    }
}