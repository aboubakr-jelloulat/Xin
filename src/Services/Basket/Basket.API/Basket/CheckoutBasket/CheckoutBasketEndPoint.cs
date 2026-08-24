namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckoutDto);

public record CheckoutBasketResponse(bool IsSuccess);

public class CheckoutBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<CheckoutBasketCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CheckoutBasketResponse>();

            return Results.Ok(response);
        })
        .WithGroupName("CheckoutBasket")
        .Produces<CheckoutBasketResponse>(StatusCodes.Status200OK)
        .ProducesValidationProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Checkout shopping basket and initiate order processing");
    
    }
}
