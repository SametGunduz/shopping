using System;
using Moq;
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
            var expectedCount = 1;
			var mockStrategy = new Mock<IDeliveryStrategy>();
            var context = new ShoppingCartContext(mockStrategy.Object);

			//Act
			context.AddItem(new Product("tv", new Category("electronics"), 30, 1));

            //Assert
            Assert.Equal(expectedCount, context.GetItemCount());
		}
    }
}
