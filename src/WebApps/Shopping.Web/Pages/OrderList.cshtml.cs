
namespace Shopping.Web.Pages
{
    public class OrderListModel(IOrderingService orderingService, ILogger<ProductDetailModel> _logger) 
        : PageModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            var customerId = new Guid("83b64e86-f22b-4bc7-8ca4-dafc8f5ba520");

            var response = await orderingService.GetOrdersByCustomer(customerId);
        
            Orders = response.Orders;

            return Page();
        }
    }
}
