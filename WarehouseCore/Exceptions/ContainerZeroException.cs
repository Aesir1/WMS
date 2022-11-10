namespace WarehouseCore.Exceptions;

public class ContainerZeroException : Exception
{
    public ContainerZeroException(string message = "Container quantity cannot be ZERO") : base(message)
    {
    }
}