namespace WarehouseCore.Exceptions;

public class ContainerQtyZeroException : Exception
{
    public ContainerQtyZeroException(string message = "Container quantity cannot be ZERO") : base(message)
    {
    }
}