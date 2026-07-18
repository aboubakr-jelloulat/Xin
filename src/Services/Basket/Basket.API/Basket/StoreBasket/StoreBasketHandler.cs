namespace Basket.API.Basket.StoreBasket;


public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);


public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart)
            .NotNull().WithMessage("Cart can not be null");

        RuleFor(x => x.Cart.UserName)
            .NotEmpty().WithMessage("UserName is required")
            .MaximumLength(100).WithMessage("UserName must not exceed 100 characters")
            .MinimumLength(3).WithMessage("UserName must be at least 3 characters");

    }
}

public class StoreBasketCommandHandler(IBasketRepository repository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart shoppingCart = command.Cart;

        var basket = await repository.StoreBasket(shoppingCart, cancellationToken);

        return new StoreBasketResult(basket.UserName);
    }
}
