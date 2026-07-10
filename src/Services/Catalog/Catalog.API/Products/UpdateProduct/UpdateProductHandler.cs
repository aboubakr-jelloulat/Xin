namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand
(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
) : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool isSucces);

internal class UpdateProductCommandHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException(command.Id);

        var config = new TypeAdapterConfig();
        config.ForType<UpdateProductCommand, Product>()
        .Ignore(dest => dest.Id);

        command.Adapt(product, config);

        session.Update(product);

        await session.SaveChangesAsync();

        return new UpdateProductResult(true);
    }
}
