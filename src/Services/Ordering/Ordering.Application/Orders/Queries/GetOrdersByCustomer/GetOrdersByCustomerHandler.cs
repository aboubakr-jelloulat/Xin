using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public class GetOrdersByCustomerHandler(IApplicationDbContext context) : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
{
    public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
    {
        //var orders = await context.Orders
        //    .Include(o => o.OrderItems)
        //    .AsNoTracking()
        //    .Where(o => o.OrderId.Value.Contains(query.Name))
        //    .OrderBy(o => o.OrderName.Value)
        //    .ToListAsync(cancellationToken);


        var orders = await context.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
            .OrderBy(o => o.OrderName.Value)
            .ToListAsync(cancellationToken);



        return new GetOrdersByCustomerResult(orders.ToOrderDtoIEnumerable());
    }
}
