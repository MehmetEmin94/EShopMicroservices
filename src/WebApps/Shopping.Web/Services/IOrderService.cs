namespace Shopping.Web.Services
{
    public interface IOrderingService
    {
        [Get("/ordering-service/orders?pageNumber={pageNumber}&pageSize={pageSize}")]
        Task<GetOrdersResponse> GetOrders(int? PageNumber = 1, int? PageSize = 10);

        [Get("/ordering-service/orders/customer/[customerId]")]
        Task <GetOrdersByCustomerResponse> GetOrdersByCustomer(Guid customerId);

        [Get("/ordering-service/orders/[orderName]")]
        Task<GetOrdersByNameResponse> GetOrdersByName(string orderName);
    }
}
