using Xin.Web.Models.Ordering;

namespace Xin.Web.Services;

public interface IOrderingService
{
    [Get("/ordering-service/orders?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetOrdersResponse> GetOrders(int PageIndex = 0, int PageSize = 10);

    [Get("/ordering-service/orders/{orderName}")]
    Task<GetOrdersByNameResponse> GetOrdersByName(string orderName);

    [Get("/ordering-service/orders/customer/{customerId}")]
    Task<GetOrdersByCustomerResponse> GetOrdersByCustomer(Guid customerId);
}
