using System;
using System.Collections.Generic;
using Trendyol.Entities.Abstract;
using Trendyol.Entities.Concrate;
using Trendyol.Services.Abstract;
using Trendyol.Services.Concrate;

namespace Trendyol
{
    class Program
    {
        static void Main(string[] args)
        {
			//Defined 2 category
			Category electronics = new Category("Electronics");
			Category auto = new Category("Automotive");

			//Defined 4 campaign with constructor method.
			IDiscount camp1 = new Campaign(electronics, DiscountType.Rate, 20, 3);
			IDiscount camp2 = new Campaign(electronics, DiscountType.Rate, 50, 5);
			IDiscount camp3 = new Campaign(electronics, DiscountType.Amount, 5, 10);
			IDiscount camp4 = new Campaign(auto, DiscountType.Rate, 20, 3);

			//Defined a coupon with Initialize method, Coupon implemented ICoupon and IDiscount interfaces.This is a example of use Interface Seg. princible.
			IDiscount coupon = new Coupon().Initialize("a45f", DiscountType.Amount, 10, 10);

			//Define 6 product with constructor method.
			Product mac = new Product("Macbook Pro", electronics, 10000.00m, 4);
			Product cas = new Product("Casper Nova", electronics, 3500m, 2);
			Product len = new Product("Lenovo RSX", electronics, 2000m, 1);
			Product hpx = new Product("Hp 1XN", electronics, 3800m, 1);
			Product mic = new Product("Michelin Tire", auto, 1000m, 4);
			Product amg = new Product("AMG Bodykit", auto, 8000m, 1);

			//Create new cart context and used dependency injection method for delivery operation, usable IoC also this class have single responsilibty princibles.
			IShoppingCartContext context = new ShoppingCartContext(new CargoDeliveryStrategy());

			//Added products at cart.
			context.AddItem(mac);
			context.AddItem(cas);
			context.AddItem(len);
			context.AddItem(hpx);
			context.AddItem(mic);
			context.AddItem(amg);

			//Apply discounts and delivery cost.
			context.Apply(new List<IDiscount>() { camp1, camp2, camp3, coupon });

			//other methods
			context.GetDeliveryCost();

			context.GetTotalDiscount();

			//Print cart
			context.Print();
        }
    }
}
