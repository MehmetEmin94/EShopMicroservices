using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            //create entity from command object
            // save to db
            // return result
            return new CreateOrderResult(Guid.NewGuid());
        }
    }
}
