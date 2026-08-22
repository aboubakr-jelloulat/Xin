using BuildingBlock.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket;


public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>;
public record CheckoutBasketResult(bool IsSuccess);

public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(x => x.BasketCheckoutDto)
            .NotNull()
            .WithMessage("Checkout data is required");

        // If DTO exists, validate all properties
        When(x => x.BasketCheckoutDto != null, () =>
        {
            RuleFor(x => x.BasketCheckoutDto.UserName)
                .NotEmpty().WithMessage("Username is required")
                .MaximumLength(50).WithMessage("Username cannot exceed 50 characters");

            RuleFor(x => x.BasketCheckoutDto.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required");
        });
    }
}

public class CheckoutBasketHandler(IBasketRepository basketRepository, IPublishEndpoint publishEndpoint) : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetBasket(command.BasketCheckoutDto.UserName, cancellationToken);

        if (basket is null)
            return new CheckoutBasketResult(false);

        var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        await basketRepository.DeleteBasket(command.BasketCheckoutDto.UserName);

        return new CheckoutBasketResult(true);
    }
}
