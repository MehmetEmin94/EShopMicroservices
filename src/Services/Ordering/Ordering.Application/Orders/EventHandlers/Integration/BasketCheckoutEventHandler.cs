using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration
{
    public class BasketCheckoutEventHandler
        (ISender sender,ILogger<BasketCheckoutEventHandler> logger)
        : IConsumer<BasketCheckoutEvent>
    {
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            logger.LogInformation("Integration Event Handler: {IntegrationEvent}", context.Message.GetType().Name);

            var command = MapToCreateOrderCommand(context.Message);

            await sender.Send(command);
        }

        private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
        {
            var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress, message.AddressLine, message.Country, message.State, message.ZipCode);
            var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);
            var orderId = Guid.NewGuid();

            var orderDto = new OrderDto(
           Id: orderId,
           CustomerId: message.CustomerId,
           OrderName: message.UserName,
           ShippingAddress: addressDto,
           BillingAddress: addressDto,
           Payment: paymentDto,
           Status: Ordering.Domain.Enums.OrderStatus.Pending,
           OrderItems:
           [
               new OrderItemDto(orderId, new Guid("3bcbe2a0-629d-4018-aeec-ca237158b9d7"), 5, 1500),
                new OrderItemDto(orderId, new Guid("a8d4c453-4977-41d1-ab0c-4389bfea40ab"), 1, 500)
           ]);

            return new CreateOrderCommand(orderDto);
        }
    }
}
