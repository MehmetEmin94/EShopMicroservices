
namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderHandler(IApplicationDbContext dbContext)
        : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            //check entity is exist
            var orderId = OrderId.Of(command.Id);

            var order = await dbContext.Orders
                .FindAsync([orderId], cancellationToken: cancellationToken);

            if (order is null)
            {
                throw new OrderNotFoundException(command.Id);
            }

            //delete entity
            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new DeleteOrderResult(true);
        }
    }
}
