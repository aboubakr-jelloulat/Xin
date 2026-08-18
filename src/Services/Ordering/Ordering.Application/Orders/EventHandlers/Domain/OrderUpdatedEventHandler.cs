namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderUpdatedEventHandler : INotificationHandler<OrderUpdatedEvent>
{
    public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
