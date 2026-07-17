namespace Basket.API.Exceptions;

internal class BasketNotFoundException : Exception
{
    public BasketNotFoundException() : base("Basket was not found.")
    {
    }


    public BasketNotFoundException(string UserName) : base($"Basket with User Name {UserName} was not found.")
    {
    }
}
