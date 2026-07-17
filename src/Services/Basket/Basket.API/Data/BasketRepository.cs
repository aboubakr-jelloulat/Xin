using Basket.API.Exceptions;

namespace Basket.API.Data;

public class BasketRepository : IBasketRepository
{
    private readonly IDocumentSession _session;

    public BasketRepository(IDocumentSession session)
    {
        _session = session;
    }


    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        _session.Store(basket);
        await _session.SaveChangesAsync(cancellationToken);

        return basket;
    }

    public async Task<ShoppingCart> GetBasket(string UserName, CancellationToken cancellationToken = default)
    {
        var basket = await  _session.LoadAsync<ShoppingCart>(UserName, cancellationToken);

        return basket is not null ? basket :  throw new BasketNotFoundException(UserName);
    }

    public async Task<bool> DeleteBasket(string UserName, CancellationToken cancellationToken = default)
    {
        _session.Delete<ShoppingCart>(UserName);
        await _session.SaveChangesAsync(cancellationToken);

        return true;
    }

    
    
}
