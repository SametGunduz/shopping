using System;
using System.Collections.Generic;
using Moq;
using Trendyol.Entities.Abstract;
using Trendyol.Entities.Concrate;
using Trendyol.Services.Abstract;
using Trendyol.Services.Concrate;
using Xunit;

namespace Test
{
    public class ShoppingCartTests
    {
		[Fact]
		public void Shopping_Cart_Add_New_Item()
		{
			//Arrange
			var mockStrategy = new Mock<IDeliveryStrategy>();
			var context = new ShoppingCartContext(mockStrategy.Object);
            var expectedCount = 1;

			//Act
			context.AddItem(new Product("tv", new Category("electronics"), 30, 1));

			//Assert
			Assert.Equal(expectedCount, context.GetItemCount());
		}

		[Fact]
		public void Shopping_Cart_Total_Amount_Calculate()
		{
			//Arrange
			var mockStrategy = new Mock<IDeliveryStrategy>();
			var context = new ShoppingCartContext(mockStrategy.Object);
            var catg = new Category("electronics");
            var expectedAmount = 7500;

			//Act
			context.AddItem(new Product("tv", catg, 3000, 1));
			context.AddItem(new Product("pc", catg, 4500, 1));

			var act = context.GetTotalAmount();

			//Assert
            Assert.Equal(expectedAmount, act);
		}

		[Fact]
		public void Shopping_Cart_Total_Delivery_Cost_Calculate()
		{
            //Arrange
            var deliveryStrategy = new CargoDeliveryStrategy();
			var context = new ShoppingCartContext(deliveryStrategy);
			var catg = new Category("electronics");
            decimal expectedAmount = 20.99m;

			//Act
			context.AddItem(new Product("tv", catg, 3000, 1));
			context.AddItem(new Product("pc", catg, 4500, 1));

            var campaign = new Campaign(catg, DiscountType.Rate, 20, 2);

            context.Apply(new List<IDiscount> { campaign });

            var act = context.GetDeliveryCost();

			//Assert
			Assert.Equal(expectedAmount, act);
		}

		[Fact]
		public void Shopping_Cart_Total_Discount_Calculate()
		{
			//Arrange
			var deliveryStrategy = new CargoDeliveryStrategy();
			var context = new ShoppingCartContext(deliveryStrategy);
			var catg = new Category("electronics");
			decimal expectedAmount = 1500;

			//Act
			context.AddItem(new Product("tv", catg, 3000, 2));
			context.AddItem(new Product("pc", catg, 4500, 1));

			var campaign = new Campaign(catg, DiscountType.Rate, 20, 2);

			context.Apply(new List<IDiscount> { campaign });

            var act = context.GetTotalDiscount();

			//Assert
			Assert.Equal(expectedAmount, act);
		}
    }
}
