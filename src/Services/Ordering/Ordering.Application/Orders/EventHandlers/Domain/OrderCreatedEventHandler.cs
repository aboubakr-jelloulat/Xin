using MassTransit;
using Microsoft.FeatureManagement;

namespace Ordering.Application.Orders.EventHandlers.Domain;


/*
    Feature Management  is a pattern that lets you enable or disable features at runtime without deploying new code.
 
            When OrderFullfilment = true:
                Order Created → Handler Called → Check Feature → TRUE 
                → Publish integration event →/Notification services react/blazor
                → Full order fulfillment workflow executes

            When OrderFullfilment = false:
            Order Created → Handler Called → Check Feature → FALSE 
            → Skip publishing → No integration events sent
            → Order is created but other services don't know about it
 
 */
public class OrderCreatedEventHandler(IPublishEndpoint publishEndpoint, IFeatureManager featureManager) : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (await featureManager.IsEnabledAsync("OrderFullfilment"))
        {
            var orderCreatedIntegrationEvent = notification.order.ToOrderDto();

            await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
        }
        
    }
}
