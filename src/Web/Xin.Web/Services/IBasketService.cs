using Xin.Web.Models.Basket;

namespace Xin.Web.Services;

public interface IBasketService
{
    [Get("/basket-service/basket/{UserName}")]
    Task<GetBasketResponse> GetBasket(string UserName);


    [Post("/basket-service/basket")]
    Task<StoreBasketResponse> StoreBasket(StoreBasketRequest request);


    [Delete("/basket-service/basket/{userName}")]
    Task<DeleteBasketResponse> DeleteBasket(string userName);

    [Post("/basket-service/basket/checkout")]
    Task<CheckoutBasketResponse> CheckoutBasket(CheckoutBasketRequest request);

}
