namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductRequest(Guid Id);

public record DeleteProductResponse(bool IsSuccess);


public class DeleteProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products", async (Guid Id, ISender sender) =>
        {
            var command = new DeleteProductCommand(Id);

            var result = await sender.Send(command);

            var response = result.Adapt<DeleteProductResponse>();

            return Results.Ok(response);
        }).WithName("DeleteProduct")
        .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }
}
