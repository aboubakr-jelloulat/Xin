namespace Catalog.API.Exceptions;

internal class ProductNotFoundException : Exception
{

    public ProductNotFoundException() : base("Product was not found.")
    {
    }

    public ProductNotFoundException(string? message) : base(message)
    {
    }

    public ProductNotFoundException(Guid productId) : base($"Product with ID {productId} was not found.")
    {
    }


}
