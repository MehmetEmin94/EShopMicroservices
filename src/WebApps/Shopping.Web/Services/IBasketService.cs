
namespace Shopping.Web.Services
{
    public interface IBasketService
    {
        [Get("/basket-service/basket/{userName}")]
        Task<GetBasketResponse> GetBasket(string userName);

        [Post("/basket-service/basket")]
        Task <StoreBasketResponse> StoreBasket(ShoppingCartModel Cart);

        [Delete("/basket-service/basket/{userName}")]
        Task<DeleteBasketResponse> DeleteBasket(string userName);

        [Post("/basket-service/basket/checkout")]
        Task<CheckoutBasketResponse> CheckoutBasket(BasketCheckoutModel BasketCheckoutDto);
    }
}
