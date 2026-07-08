namespace Catalog.API.Products.GetProductById;

//public record GetProductByIdRequest(Guid Id);

public record GetProductByIdResponse(Product Product);

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{Id}", async (Guid Id, ISender sender) =>
        {
            var query = new GetProductByIdQuery(Id);

            var result = await sender.Send(query);

            var response = result.Adapt<GetProductByIdResponse>();

            return Results.Ok(response);
        }).WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}
