
namespace Ordering.Infrastructure.Data.Extentions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>
            {
                Customer.Create(CustomerId.Of(new Guid("83b64e86-f22b-4bc7-8ca4-dafc8f5ba520")),"mehmet","mehmet.aykan@gmail.com"),
                Customer.Create(CustomerId.Of(new Guid("db3d8011-36f5-4619-88c6-2227a94326c0")),"emin","emin.aykan@gmail.com")
            };

        public static IEnumerable<Product> Products =>
            new List<Product>
            {
                Product.Create(ProductId.Of(new Guid("3bcbe2a0-629d-4018-aeec-ca237158b9d7")),"IPhone 15",1000),
                Product.Create(ProductId.Of(new Guid("a8d4c453-4977-41d1-ab0c-4389bfea40ab")),"Samsung s24",900),
                Product.Create(ProductId.Of(new Guid("21b867fd-5b08-4bc6-bfbd-8d6d0d29b581")),"Huawei Plus", 1100),
                Product.Create(ProductId.Of(new Guid("8b65372b-fe24-455c-95c1-b2b9d550b332")),"Xiaomi Mi",800)
            };

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("mehmet", "aykan", "mehmet.aykan@gmail.com", "Sultanbeyli No:18", "Turkey", "Istanbul", "34925");
                var address2 = Address.Of("emin", "aykan", "emin.aykan@gmail.com", "Sultanbeyli No:20", "Turkey", "Istanbul", "34912");

                var payment1 = Payment.Of("mehmet", "5555555555554444", "12/28", "355", 1);
                var payment2 = Payment.Of("emin", "8885555555554444", "06/30", "222", 2);

                var order1 = Order.Create(
                                OrderId.Of(Guid.NewGuid()),
                                CustomerId.Of(new Guid("83b64e86-f22b-4bc7-8ca4-dafc8f5ba520")),
                                OrderName.Of("ORD_1"),
                                shippingAddress: address1,
                                billingAddress: address1,
                                payment1);
                order1.Add(ProductId.Of(new Guid("3bcbe2a0-629d-4018-aeec-ca237158b9d7")), 2, 1000);
                order1.Add(ProductId.Of(new Guid("8b65372b-fe24-455c-95c1-b2b9d550b332")), 1, 800);

                var order2 = Order.Create(
                                OrderId.Of(Guid.NewGuid()),
                                CustomerId.Of(new Guid("db3d8011-36f5-4619-88c6-2227a94326c0")),
                                OrderName.Of("ORD_2"),
                                shippingAddress: address2,
                                billingAddress: address2,
                                payment2);
                order2.Add(ProductId.Of(new Guid("a8d4c453-4977-41d1-ab0c-4389bfea40ab")), 1, 900);
                order2.Add(ProductId.Of(new Guid("21b867fd-5b08-4bc6-bfbd-8d6d0d29b581")), 2, 1100);

                return new List<Order> { order1, order2 };
            }
        }
    }
}
